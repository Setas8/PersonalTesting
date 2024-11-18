namespace Contabilidad.Views;

public partial class Form_Ingreso : ContentPage
{
	public Form_Ingreso()
	{
		InitializeComponent();
	}
    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        var registro = new Models.Registro
        {
            Tipo = "Ingreso",
            Cantidad = decimal.Parse(MontoEntry.Text),
            Fecha = FechaPicker.Date
        };

        var db = Database.GetConnection();
        await db.InsertAsync(registro);

        await DisplayAlert("Éxito", "Ingreso registrado", "OK");
        await Navigation.PopAsync();
    }
}