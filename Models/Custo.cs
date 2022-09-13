using System;

namespace ITERA.Models
{
    public class Custo
    {
        public int ano { get; set; }
        public string id_type { get; set; }
        public DateTime last_update { get; set; }
        public float valor { get; set; }
        public Empresa empresa { get; set; }
    }
}