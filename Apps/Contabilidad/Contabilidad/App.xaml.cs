namespace Contabilidad;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Verificar si la configuración inicial ya se realizó
        CheckAndSetUpInitialConfiguration();
    }

    private async void CheckAndSetUpInitialConfiguration()
    {
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

