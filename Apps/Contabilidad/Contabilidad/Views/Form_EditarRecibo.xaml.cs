namespace Contabilidad.Views;

public partial class Form_EditarRecibo : ContentPage
{
    private ReciboFijo recibo;
    public Form_EditarRecibo(ReciboFijo recibo)
	{
		InitializeComponent();
        this.recibo = recibo;

        if (recibo != null)
        {
            DescripcionEntry.Text = recibo.Descripcion;
            MontoEntry.Text = recibo.Cantidad.ToString();
            FechaProximaPicker.Date = recibo.FechaProxima;
            FrecuenciaPicker.SelectedItem = recibo.Frecuencia;
        }
        async void OnGuardarClicked(object sender, EventArgs e)
        {
            if (recibo == null)
            {
                recibo = new ReciboFijo();
            }

            recibo.Descripcion = DescripcionEntry.Text;
            recibo.Cantidad = decimal.Parse(MontoEntry.Text);
            recibo.FechaProxima = FechaProximaPicker.Date;
            recibo.Frecuencia = FrecuenciaPicker.SelectedItem.ToString();

            var db = Database.GetConnection();
            if (recibo.Id == 0)
            {
                await db.InsertAsync(recibo);
            }
            else
            {
                await db.UpdateAsync(recibo);
            }

            await DisplayAlert("Éxito", "Recibo guardado", "OK");
            await Navigation.PopAsync();
        }

        async void OnEliminarClicked(object sender, EventArgs e)
        {
            if (recibo != null)
            {
                var db = Database.GetConnection();
                await db.DeleteAsync(recibo);
                await DisplayAlert("Éxito", "Recibo eliminado", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}