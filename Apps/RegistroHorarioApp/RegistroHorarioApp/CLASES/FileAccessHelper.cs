using System;
using System.IO;

namespace RegistroHorarioApp.CLASES
{
    public static class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            // Obtiene la ruta local de la aplicación
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // Devuelve la ruta completa al archivo SQLite
            return Path.Combine(folderPath, filename);
        }
    }
}
