using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherForecastApiJwtSandbox.Models;
using WeatherForecastApiJwtSandbox.Services;

namespace WeatherForecastApiJwtSandbox.Controllers
{
    [ApiController]
    public class LoginController : Controller
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("[controller]/[action]")]
        public IActionResult Entrar(Login model)
        {
            try
            {
                var service = new AutenticacaoService();
                var usuario = service.Autenticar(model);

                if (usuario == null)
                {
                    return Unauthorized(new { message = "Usuário e/ou senha inválidos." });
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
