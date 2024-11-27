using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidad.Models
{
    public class Recibo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime FechaProxima { get; set; }
        public string Frecuencia { get; set; } // "Mensual", "Semanal", etc.
    }
}
