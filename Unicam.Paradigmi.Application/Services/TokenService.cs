using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Application.Options;
using Unicam.Paradigmi.Models.Entities;
using Unicam.Paradigmi.Models.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
	public class TokenService
	{
        public readonly JwtAuthenticationOption _jwtAuthenticationOption;
		public readonly UserRepository _userRepository;

        public TokenService(UserRepository userRepository,
            IOptions<JwtAuthenticationOption> jwtAuthentication)
        {
            _userRepository = userRepository;
            _jwtAuthenticationOption = jwtAuthentication.Value;
        }

		public async Task<string> CreateTokenAsync(string email, string password)
		{
			var user = await _userRepository.GetUserFromEmailAndPassword(email, password);

			if (user == null) throw new InvalidCredentialException("Invalid email or password");

			return CreateJwtToken(user);
		}

		private string CreateJwtToken(User user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtAuthenticationOption.Key));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var claims = new List<Claim>
		{
			new("user_id", user.UserId.ToString()),
			new("Name", user.Username),
			new("Surname", user.Surname),
			new("Email", user.Email)
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
