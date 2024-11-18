using Contabilidad.Models;

namespace Contabilidad.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            CargarResumenDiario();
        }

        private async void CargarResumenDiario()
        {
            var db = Database.GetConnection();
            var hoy = DateTime.Today;

            var ingresos = (await db.Table<Registro>()
                             .Where(r => r.Fecha == hoy && r.Tipo == "Ingreso")
                             .ToListAsync())
                    .Sum(r => r.Cantidad);

            var gastos = (await db.Table<Registro>()
                                  .Where(r => r.Fecha == hoy && r.Tipo == "Retiro")
                                  .ToListAsync())
                        .Sum(r => r.Cantidad);

            LabelIngresos.Text = $"€ {ingresos:N2}";
            LabelGastos.Text = $"€ {gastos:N2}";
        }

        private async void OnRegistrarIngreso(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Contabilidad.Views.Form_Ingreso());
        }

        private async void OnRegistrarRetiro(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Contabilidad.Views.Form_Retirada());
        }

        private async void OnVerCalendario(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Contabilidad.Views.Form_Calendario());
        }
    }
}
