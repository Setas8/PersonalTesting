namespace Contabilidad;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
      
        InicializarBaseDeDatos();
    }

    private async void InicializarBaseDeDatos()
    {
        await Models.Database.Initialize(); // Inicializa la base de datos antes de continuar

        // Verificar si ya se configuró el saldo inicial
        var db = Models.Database.GetConnection();
        var saldoInicial = await db.Table<Models.Registro>().FirstOrDefaultAsync(r => r.Descripcion == "Saldo Inicial");

        if (saldoInicial == null)
        {
            MainPage = new NavigationPage(new Views.Form_SaldoInicial());
        }
        else
        {
            MainPage = new NavigationPage(new Views.MainPage());
        }
    }
}

