using System;
using Microsoft.Maui.Controls;
using ContabilidadApp.Clases;
using System.Globalization;

namespace ContabilidadApp.Clases
{
    public class TipoMovimientoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString() == "Ingreso" ? "Ingreso" : "Gasto";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString() == "Ingreso" ? "Ingreso" : "Gasto";
        }
    }
}
