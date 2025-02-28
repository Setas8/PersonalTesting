using System;
using SQLite;

namespace RegistroHorarioApp.CLASES
{
    public class Registro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        // Guardamos TimeSpan como string en formato HH:mm
        public string StartTimeString { get; set; }
        public string EndTimeString { get; set; }

        [Ignore] // No se almacena en SQLite
        public TimeSpan StartTime
        {
            get => TimeSpan.Parse(StartTimeString);
            set => StartTimeString = value.ToString(@"hh\:mm");
        }

        [Ignore] // No se almacena en SQLite
        public TimeSpan EndTime
        {
            get => TimeSpan.Parse(EndTimeString);
            set => EndTimeString = value.ToString(@"hh\:mm");
        }

        [Ignore] // No se almacena en SQLite
        public double HoursWorked => (EndTime - StartTime).TotalHours;

        [Ignore] // No se almacena en SQLite
        public string FormattedDetails => $"{StartTime:hh\\:mm} - {EndTime:hh\\:mm}, {HoursWorked:F2} horas";
    }
}

