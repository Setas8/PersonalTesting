using SQLite;

namespace ContabilidadApp.Clases
{
    public class Movimiento
    {
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public decimal Cantidad { get; set; }
        public TipoMovimiento Tipo { get; set; }
    }
}

