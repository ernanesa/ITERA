using ITERA.Interfaces.Repositories;
using ITERA.Models;
using ITERA.Interfaces.Services;

namespace ITERA.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Login(string login, string senha)
        {
            return _usuarioRepository.Login(login, senha);
        }
    }
}