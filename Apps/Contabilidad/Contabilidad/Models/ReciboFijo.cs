using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidad.Models
{
    public class ReciboFijo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public double Cantidad { get; set; }
        public int DiaDelMes { get; set; }
        public string Frecuencia { get; set; } = "Mensual";
    }
}
