using SQLite;

namespace ContabilidadApp.Clases
{
    public class ReciboFijo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cantidad { get; set; }
        public string Concepto { get; set; }
    }
}

