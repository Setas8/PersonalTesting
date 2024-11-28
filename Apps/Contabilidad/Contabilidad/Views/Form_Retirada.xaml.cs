using Contabilidad.Models;

namespace Contabilidad.Views;

public partial class Form_Retirada : ContentPage
{
    public Form_Retirada()
    {
        InitializeComponent();
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        var db = Database.GetConnection();
        var gasto = new Registro
        {
            Tipo = "Gasto",
            Cantidad = double.Parse(EntryCantidad.Text),
            Descripcion = EntryCategoria.Text,
            Fecha = DateTime.Now
        };

        await db.InsertAsync(gasto);
        await DisplayAlert("Éxito", "Gasto registrado correctamente", "OK");
        await Navigation.PopAsync();
    }
}
