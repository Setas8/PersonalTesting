using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace PropinasApp
{
    public partial class MainPage : ContentPage
    {
        private Dictionary<string, double> mapaPropinas = new Dictionary<string, double>();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnRepartirPropinasClicked(object sender, EventArgs e)
        {
            if (!double.TryParse(PropinaEntry.Text, out double propinaTotal) || propinaTotal <= 0)
            {
                await DisplayAlert("Error", "La cantidad de propinas debe ser un número mayor que 0.", "OK");
                return;
            }

            if (!int.TryParse(EmpleadosEntry.Text, out int numEmpleados) || numEmpleados <= 0)
            {
                await DisplayAlert("Error", "El número de empleados debe ser un número mayor que 0.", "OK");
                return;
            }

            double propinaPorEmpleado = Math.Floor(propinaTotal / numEmpleados * 100) / 100.0;
            double sobrante = propinaTotal - (propinaPorEmpleado * numEmpleados);

            for (int i = 0; i < numEmpleados; i++)
            {
                string nombre = await PromptForEmpleadoName(i + 1);
                if (!mapaPropinas.ContainsKey(nombre))
                {
                    mapaPropinas[nombre] = 0;
                }

                mapaPropinas[nombre] += propinaPorEmpleado;
            }
         
            ResultLabel.Text = $"Distribución de propinas:\n";
            foreach (var entry in mapaPropinas)
            {
                ResultLabel.Text += $"{entry.Key}: {entry.Value:F2} euros\n";
            }


            PropinaEntry.Text = string.Empty;
            EmpleadosEntry.Text = string.Empty;

        }

        private async Task<string> PromptForEmpleadoName(int empleadoNumero)
        {
            return await DisplayPromptAsync($"Empleado {empleadoNumero}", "Introduce el nombre del empleado");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Application.Current.RequestedTheme == AppTheme.Dark)
            {
                ResultLabel.TextColor = Colors.White;
                ResultLabel.BackgroundColor = Colors.Black;
            }
            else
            {
                ResultLabel.TextColor = Colors.Black;
                ResultLabel.BackgroundColor = Colors.White;
            }
        }
        
    }
}



