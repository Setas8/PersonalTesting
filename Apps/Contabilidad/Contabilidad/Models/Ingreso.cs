using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidad.Models
{
    public class Ingreso
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public decimal Cantidad { get; set; }
        public string Categoria { get; set; }
        public DateTime Fecha { get; set; }
    }
}
