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
        var recibos = await db.Table<ReciboFijo>().ToListAsync();
        RecibosList.ItemsSource = recibos;
    }

    private async void OnAddReciboClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Form_EditarRecibo());
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        var db = Database.GetConnection();

        // Guardar el saldo inicial como un registro de ingreso
        var saldoInicial = new Registro
        {
            Tipo = "Ingreso",
            Cantidad = double.Parse(EntrySaldo.Text),
            Descripcion = "Saldo Inicial",
            Fecha = DateTime.Now
        };

        await db.InsertAsync(saldoInicial);

        await DisplayAlert("Éxito", "Configuración inicial guardada.", "OK");

        // Navegar a la página principal
        Application.Current.MainPage = new NavigationPage(new MainPage());
    }
}
