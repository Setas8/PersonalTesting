using Contabilidad.Models;
using SQLite;

namespace Contabilidad.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        CargarDatos();
    }

    private async void CargarDatos()
    {
        var db = Database.GetConnection();

        // Obtener todos los registros de tipo "Ingreso" y "Retiro"
        var ingresos = await db.Table<Registro>().Where(r => r.Tipo == "Ingreso").ToListAsync();
        var gastos = await db.Table<Registro>().Where(r => r.Tipo == "Retiro").ToListAsync();

        // Calcular la suma manualmente
        var saldo = ingresos.Sum(r => r.Cantidad) - gastos.Sum(r => r.Cantidad);
        LabelSaldo.Text = $"€ {saldo:N2}";

        // Cargar los recibos fijos
        var recibos = await db.Table<ReciboFijo>().ToListAsync();
        RecibosList.ItemsSource = recibos;
    }

    private async void OnRegistrarIngreso(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Form_Ingreso());
    }

    private async void OnRegistrarRetirada(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Form_Retirada());
    }

    private async void OnGestionarRecibos(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Form_RecibosFijos());
    }
}
