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

        // Propiedad calculada para obtener las horas trabajadas
        public double HoursWorked => (EndTime - StartTime).TotalHours;

        // Propiedad para mostrar un formato amigable de las horas trabajadas
        public string FormattedDetails => $"{StartTime:hh\\:mm} - {EndTime:hh\\:mm}, {HoursWorked:F2} horas";
    }
}


