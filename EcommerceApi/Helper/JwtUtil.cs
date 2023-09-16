using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EcommerceApi.Abstract;
using EcommerceApi.Dto;
using EcommerceApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace EcommerceApi.Helper
{
	public class JwtUtil : IJwtUtils
    {
        private IConfiguration _configuration;


		public JwtUtil(IConfiguration configuration)
		{
            _configuration = configuration;
		}

        public string GenerateJwtToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(

                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                 );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public int ValidateJwtToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}

