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

        private void OnRepartirPropinasClicked(object sender, EventArgs e)
        {
            double propinaTotal = double.Parse(PropinaEntry.Text);
            int numEmpleados = int.Parse(EmpleadosEntry.Text);

            if (propinaTotal <= 0 || numEmpleados <= 0)
            {
                DisplayAlert("Error", "La cantidad de propinas y el número de empleados deben ser mayores que 0.", "OK");
                return;
            }

            double propinaPorEmpleado = Math.Floor(propinaTotal / numEmpleados * 100) / 100.0;
            double resto = propinaTotal - (propinaPorEmpleado * numEmpleados);

            for (int i = 0; i < numEmpleados; i++)
            {
                string nombre = PromptForEmpleadoName(i + 1);
                if (!mapaPropinas.ContainsKey(nombre))
                {
                    mapaPropinas[nombre] = 0;
                }

                mapaPropinas[nombre] += propinaPorEmpleado;
            }

            foreach (var key in new List<string>(mapaPropinas.Keys))
            {
                if (resto <= 0) break;
                mapaPropinas[key] += 0.01;
                resto -= 0.01;
            }

            ResultLabel.Text = "Distribución de propinas:";
            foreach (var entry in mapaPropinas)
            {
                ResultLabel.Text += $"\n{entry.Key}: {entry.Value:F2} euros";
            }
        }

        private string PromptForEmpleadoName(int empleadoNumero)
        {      
            return PromptAsync($"Empleado {empleadoNumero}", "Introduce el nombre del empleado");
        }

        private async Task<string> PromptAsync(string title, string message)
        {
            var promptResult = await DisplayPromptAsync(title, message);
            return promptResult;
        }
    }
}
