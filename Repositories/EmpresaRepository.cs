using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ITERA.Interfaces.Repositories;
using ITERA.Models;

namespace ITERA.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private char separator = Path.DirectorySeparatorChar;
        string filePath;

        private string _data;

        public EmpresaRepository()
        {
            filePath = @$"Data{separator}companys.json";
            _data = File.ReadAllText(filePath);
        }

        public Empresa Adicionar(Empresa empresa)
        {
            var empresas = JsonSerializer.Deserialize<Empresa[]>(_data).ToList();
            empresas.Add(empresa);

            string jsonString = JsonSerializer.Serialize(empresas);
            File.WriteAllText(filePath, jsonString);

            return empresa;
        }


        public void Atualizar(Empresa empresa)
        {
            throw new System.NotImplementedException();
        }

        public Empresa ObterPorId(string id)
        {
            try
            {
                var empresas = JsonSerializer.Deserialize<Empresa[]>(_data);
                return empresas.Where(p => p.id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Empresa> ObterTodos()
        {
            throw new System.NotImplementedException();
        }

        public void Remover(Empresa empresa)
        {
            var empresas = JsonSerializer.Deserialize<Empresa[]>(_data).ToList();
            var index = empresas.FindIndex(p => p.id == empresa.id);
            empresas[index].status = "INATIVO";

            string jsonString = JsonSerializer.Serialize(empresas);
            File.WriteAllText(filePath, jsonString);
        }
    }
}