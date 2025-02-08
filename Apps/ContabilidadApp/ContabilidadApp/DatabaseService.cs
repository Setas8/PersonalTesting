using SQLite;
using System.IO;
using ContabilidadApp.Clases;

namespace ContabilidadApp
{
    public class DatabaseService
    {
        private readonly SQLiteConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Movimiento>();
            _database.CreateTable<ReciboFijo>();
            _database.CreateTable<Saldo>();
        }

        public void SaveMovimiento(Movimiento movimiento)
        {
            _database.Insert(movimiento);
        }

        public void SaveReciboFijo(ReciboFijo reciboFijo)
        {
            _database.Insert(reciboFijo);
        }

        public void SaveSaldo(Saldo saldo)
        {
            _database.Insert(saldo);
        }

        public decimal GetSaldo()
        {
            var saldo = _database.Table<Saldo>().FirstOrDefault();
            return saldo?.Cantidad ?? 0;
        }

        public void UpdateSaldo(decimal saldo)
        {
            var existingSaldo = _database.Table<Saldo>().FirstOrDefault();
            if (existingSaldo != null)
            {
                // Si ya existe un saldo, lo actualizamos
                existingSaldo.Cantidad = saldo;
                _database.Update(existingSaldo);
            }
            else
            {
                // Si no existe un saldo, lo creamos
                var newSaldo = new Saldo { Cantidad = saldo };
                _database.Insert(newSaldo);
            }
        }

        public List<Movimiento> GetMovimientos()
        {
            return _database.Table<Movimiento>().ToList();
        }

        public List<ReciboFijo> GetRecibosFijos()
        {
            return _database.Table<ReciboFijo>().ToList();
        }
    }
}
