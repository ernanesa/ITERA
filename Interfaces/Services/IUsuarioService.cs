using ITERA.Models;

namespace ITERA.Interfaces.Services
{
    public interface IUsuarioService
    {
        Usuario Login(string login, string senha);
    }
}
