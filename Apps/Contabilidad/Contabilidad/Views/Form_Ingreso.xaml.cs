using Contabilidad.Models;

namespace Contabilidad.Views;

public partial class Form_Ingreso : ContentPage
{
    public Form_Ingreso()
    {
        InitializeComponent();
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        var db = Database.GetConnection();
        var ingreso = new Registro
        {
            Tipo = "Ingreso",
            Cantidad = double.Parse(EntryCantidad.Text),
            Descripcion = EntryCategoria.Text,
            Fecha = DateTime.Now
        };

        await db.InsertAsync(ingreso);
        await DisplayAlert("Éxito", "Ingreso registrado correctamente", "OK");
        await Navigation.PopAsync();
    }
}