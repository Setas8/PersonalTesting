using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contabilidad.Models
{
    using Microsoft.Data.Sqlite;
    using SQLite;

    public class Database
    {
        private SQLiteConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Ingreso>();
            _database.CreateTable<Gasto>();
            _database.CreateTable<Recibo>();
        }

        // Métodos para manejar Ingresos, Gastos y Recibos Fijos
        public List<Ingreso> GetIngresos() => _database.Table<Ingreso>().ToList();
        public void SaveIngreso(Ingreso ingreso) => _database.Insert(ingreso);

        public List<Gasto> GetGastos() => _database.Table<Gasto>().ToList();
        public void SaveGasto(Gasto gasto) => _database.Insert(gasto);

        public List<Recibo> GetRecibos() => _database.Table<Recibo>().ToList();
        public void SaveRecibo(Recibo recibo) => _database.Insert(recibo);
    }
}
