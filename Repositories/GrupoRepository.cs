using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ITERA.Interfaces.Repositories;
using ITERA.Models;

namespace ITERA.Repositories
{
    public class GrupoRepository : IGrupoRepository
    {
        private char separator = Path.DirectorySeparatorChar;
        string filePath;

        private string _data;

        public GrupoRepository()
        {
            filePath = @$"Data{separator}group.json";
            _data = File.ReadAllText(filePath);
        }

        public Grupo Adicionar(Grupo grupo)
        {
            var grupos = JsonSerializer.Deserialize<Grupo[]>(_data).ToList();
            grupos.Add(grupo);

            string jsonString = JsonSerializer.Serialize(grupos);
            File.WriteAllText(filePath, jsonString);

            return grupo;
        }

        public void Atualizar(Grupo grupo, Empresa empresa)
        {
            var grupos = JsonSerializer.Deserialize<Grupo[]>(_data).ToList();
            var index = grupos.FindIndex(p => p.id == grupo.id);
            // grupos[index].companys.Add(empresa);

            string jsonString = JsonSerializer.Serialize(grupos);
            File.WriteAllText(filePath, jsonString);
        }

        public void Atualizar(Grupo grupo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Grupo> ObterPorData(DateTime date)
        {
            var grupos = JsonSerializer.Deserialize<Grupo[]>(_data);
            return grupos.Where(p => DateTime.Parse(p.date_ingestion).Date <= date);
        }

        public Grupo ObterPorId(int id)
        {
            try
            {
                var grupos = JsonSerializer.Deserialize<Grupo[]>(_data);
                return grupos.Where(p => p.id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Grupo> ObterTodos()
        {
            try
            {
                return JsonSerializer.Deserialize<IEnumerable<Grupo>>(_data).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Remover(Grupo grupo)
        {
            throw new System.NotImplementedException();
        }
    }
}