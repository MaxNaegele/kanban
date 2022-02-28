namespace _01.kanban.WebApi.Authorizattion;

public class TokenService
    {
        private IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration[nameof(JwtOptions.Secret)])), SecurityAlgorithms.HmacSha256),
                Subject = GetClaimsIdentity(user)
            });
            return tokenHandler.WriteToken(tokenDescriptor);
        }
        private ClaimsIdentity GetClaimsIdentity(user)
        {
            return new ClaimsIdentity(
                new[] {
                        new Claim ("UseId", user.use_id.ToString()),
                        new Claim (ClaimTypes.Name, user.usu_nome),
                        new Claim (ClaimTypes.Email, user.usu_email),                    
                }
            );
        }
    }