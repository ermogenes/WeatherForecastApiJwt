using System;
using System.IdentityModel.Tokens.Jwt;
using WeatherForecastApiJwtSandbox.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace WeatherForecastApiJwtSandbox.Services
{
    public class AutenticacaoService
    {
        public Usuario Autenticar(Login loginModel)
        {
            string login = loginModel.username;
            string senha = loginModel.password;

            // Substituir por uma validação correta
            if (login.Trim() == "teste" && senha.Trim() == "teste")
            {

                // Buscar usuário no banco
                var usuario = new Usuario { Nome = "João", Papel = "User" };

                var chavePrivada = Configuracoes.GetChavePrivada();
                
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(
                        new Claim[] 
                        {
                            new Claim(ClaimTypes.Name, usuario.Nome),
                            new Claim("PapelUsuarioAplicacao", usuario.Papel),
                        }
                    ),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(chavePrivada),
                        SecurityAlgorithms.HmacSha256Signature
                    ),
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                usuario.Token = tokenHandler.WriteToken(token);

                return usuario;
            }
            else
            {
                return null;
            }
            
        }
    }
}