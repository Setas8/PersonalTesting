using SQLite;

namespace Contabilidad.Models
{
    public class Recibo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public double Cantidad { get; set; }
        public DateTime FechaProxima { get; set; }
    }
}
