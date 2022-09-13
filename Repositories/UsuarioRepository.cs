using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using ITERA.Models;
using ITERA.Interfaces.Repositories;

namespace ITERA.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private char separator = Path.DirectorySeparatorChar;
        string filePath;

        private string _data;

        public UsuarioRepository()
        {
            filePath = @$"Data{separator}user.json";
            _data = File.ReadAllText(filePath);
        }


        public Usuario Login(string login, string senha)
        {
            try
            {
                var usuarios = JsonSerializer.Deserialize<Usuario[]>(_data);

                return usuarios.Where(p => p.login == login && p.senha == senha && p.ativo).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}