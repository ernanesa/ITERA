using System;
using System.Collections.Generic;
using ITERA.Models;

namespace ITERA.Interfaces.Repositories
{
    public interface IGrupoRepository
    {
        Grupo Adicionar(Grupo grupo);
        void Atualizar(Grupo grupo, Empresa empresa);
        Grupo ObterPorId(int id);
        IEnumerable<Grupo> ObterTodos();
        IEnumerable<Grupo> ObterPorData(DateTime date);
        void Remover(Grupo grupo);
    }
}