using ITERA.Interfaces.Services;
using ITERA.Services;
using ITERA.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITERA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Login([FromBody] LoginViewModel login)
        {
            if (string.IsNullOrEmpty(login.Login) || string.IsNullOrEmpty(login.Senha))
                return BadRequest();

            var usuario = _usuarioService.Login(login.Login, login.Senha);
            if (usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GerarToken(usuario);
            usuario.senha = "";

            return new
            {
                usuario,
                token
            };
        }
    }
}