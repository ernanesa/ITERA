using System;
using System.Collections.Generic;
using ITERA.Interfaces.Repositories;
using ITERA.Interfaces.Services;
using ITERA.Models;

namespace ITERA.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public Empresa Adicionar(Empresa empresa)
        {
            return _empresaRepository.Adicionar(empresa);
        }

        public void Atualizar(Empresa empresa)
        {
            // TODO: Verificar necessidade de Implementar
            throw new NotImplementedException();
        }

        public Empresa ObterPorId(string id)
        {
            return _empresaRepository.ObterPorId(id);
        }

        public IEnumerable<Empresa> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Empresa empresa)
        {
            _empresaRepository.Remover(empresa);
        }
    }
}