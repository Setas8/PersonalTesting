using Contabilidad.Models;

namespace Contabilidad.Views;

public partial class Form_SaldoInicial : ContentPage
{
    public Form_SaldoInicial()
    {
        InitializeComponent();
        CargarRecibos();
    }

    private async void CargarRecibos()
    {
        var db = Database.GetConnection();
        if (RecibosList != null) // Verificar si RecibosList no es nulo
        {
            var recibos = await db.Table<ReciboFijo>().ToListAsync();
            RecibosList.ItemsSource = recibos;
        }
        else
        {
            Console.WriteLine("RecibosList no está inicializado.");
        }
    }

    private async void OnAddReciboClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Form_EditarRecibo());
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        var db = Database.GetConnection();

        if (!string.IsNullOrWhiteSpace(EntrySaldo?.Text) && double.TryParse(EntrySaldo.Text, out double saldo))
        {
            var saldoInicial = new Registro
            {
                Tipo = "Ingreso",
                Cantidad = saldo,
                Descripcion = "Saldo Inicial",
                Fecha = DateTime.Now
            };

            await db.InsertAsync(saldoInicial);
            await DisplayAlert("Éxito", "Configuración inicial guardada.", "OK");

            // Navegar a la página principal
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
        else
        {
            await DisplayAlert("Error", "Por favor, introduce un saldo inicial válido.", "OK");
        }
    }
}
