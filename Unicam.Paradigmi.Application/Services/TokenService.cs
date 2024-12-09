using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Options;
using Unicam.Paradigmi.Models.Entities;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
	public class TokenService : ITokenService
	{
		public readonly JwtAuthenticationOption _jwtAuthenticationOption;
		public readonly UserRepository _userRepository;

		public TokenService(IOptions<JwtAuthenticationOption> jwtAuthenticationOption, UserRepository userRepository)
		{
			_userRepository = userRepository;
			_jwtAuthenticationOption = jwtAuthenticationOption.Value;
		}

		public async Task<string> CreateTokenStringAsync(string email, string password)
		{
			var user = await _userRepository.GetUserFromEmailAndPassword(email, password);

			return user == null ? throw new InvalidCredentialException("Invalid email or password") : CreateJwtToken(user);
		}

		private string CreateJwtToken(User user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtAuthenticationOption.Key));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var claims = new List<Claim>
			{
				new("UserId", user.UserId.ToString()),
				new("Name", user.Name),
				new("Surname", user.Surname),
				new("Email", user.Email),
				new("Password",user.Password)
		};

			var jwtSecurityToken = new JwtSecurityToken(_jwtAuthenticationOption.Issuer,
				null,
				claims,
				expires: DateTime.Now.AddHours(2),
				signingCredentials: credentials
			);
			return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
		}
	}
}
