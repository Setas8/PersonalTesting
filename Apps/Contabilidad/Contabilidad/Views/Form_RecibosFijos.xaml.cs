using Contabilidad.Models;

namespace Contabilidad.Views;

public partial class Form_RecibosFijos : ContentPage
{
    public Form_RecibosFijos()
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
}
