using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegistroHorarioApp.CLASES;
using SQLite;

namespace RegistroHorarioApp.SERVICES
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Registro>().Wait();
        }

        public Task<int> SaveWorkLogAsync(Registro registro)
        {
            return _database.InsertAsync(registro);
        }

        public Task<List<Registro>> GetWorkLogsAsync()
        {
            return _database.Table<Registro>().ToListAsync();
        }

        public Task<List<Registro>> GetWorkLogsByMonthAsync(int year, int month)
        {
            return _database.Table<Registro>()
                .Where(w => w.Date.Year == year && w.Date.Month == month)
                .ToListAsync();
        }

        public Task<List<Registro>> GetWorkLogsByWeekAsync(DateTime startOfWeek)
        {
            DateTime endOfWeek = startOfWeek.AddDays(6);
            return _database.Table<Registro>()
                .Where(w => w.Date >= startOfWeek && w.Date <= endOfWeek)
                .ToListAsync();
        }

        public async Task<double> GetTotalHoursWorkedTodayAsync()
        {
            DateTime today = DateTime.Today;
            var logs = await _database.Table<Registro>()
                .Where(w => w.Date == today)
                .ToListAsync();

            double totalHours = 0;
            foreach (var log in logs)
            {
                totalHours += log.HoursWorked;
            }
            return totalHours;
        }
    }
}

