using System;
using SQLite;

namespace RegistroHorarioApp.CLASES
{
    public class Registro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public double HoursWorked => (EndTime - StartTime).TotalHours;
        public string FormattedDetails => $"{StartTime:hh\\:mm} - {EndTime:hh\\:mm}, {HoursWorked:F2} horas";
    }
}
