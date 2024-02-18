using AmcomanApi.ViewModel.Authentication;
using mialco.amcoman.dal;
using mialco.amcoman.dal.Entity;
using mialco.amcoman.shared;
using mialco.amcoman.shared.Abstraction;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using mialco.amcoman.shared.Constants;

namespace AmcomanApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly AmcomanContext _context;
		private readonly IConfiguration _configuartion;
		private readonly IAmcomanVars _vars;
		private readonly TokenValidationParameters _tokenValidationParameters;
		

		public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, AmcomanContext context, IConfiguration configuration, IAmcomanVars vars, TokenValidationParameters tokenValidationParameters)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_context = context;
			_configuartion = configuration;
			_vars = vars;
			_tokenValidationParameters = tokenValidationParameters;
		}

		[HttpPost("register-user")]
		public async Task<IActionResult> RegisterUser([FromBody] RegisterUserVm payload)
		{
			var userExists = await _userManager.FindByNameAsync(payload.UserName);
			var emailExists = await _userManager.FindByEmailAsync(payload.Email);

			if (userExists != null)
			{
				Log.Error("Username [{userName}] already exists  (Email [{Email}])", payload.UserName, payload.Email);
				ModelState.AddModelError("Username", "Username already exists");
			}
			if (emailExists != null)
			{
				Log.Error("Email [{Email}] already exists  (User [{User}])", payload.Email, payload.UserName);
				ModelState.AddModelError("Username", "Username already exists");
			}
			if (userExists != null && emailExists != null)
			{
				return BadRequest(ModelState);
			}

			var newUser = new ApplicationUser
			{
				UserName = payload.UserName,
				Email = payload.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
			};

			var result = await _userManager.CreateAsync(newUser, payload.Password);

			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(error.Code, error.Description);
				}
				return BadRequest(ModelState);
			}

			if (string.IsNullOrEmpty(payload.Role))
			{
				payload.Role = UserRolesNames.User;
			}
			switch (payload.Role)
			{
				case UserRolesNames.Admin:
					await _userManager.AddToRoleAsync(newUser, UserRolesNames.Admin);
					break;
				case UserRolesNames.User:
					await _userManager.AddToRoleAsync(newUser, UserRolesNames.User);
					break;
				case UserRolesNames.Guest:
					await _userManager.AddToRoleAsync(newUser, UserRolesNames.Guest);
					break;
				case UserRolesNames.ContentManager:
					await _userManager.AddToRoleAsync(newUser, UserRolesNames.ContentManager);
					break;
				default:
					await _userManager.AddToRoleAsync(newUser, UserRolesNames.User);
					break;
			}
			return CreatedAtAction(nameof(RegisterUser), new { id = newUser.Id }, newUser);
		}

		private async Task<AuthResultVm> GenerateJwtTokenAsync(ApplicationUser user, string existingRefreshToken)
		{
			var jti = Guid.NewGuid().ToString();
			var authClaims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim(JwtRegisteredClaimNames.Sub, user.Email),
				new Claim(JwtRegisteredClaimNames.Jti,jti )
			};

			//Add roles to the token
			//var userRoles = await _userManager.GetRolesAsync(user);

			var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_vars.JwtKey));
			var credentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256);
			var roles = await _userManager.GetRolesAsync(user);
			var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();
			var userClaims = await _userManager.GetClaimsAsync(user);
			var claims = new List<Claim>{
				new Claim(JwtRegisteredClaimNames.Sub, user.Email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim("uid", user.Id)
			}.Union(userClaims).Union(roleClaims) ;			
			//This token did not work
			//var token = new JwtSecurityToken(
			//	issuer: _vars.JwtIssuer,
			//	audience: _vars.JwtIssuer,
			//	expires: DateTime.UtcNow.AddMinutes(30), //Typical Time 1-3 minutes //TODO: Move to config
			//	claims: authClaims,
			//	signingCredentials: credentials
			//);
			var expiryInMinutes = _configuartion.GetValue<int>("Jwt:ExpiryInMinutes");
			var refreshTokenExpiryInDays = _configuartion.GetValue<int>("Jwt:RefreshTokenExpiryInDays");
			var token = new JwtSecurityToken(
				issuer: _vars.JwtIssuer,
				audience: _vars.JwtIssuer,
				expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
				claims: claims,
				signingCredentials: credentials
			);

			var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
			var refreshToken = new RefreshToken();
			if (string.IsNullOrEmpty(existingRefreshToken))
			{
				refreshToken = new RefreshToken
				{
					JwtId = jti,
					IsRevoked = false,
					DateAdded = DateTime.UtcNow,
					DateExpire = DateTime.UtcNow.AddDays(refreshTokenExpiryInDays),
					Token = Guid.NewGuid().ToString() + "-" + Guid.NewGuid().ToString(),
					UserId = user.Id,
				};
				await _context.RefreshTokens.AddAsync(refreshToken); //todo: add to repo
				await _context.SaveChangesAsync(); //todo: add to repo
			}

			var response = new AuthResultVm
			{
				Token = jwtToken,
				RefreshToken = (string.IsNullOrEmpty(existingRefreshToken)) ? refreshToken.Token: existingRefreshToken,
				ExpiresAt = token.ValidTo
			};
			return response;
		}

		[HttpPost("login-user")]
		public async Task<IActionResult> LoginUser([FromBody] LoginVm payload)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var user = await _userManager.FindByNameAsync(payload.UserName);
			if (user == null)
			{
				Log.Error("User Name [{User}] not found", payload.UserName);

				// verify if the user name is an email
				var matchEmail = Regex.Match(payload.UserName, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
				//we check for the email as well
				if (matchEmail.Success)
				{
					user = await _userManager.FindByEmailAsync(payload.UserName);
					if (user == null)
					{
						Log.Error("Email [{Email}] not found", payload.UserName);
						return Unauthorized();
					}
				}
				else
				{
					return Unauthorized();

				}
			}
			if (user != null)
			{
				var isValid = await _userManager.CheckPasswordAsync(user, payload.Password);

				if (isValid)
				{
					
					var result = await GenerateJwtTokenAsync(user,string.Empty);
					return Ok(result);
				}
				else
				{
					Log.Error("Password for user [{User}] is incorrect", payload.UserName);
					return Unauthorized();
				}
			}
			else
			{
				Log.Error("User [{User}] not found", payload.UserName);
				return Unauthorized();
			}
		}

		[HttpPost("refresh-token")]
		public async Task<IActionResult> RefreshToken([FromBody] TokenRequestVm payload)
		{
			try
			{
				var result = await VerifyAndGenerateTokenAsync(payload);
				if (result == null)
				{
					return BadRequest("Invalid Token");
				}
				return Ok(result);
			}
			catch (Exception ex)
			{
				return	BadRequest(ex.Message);
			}
		}

		private async Task<AuthResultVm> VerifyAndGenerateTokenAsync(TokenRequestVm payload)
		{
			try
			{
				//1. verify the jwt token format
				var jwtTokenHandler = new JwtSecurityTokenHandler();
				var tokenInVerification = jwtTokenHandler.ValidateToken(payload.Token, _tokenValidationParameters, out var validatedToken);

				//2. check the encryption algorithm
				if (validatedToken is JwtSecurityToken jwtSecurityToken)
				{
					var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
					if (result == false)
					{
						return null;
					}
				}

				//3. check expiry date
				var utcexpiryDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
				var expiryDate = UnixTimeStampToDateTimeInUTC(utcexpiryDate);
				if (expiryDate > DateTime.UtcNow) throw new Exception("This token hasn't expired yet");
				//4. check if the token exists in the database
				var dbRefreshToken = _context.RefreshTokens.FirstOrDefault(x => x.Token == payload.RefreshToken);
				if (dbRefreshToken == null)
				{
					throw new Exception("This refresh token does not exist");
				}
				else
				{
					//5. check if the token has been revoked
					var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
					if (dbRefreshToken.JwtId != jti) throw new Exception("This refresh token does not match this JWT token");
					//6. check if the token has expired
					if (dbRefreshToken.DateExpire <= DateTime.UtcNow) throw new Exception("This refresh token has expired, please re-authenticate");
					//7. check if the token is revoked
					if (dbRefreshToken.IsRevoked) throw new Exception("This refresh token has been revoked");
					//Generate new token(with existing refresh token)
					var dbUserData = await _userManager.FindByIdAsync(dbRefreshToken.UserId);
					var newTokenResponse = GenerateJwtTokenAsync(dbUserData, payload.RefreshToken);
					return await newTokenResponse;
				}

			}
			catch (SecurityTokenExpiredException)
			{
				//Generate new token(with existing refresh token)
				var dbRefreshToken = _context.RefreshTokens.FirstOrDefault(x => x.Token == payload.RefreshToken);
				var dbUserData = await _userManager.FindByIdAsync(dbRefreshToken.UserId);
				var newTokenResponse = GenerateJwtTokenAsync(dbUserData, payload.RefreshToken);
				return await newTokenResponse;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}


		}

		private DateTime UnixTimeStampToDateTimeInUTC(long utcexpityDate)
		{
			var datetimevalue = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			datetimevalue= datetimevalue.AddSeconds(utcexpityDate).ToUniversalTime();
			return datetimevalue;
		}
	}
}
