using SQLite;

namespace Contabilidad.Models;

public static class Database
{
    // Declaramos db como nullable
    private static SQLiteAsyncConnection? db;

    public static async Task Initialize()
    {
        if (db == null)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Contabilidad.db");
            db = new SQLiteAsyncConnection(dbPath);
            await db.CreateTableAsync<Registro>();
            await db.CreateTableAsync<Recibo>();
            await db.CreateTableAsync<ReciboFijo>();
        }
    }

    public static SQLiteAsyncConnection GetConnection()
    {
        // Comprobamos si db es null y lanzamos una excepción en caso de que no se haya inicializado
        if (db == null)
        {
            throw new InvalidOperationException("La base de datos no ha sido inicializada.");
        }

        return db;
    }
}