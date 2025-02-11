using Microsoft.Maui.Controls;
using ContabilidadApp.Clases;
using System.IO;

namespace ContabilidadApp
{
    public partial class App : Application
    {
        public static string DatabasePath { get; private set; }

        public App()
        {
            InitializeComponent();

            // Definir la ruta de la base de datos
            DatabasePath = Path.Combine(FileSystem.AppDataDirectory, "contabilidad.db3");

            MainPage = new Formularios.MainPage();
        }
    }
}

