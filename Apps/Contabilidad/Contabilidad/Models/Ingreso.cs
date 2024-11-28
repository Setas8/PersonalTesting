using SQLite;

namespace Contabilidad.Models
{
    public class Ingreso
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Cantidad { get; set; }
        public string? Categoria { get; set; } 
        public DateTime Fecha { get; set; }
    }
}
