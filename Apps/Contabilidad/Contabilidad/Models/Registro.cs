using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidad.Models
{
    public class Registro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Tipo { get; set; } // "Ingreso" o "Retiro"
        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; }
    }
}
