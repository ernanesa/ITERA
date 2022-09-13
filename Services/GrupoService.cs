using System;
using System.Collections.Generic;
using ITERA.Interfaces.Repositories;
using ITERA.Interfaces.Services;
using ITERA.Models;

namespace ITERA.Services
{
    public class GrupoService : IGrupoService
    {
        private readonly IGrupoRepository _grupoRepository;

        public GrupoService(IGrupoRepository grupoRepository)
        {
            _grupoRepository = grupoRepository;
        }

        public Grupo Adicionar(Grupo grupo)
        {
            return _grupoRepository.Adicionar(grupo);
        }

        public void Atualizar(Grupo grupo, Empresa empresa)
        {
            _grupoRepository.Atualizar(grupo, empresa);
        }

        public void Atualizar(Grupo grupo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Grupo> ObterPorData(DateTime date)
        {
            return _grupoRepository.ObterPorData(date);
        }

        public Grupo ObterPorId(int id)
        {
            return _grupoRepository.ObterPorId(id);
        }

        public IEnumerable<Grupo> ObterTodos()
        {
            return _grupoRepository.ObterTodos();
        }

        public void Remover(Grupo grupo)
        {
            throw new NotImplementedException();
        }
    }
}