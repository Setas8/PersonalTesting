using System;
using Microsoft.Maui.Controls;
using RegistroHorarioApp.CLASES;
using RegistroHorarioApp.SERVICES;

namespace RegistroHorarioApp
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public MainPage()
        {
            InitializeComponent();

            // Obtiene la ruta del archivo SQLite
            var dbPath = FileAccessHelper.GetLocalFilePath("worklogs.db3");
            _databaseService = new DatabaseService(dbPath);

            // Cargar los registros al inicio
            LoadWorkLogs();
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            // Verifica si las horas de inicio y fin son válidas
            if (startTimePicker.Time >= endTimePicker.Time)
            {
                await DisplayAlert("Error", "La hora de inicio no puede ser después de la hora de fin.", "OK");
                return;
            }

            // Crea un nuevo registro
            var registro = new Registro
            {
                Date = datePicker.Date,
                StartTime = startTimePicker.Time,
                EndTime = endTimePicker.Time
            };

            // Guarda el registro en la base de datos
            await _databaseService.SaveWorkLogAsync(registro);

            // Recarga los registros
            LoadWorkLogs();
        }

        private async void LoadWorkLogs()
        {
            // Obtiene los registros desde la base de datos
            var workLogs = await _databaseService.GetWorkLogsAsync();
            workLogListView.ItemsSource = workLogs;  // Muestra los registros en el ListView
        }
    }
}

