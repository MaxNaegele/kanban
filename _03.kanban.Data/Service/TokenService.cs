using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using _02.kanban.Application.Interfaces.Services;
using _04.kanban.Core.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace _03.kanban.Data.Service
{
    public class TokenService : ITokenService
    {
        private IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(DataUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = GetClaimsIdentity(user),
                Audience = _configuration[nameof(JwtOptions.Audience)],
                Issuer = _configuration[nameof(JwtOptions.Issuer)],
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration[nameof(JwtOptions.Expires)])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration[nameof(JwtOptions.Secret)])), SecurityAlgorithms.HmacSha512Signature),
            });
            return tokenHandler.WriteToken(tokenDescriptor);
        }
        private ClaimsIdentity GetClaimsIdentity(DataUser user)
        {
            return new ClaimsIdentity(
                new[] {
                        new Claim ("Id", user.Id.ToString()),
                        new Claim (ClaimTypes.Name, user.Name),
                        new Claim (ClaimTypes.Email, user.Email),
                }
            );
        }
    }
}