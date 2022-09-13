using System;
using System.Collections.Generic;
using ITERA.Models;

namespace ITERA.Interfaces.Services
{
    public interface IGrupoService
    {
        Grupo Adicionar(Grupo grupo);
        void Atualizar(Grupo grupo, Empresa empresa);
        Grupo ObterPorId(int id);
        IEnumerable<Grupo> ObterTodos();
        IEnumerable<Grupo> ObterPorData(DateTime date);
        void Remover(Grupo grupo);
    }
}