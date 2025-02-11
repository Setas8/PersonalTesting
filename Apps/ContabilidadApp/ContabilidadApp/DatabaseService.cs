using SQLite;
using ContabilidadApp.Clases;
using System.Collections.Generic;
using System.Linq;

namespace ContabilidadApp
{
    public class DatabaseService
    {
        private readonly SQLiteConnection _connection;

        public DatabaseService(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<Movimiento>();
            _connection.CreateTable<ReciboFijo>();
            _connection.CreateTable<Saldo>();
        }

        public List<Movimiento> GetMovimientos() => _connection.Table<Movimiento>().ToList();
        public List<ReciboFijo> GetRecibosFijos() => _connection.Table<ReciboFijo>().ToList();
        public decimal GetSaldo()
        {
            var saldo = _connection.Table<Saldo>().FirstOrDefault();
            return saldo != null ? saldo.Cantidad : 0;
        }

        public void SaveMovimiento(Movimiento movimiento)
        {
            _connection.Insert(movimiento);
        }

        public void SaveReciboFijo(ReciboFijo reciboFijo)
        {
            _connection.Insert(reciboFijo);
        }

        public void DeleteReciboFijo(ReciboFijo reciboFijo)
        {
            _connection.Delete(reciboFijo);
        }

        public void SaveSaldo(Saldo saldo)
        {
            _connection.Insert(saldo);
        }
    }
}
