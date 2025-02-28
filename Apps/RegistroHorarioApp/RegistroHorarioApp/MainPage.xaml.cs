using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegistroHorarioApp.CLASES;
using RegistroHorarioApp.SERVICES;
using Microsoft.Maui.Controls;

namespace RegistroHorarioApp
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public MainPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService(FileAccessHelper.GetLocalFilePath("registros.db3"));
            LoadTodayHours();
            LoadWorkLogsForMonth(DateTime.Now.Year, DateTime.Now.Month);
        }

        private async void LoadTodayHours()
        {
            double totalHours = await _databaseService.GetTotalHoursWorkedTodayAsync();
            TotalHoursLabel.Text = $"{totalHours:F2} horas";
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today; // Obtener la fecha actual
            TimeSpan startTime = StartTimePicker.Time;
            TimeSpan endTime = EndTimePicker.Time;

            // Convertimos TimeSpan a DateTime combinándolo con la fecha actual
            DateTime startDateTime = today.Add(startTime);
            DateTime endDateTime = today.Add(endTime);

            if (startDateTime < endDateTime)
            {
                await _databaseService.SaveWorkLogAsync(new Registro
                {
                    Date = today,
                    StartTime = startTime,
                    EndTime = endTime
                });

                StartTimePicker.Time = new TimeSpan(0, 0, 0);
                EndTimePicker.Time = new TimeSpan(0, 0, 0);

                LoadTodayHours();
                LoadWorkLogsForMonth(today.Year, today.Month);
            }
            else
            {
                await DisplayAlert("Error", "La hora de inicio debe ser menor que la hora de finalización", "OK");
            }
        }


        private async void LoadWorkLogsForMonth(int year, int month)
        {
            List<Registro> logs = await _databaseService.GetWorkLogsByMonthAsync(year, month);
            WorkLogListView.ItemsSource = logs;
        }

        private void OnMonthSelected(object sender, DateChangedEventArgs e)
        {
            LoadWorkLogsForMonth(e.NewDate.Year, e.NewDate.Month);
        }

        private async void LoadWorkLogsForWeek(DateTime selectedDate)
        {
            DateTime startOfWeek = selectedDate.AddDays(-(int)selectedDate.DayOfWeek);
            List<Registro> logs = await _databaseService.GetWorkLogsByWeekAsync(startOfWeek);
            WorkLogListView.ItemsSource = logs;
        }

        private void OnWeekSelected(object sender, DateChangedEventArgs e)
        {
            LoadWorkLogsForWeek(e.NewDate);
        }
    }
}

