using AmcomanApi.ViewModel.Authentication;
using mialco.amcoman.dal;
using mialco.amcoman.dal.Entity;
using mialco.amcoman.shared;
using mialco.amcoman.shared.Abstraction;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

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

		public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, AmcomanContext context, IConfiguration configuration, IAmcomanVars vars)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_context = context;
			_configuartion = configuration;
			_vars = vars;
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
			return CreatedAtAction(nameof(RegisterUser), new { id = newUser.Id }, newUser);
		}

		private async Task<AuthResultVm> GenerateJwtToken(ApplicationUser user)
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
			var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_vars.JwtKey));
			var token = new JwtSecurityToken(
				issuer: _vars.JwtIssuer,
				audience: _vars.JwtIssuer,
				expires: DateTime.UtcNow.AddMinutes(30), //Typical Time 1-3 minutes //TODO: Move to config
				claims: authClaims,
				signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
			);
			var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
			var refreshToken = new RefreshToken
			{
				JwtId = jti,
				IsRevoked = false,
				DateAdded = DateTime.UtcNow,
				DateExpire = DateTime.UtcNow.AddMonths(6), //TODO: Move to config
				Token = Guid.NewGuid().ToString() + "-" + Guid.NewGuid().ToString(),
				UserId = user.Id,
			};
			await _context.RefreshTokens.AddAsync(refreshToken); //todo: add to repo
			await _context.SaveChangesAsync(); //todo: add to repo

			var response = new AuthResultVm
			{
				Token = jwtToken,
				RefreshToken = refreshToken.Token,
				ExpiresAt = token.ValidTo
			};
			return response;
		}

		//[HttpPost("login-user")]
		//public async Task<IActionResult> LoginUser([FromBody] LoginVm payload)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return BadRequest(ModelState);
		//	}

		//	//todo: allow login with emailor user name as well
		//	var user = await _userManager.FindByNameAsync(payload.UserName);
		//	if (user == null || !await _userManager.CheckPasswordAsync(user, payload.Password))
		//	{
		//		Log.Error("User [{User}] not found or password is incorrect", payload.UserName);
		//		return Unauthorized();
		//	}
		//	Log.Information("User [{User}] logged in", payload.UserName);
		//	var result = await GenerateJwtToken(user);
		//	return Ok(result);
		//}

		[HttpPost("login-user")]
		public async Task<IActionResult> RefreshToken([FromBody] LoginVm payload)
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
					var result = await GenerateJwtToken(user);
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

	}
}
