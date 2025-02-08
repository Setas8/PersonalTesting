using ContabilidadApp.Clases;
using System;
using Microsoft.Maui.Controls;
using System.IO;
using System.Collections.Generic;

namespace ContabilidadApp.Formularios
{
    public partial class MainPage : ContentPage
    {
        private DatabaseService _databaseService;
        private decimal _saldo;

        // Propiedades para mantener los movimientos y la lista de tipos
        public List<Movimiento> Movimientos { get; set; }
        public List<string> TipoItems { get; set; }  // Lista de tipos de movimiento (Ingreso, Gasto)
        public string TipoSeleccionado { get; set; }  // Propiedad para el tipo seleccionado

        public MainPage()
        {
            InitializeComponent();
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "contabilidad.db");
            _databaseService = new DatabaseService(dbPath);
            LoadSaldo();
            Movimientos = new List<Movimiento>();

            // Inicialización de TipoItems
            TipoItems = new List<string> { "Ingreso", "Gasto" };  // Opciones para el Picker
            BindingContext = this;  // Establecer el contexto de enlace
        }

        private void LoadSaldo()
        {
            _saldo = _databaseService.GetSaldo();
            lblSaldo.Text = $"{_saldo:C}";
            if (_saldo == 0)
            {
                btnEstablecerSaldo.IsVisible = true;  // Solo se muestra si el saldo es 0
            }
            else
            {
                btnEstablecerSaldo.IsVisible = false;
            }
        }

        private void OnEstablecerSaldoClicked(object sender, EventArgs e)
        {
            // Solicitar al usuario el saldo inicial y guardarlo
            decimal saldoInicial = 1000m;  // Usar una entrada del usuario aquí
            _databaseService.SaveSaldo(new Saldo { Cantidad = saldoInicial });
            _saldo = saldoInicial;
            lblSaldo.Text = $"{_saldo:C}";
            btnEstablecerSaldo.IsVisible = false;
        }

        private void OnRegistrarMovimientoClicked(object sender, EventArgs e)
        {
            // Verificamos si el campo de cantidad tiene un valor
            if (string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtConcepto.Text))
            {
                DisplayAlert("Error", "Por favor, ingrese una cantidad y un concepto válidos.", "Aceptar");
                return;
            }

            decimal cantidad = decimal.Parse(txtCantidad.Text);

            // Convertimos el tipo seleccionado en el Picker a un enum
            if (pickerTipo.SelectedItem == null)
            {
                DisplayAlert("Error", "Por favor, seleccione un tipo de movimiento.", "Aceptar");
                return;
            }

            TipoMovimiento tipo = (TipoMovimiento)Enum.Parse(typeof(TipoMovimiento), pickerTipo.SelectedItem.ToString());
            string concepto = txtConcepto.Text;

            var movimiento = new Movimiento
            {
                Fecha = DateTime.Now,
                Cantidad = cantidad,
                Tipo = tipo,  // Usamos el enum en lugar de string
                Concepto = concepto
            };

            // Guardamos el movimiento en la base de datos
            _databaseService.SaveMovimiento(movimiento);

            // Actualizamos el saldo según el tipo de movimiento
            _saldo = tipo == TipoMovimiento.Ingreso ? _saldo + cantidad : _saldo - cantidad;
            lblSaldo.Text = $"{_saldo:C}";

            // Guardamos el nuevo saldo en la base de datos
            _databaseService.UpdateSaldo(_saldo);

            // Limpiar los campos después de guardar
            txtCantidad.Text = string.Empty;
            txtConcepto.Text = string.Empty;
            pickerTipo.SelectedItem = null;

            // Recargar lista de movimientos
            LoadSaldo();
        }

        private void OnRegistrarReciboFijoClicked(object sender, EventArgs e)
        {
            // Verificamos que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtCantidadRecibo.Text) || string.IsNullOrWhiteSpace(txtConceptoRecibo.Text) || string.IsNullOrWhiteSpace(txtFechaRecibo.Text))
            {
                DisplayAlert("Error", "Por favor, ingrese todos los campos del recibo fijo.", "Aceptar");
                return;
            }

            decimal cantidad = decimal.Parse(txtCantidadRecibo.Text);
            string concepto = txtConceptoRecibo.Text;
            DateTime fecha = DateTime.Parse(txtFechaRecibo.Text);

            var reciboFijo = new ReciboFijo
            {
                Fecha = fecha,
                Cantidad = cantidad,
                Concepto = concepto
            };

            // Guardamos el recibo fijo en la base de datos
            _databaseService.SaveReciboFijo(reciboFijo);

            // Actualizamos el saldo con el recibo fijo (esto puede ser un ingreso o gasto, según corresponda)
            _saldo += cantidad; // Suposición: Los recibos fijos son ingresos
            lblSaldo.Text = $"{_saldo:C}";

            // Guardamos el nuevo saldo en la base de datos
            _databaseService.UpdateSaldo(_saldo);

            // Limpiar los campos después de guardar
            txtCantidadRecibo.Text = string.Empty;
            txtConceptoRecibo.Text = string.Empty;
            txtFechaRecibo.Text = string.Empty;

            // Recargar saldo
            LoadSaldo();
        }
    }
}
