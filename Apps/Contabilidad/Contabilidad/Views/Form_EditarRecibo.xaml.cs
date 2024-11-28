using Contabilidad.Models;

namespace Contabilidad.Views;

public partial class Form_EditarRecibo : ContentPage
{
    private ReciboFijo? recibo;

    public Form_EditarRecibo(ReciboFijo? recibo = null)
    {
        InitializeComponent();
        this.recibo = recibo;

        if (recibo != null)
        {
            EntryDescripcion.Text = recibo.Descripcion;
            EntryCantidad.Text = recibo.Cantidad.ToString();
            EntryDia.Text = recibo.DiaDelMes.ToString();
            PickerFrecuencia.SelectedItem = recibo.Frecuencia;
        }
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        var db = Database.GetConnection();

        if (recibo == null)
        {
            recibo = new ReciboFijo();
            await db.InsertAsync(recibo);
        }

        recibo.Descripcion = EntryDescripcion.Text;
        recibo.Cantidad = double.Parse(EntryCantidad.Text);
        recibo.DiaDelMes = int.Parse(EntryDia.Text);
        recibo.Frecuencia = PickerFrecuencia.SelectedItem?.ToString() ?? "Mensual";

        await db.UpdateAsync(recibo);
        await DisplayAlert("Éxito", "Recibo guardado correctamente.", "OK");
        await Navigation.PopAsync();
    }

    private async void OnEliminarClicked(object sender, EventArgs e)
    {
        if (recibo != null)
        {
            var db = Database.GetConnection();
            await db.DeleteAsync(recibo);
            await DisplayAlert("Éxito", "Recibo eliminado correctamente.", "OK");
        }
        await Navigation.PopAsync();
    }
}
