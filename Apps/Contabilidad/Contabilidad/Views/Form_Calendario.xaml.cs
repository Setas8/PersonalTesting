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

        // A�ade l�gica para marcar fechas con movimientos (opcional)
        foreach (var registro in registros)
        {
            // Aqu� podr�as marcar fechas con un color especial en el calendario si lo soporta
        }
    }

    private async void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        var fechaSeleccionada = e.NewDate;

        var db = Database.GetConnection();
        var registros = await db.Table<Models.Registro>()
                                .Where(r => r.Fecha == fechaSeleccionada)
                                .ToListAsync();

        // Mostrar registros en un nuevo popup o p�gina
        await DisplayAlert("Movimientos", string.Join("\n", registros.Select(r => $"{r.Tipo}: �{r.Monto}")), "OK");
    }

    private async void OnRegistrarMovimiento(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Form_Ingreso());
    }
}