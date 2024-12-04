using SQLite;

namespace Contabilidad.Models
{
    public class Registro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Tipo { get; set; } // "Ingreso" o "Retiro"
        public double Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }
}
