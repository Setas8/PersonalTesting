using ContabilidadApp.Clases;
using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using System.Linq;

namespace ContabilidadApp.Formularios
{
    public partial class MainPage : ContentPage
    {
        // Propiedades de los datos
        private readonly DatabaseService _databaseService;

        public MainPage()
        {
            InitializeComponent();   
            _databaseService = new DatabaseService(App.DatabasePath);
            InitializeData();
            BindingContext = this;
        }

        public decimal SaldoActual { get; set; }
        public List<string> TipoItems { get; set; }
        public string TipoSeleccionado { get; set; }
        public string Concepto { get; set; }
        public DateTime FechaRecibo { get; set; }
        public decimal CantidadRecibo { get; set; }
        public string ConceptoRecibo { get; set; }
        public List<Movimiento> Movimientos { get; set; }
        public List<ReciboFijo> RecibosFijos { get; set; }

        // Inicializar datos de ejemplo
        private void InitializeData()
        {
            TipoItems = new List<string> { "Ingreso", "Gasto" };    
            Movimientos = _databaseService.GetMovimientos();
            RecibosFijos = _databaseService.GetRecibosFijos();
            SaldoActual = _databaseService.GetSaldo();
            lblSaldo.Text = $"Saldo Actual: {SaldoActual}";
        }

        // Método para registrar un movimiento
        private void OnRegistrarMovimientoClicked(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtCantidad.Text, out decimal cantidad))
            {
                var movimiento = new Movimiento
                {
                    Fecha = DateTime.Today,
                    Concepto = txtConcepto.Text,
                    Cantidad = cantidad,
                    Tipo = TipoSeleccionado == "Ingreso" ? TipoMovimiento.Ingreso : TipoMovimiento.Gasto
                };

                _databaseService.SaveMovimiento(movimiento);

                Movimientos.Add(movimiento);
                SaldoActual += movimiento.Tipo == TipoMovimiento.Ingreso ? movimiento.Cantidad : -movimiento.Cantidad;

                lblSaldo.Text = $"Saldo Actual: {SaldoActual}";
                lstMovimientos.ItemsSource = null;
                lstMovimientos.ItemsSource = Movimientos;

                // Limpiar los campos
                txtCantidad.Text = string.Empty;
                txtConcepto.Text = string.Empty;
                pickerTipo.SelectedItem = null;  // Restablecer selección del Picker
            }
            else
            {
                DisplayAlert("Error", "Cantidad no válida", "OK");
            }
        }

        // Método para registrar un recibo fijo
        private void OnRegistrarReciboFijoClicked(object sender, EventArgs e)
        {
            if (FechaRecibo != null && decimal.TryParse(txtCantidadRecibo.Text, out decimal cantidad))
            {
                var reciboFijo = new ReciboFijo
                {
                    Fecha = FechaRecibo,
                    Cantidad = cantidad,
                    Concepto = txtConceptoRecibo.Text
                };

                _databaseService.SaveReciboFijo(reciboFijo);

                RecibosFijos.Add(reciboFijo);
                lstRecibosFijos.ItemsSource = null;
                lstRecibosFijos.ItemsSource = RecibosFijos;

                // Limpiar los campos
                txtCantidadRecibo.Text = string.Empty;
                txtConceptoRecibo.Text = string.Empty;
                txtFechaRecibo.Date = DateTime.Today;  // Restablecer la fecha al día de hoy
            }
            else
            {
                DisplayAlert("Error", "Datos de recibo no válidos", "OK");
            }
        }

        // Método para eliminar un recibo fijo
        private void OnEliminarReciboFijoClicked(object sender, EventArgs e)
        {
            var swipeItem = (SwipeItem)sender;
            var reciboFijo = (ReciboFijo)swipeItem.BindingContext;
            _databaseService.DeleteReciboFijo(reciboFijo);

            RecibosFijos.Remove(reciboFijo);
            lstRecibosFijos.ItemsSource = null;
            lstRecibosFijos.ItemsSource = RecibosFijos;
        }

        // Establecer saldo inicial
        private async void OnEstablecerSaldoClicked(object sender, EventArgs e)
        {
            var saldoInicial = await DisplayPromptAsync("Saldo Inicial", "Ingrese el saldo inicial en euros", keyboard: Keyboard.Numeric);

            if (decimal.TryParse(saldoInicial, out decimal cantidad))
            {
                _databaseService.SaveSaldo(new Saldo { Cantidad = cantidad });
                SaldoActual = cantidad;
                lblSaldo.Text = $"Saldo Actual: {SaldoActual}";
            }
            else
            {
                DisplayAlert("Error", "Saldo no válido", "OK");
            }
        }
    }
}
