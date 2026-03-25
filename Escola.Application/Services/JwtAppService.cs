using Escola.Application.Interfaces;
using Escola.Application.ViewModel;
using Escola.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Escola.Application.Services
{
    public class JwtAppService: IJwtAppService
    {

        private IConfiguration _configuration;
        public JwtAppService(IConfiguration configuration)
        {

            _configuration = configuration;

        }

        public string GerarToken(UsuarioDTO usuario)
        {
            var jwtConfig = _configuration.GetSection("JwtSettings");

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["SecretKey"]!));

            var claims = new[]
            {
                new Claim("UsuarioId", usuario.UsuarioId.ToString()),
                new Claim("Nome", usuario.Nome),
                new Claim("Email", usuario.Email)
            };

            var token = new JwtSecurityToken(
                issuer: jwtConfig["Issuer"],
                audience: jwtConfig["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
