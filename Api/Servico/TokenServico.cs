using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api.Model;
using Microsoft.IdentityModel.Tokens;

namespace Api.Servico
{
    public class TokenServico
    {
        private readonly IConfiguration _configuration;

        public TokenServico(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(usuarioModel model)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, model.Usuario)
                    }),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(8),
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}