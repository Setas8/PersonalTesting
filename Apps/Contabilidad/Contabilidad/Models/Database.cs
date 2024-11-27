using SQLite;
using System.IO;
using System.Threading.Tasks;

public static class Database
{
    private static SQLiteAsyncConnection db;

    public static async Task Initialize()
    {
        if (db != null)
            return;

        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Contabilidad.db");
        db = new SQLiteAsyncConnection(databasePath);

        // Crea las tablas necesarias
        await db.CreateTableAsync<Contabilidad.Models.Registro>();
        await db.CreateTableAsync<Contabilidad.Models.Recibo>();
    }

    public static SQLiteAsyncConnection GetConnection() => db;
}


public class ReciboFijo
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public decimal Cantidad { get; set; }
    public DateTime FechaProxima { get; set; }
    public string Frecuencia { get; set; } // "Mensual", "Semanal", etc.
}

