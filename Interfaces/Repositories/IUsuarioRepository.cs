using ITERA.Models;

namespace ITERA.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario Login(string login, string senha);
    }
}