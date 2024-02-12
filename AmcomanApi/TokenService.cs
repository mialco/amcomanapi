using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AmcomanApi
{
	public class TokenService
	{

		private readonly IConfiguration _config;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

		public TokenService(IConfiguration config, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_config = config;
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public async Task<string> CreateToken(IdentityUser user)
		{
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.NameId, user.Id),
				new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
			};

			var roles = await _userManager.GetRolesAsync(user);

			claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddDays(7),
				SigningCredentials = creds
			};

			var tokenHandler = new JwtSecurityTokenHandler();

			var token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}
	}
}
