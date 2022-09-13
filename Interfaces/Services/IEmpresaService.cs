using System.Collections.Generic;
using ITERA.Models;

namespace ITERA.Interfaces.Services
{
    public interface IEmpresaService
    {
        Empresa Adicionar(Empresa empresa);
        void Atualizar(Empresa empresa);
        Empresa ObterPorId(string id);
        IEnumerable<Empresa> ObterTodos();
        void Remover(Empresa empresa);
    }
}