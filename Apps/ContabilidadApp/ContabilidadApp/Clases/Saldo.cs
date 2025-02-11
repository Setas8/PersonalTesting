using SQLite;

namespace ContabilidadApp.Clases
{
    public class Saldo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public decimal Cantidad { get; set; }
    }
}

