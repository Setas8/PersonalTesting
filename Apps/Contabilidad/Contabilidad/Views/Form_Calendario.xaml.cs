using Syncfusion.Maui.Calendar;

namespace Contabilidad.Views;

public partial class Form_Calendario : ContentPage
{
    public Form_Calendario()
    {
        InitializeComponent();
        CargarMovimientos();
    }

    private async void CargarMovimientos()
    {
        var db = Database.GetConnection();
        var registros = await db.Table<Models.Registro>().ToListAsync();

        // Opcional: lógica para destacar fechas con movimientos.
        foreach (var registro in registros)
        {
            // Aquí podrías personalizar marcadores en el calendario.
        }
    }

    private async void OnDateSelected(object sender, CalendarSelectionChangedEventArgs e)
    {
        // Convertir e.NewValue a DateTime
        if (e.NewValue is DateTime fechaSeleccionada)
        {
            var db = Database.GetConnection();
            var registros = await db.Table<Models.Registro>()
                                    .Where(r => r.Fecha == fechaSeleccionada)
                                    .ToListAsync();

            // Mostrar movimientos en un cuadro de diálogo.
            if (registros.Any())
            {
                var detalles = string.Join("\n", registros.Select(r => $"{r.Tipo}: €{r.Cantidad}"));
                await DisplayAlert("Movimientos", detalles, "OK");
            }
            else
            {
                await DisplayAlert("Movimientos", "No hay movimientos en esta fecha.", "OK");
            }
        }
        else
        {
            await DisplayAlert("Error", "No se pudo determinar la fecha seleccionada.", "OK");
        }
    }

    private async void OnRegistrarMovimiento(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Form_Ingreso());
    }
}