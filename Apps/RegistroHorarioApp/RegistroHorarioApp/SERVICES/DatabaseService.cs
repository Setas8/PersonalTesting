using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using RegistroHorarioApp.CLASES;

namespace RegistroHorarioApp.SERVICES
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Registro>().Wait();  // Crea la tabla si no existe
        }

        // Guardar un registro de trabajo
        public Task<int> SaveWorkLogAsync(Registro registro)
        {
            return _database.InsertAsync(registro);
        }

        // Obtener todos los registros
        public Task<List<Registro>> GetWorkLogsAsync()
        {
            return _database.Table<Registro>().ToListAsync();
        }

        // Obtener registros de un mes específico
        public Task<List<Registro>> GetWorkLogsByMonthAsync(int year, int month)
        {
            return _database.Table<Registro>()
                .Where(w => w.Date.Year == year && w.Date.Month == month)
                .ToListAsync();
        }

        // Obtener registros por semana
        public Task<List<Registro>> GetWorkLogsByWeekAsync(DateTime startOfWeek)
        {
            DateTime endOfWeek = startOfWeek.AddDays(6);
            return _database.Table<Registro>()
                .Where(w => w.Date >= startOfWeek && w.Date <= endOfWeek)
                .ToListAsync();
        }
    }
}
