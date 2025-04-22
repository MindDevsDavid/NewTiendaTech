using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechTienda.Services;
using TechTienda.Models;
using System.Configuration;
using TechTienda.Forms.CargadorView; 

namespace TechTienda.Forms.Celular
{
    public partial class AddCelular : Form
    {
        private readonly ApiClient _apiClient;
        private Cargador _cargadorSeleccionado;

        public AddCelular(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _cargadorSeleccionado = null;
            ConfigureForm();
            // Vincular eventos
            this.btnSeleccionarCargador.Click += new System.EventHandler(this.btnSeleccionarCargador_Click);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
        }

        private void ConfigureForm()
        {
            // Configurar DateTimePicker
            dtpFechaLanzamiento.Format = DateTimePickerFormat.Short;
            dtpFechaLanzamiento.Value = DateTime.Today;

            // Configurar valores por defecto
            numPrecio.Minimum = 0;
            numStock.Minimum = 0;
            numAlmacenamiento.Minimum = 1;

            // Configurar evento para el botón de cargador
            btnSeleccionarCargador.Click += (s, e) => SeleccionarCargador();
        }

        private void SeleccionarCargador()
        {
            var selectorForm = new SeleccionarCargadorForm(_apiClient);
            if (selectorForm.ShowDialog() == DialogResult.OK)
            {
                _cargadorSeleccionado = selectorForm.CargadorSeleccionado;
                ActualizarInfoCargador();
            }
        }

        private void ActualizarInfoCargador()
        {
            lblInfoCargador.Text = _cargadorSeleccionado != null
                ? $"{_cargadorSeleccionado.Marca} ({_cargadorSeleccionado.Capacidad})"
                : "Cargador Genérico";
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio");
                return false;
            }

            if (numPrecio.Value <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a 0");
                return false;
            }

            if (numStock.Value < 0)
            {
                MessageBox.Show("El stock no puede ser negativo");
                return false;
            }

            return true;
        }

        private TechTienda.Models.Celular CrearCelularDesdeFormulario()
        {
            return new TechTienda.Models.Celular
            {
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                Precio = numPrecio.Value,
                Stock = (int)numStock.Value,
                Marca = txtMarca.Text.Trim(),
                Almacenamiento = (int)numAlmacenamiento.Value,
                FechaLanzamiento = dtpFechaLanzamiento.Value,
                Cargador = _cargadorSeleccionado ?? new Cargador() // Usa cargador por defecto si es null
            };
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            try
            {
                var nuevoCelular = CrearCelularDesdeFormulario();
                await _apiClient.CreateCelularAsync(nuevoCelular);

                MessageBox.Show("Celular registrado exitosamente!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}");
            }
        }

        private void AddCelular_Load(object sender, EventArgs e)
        {
            // Inicialización adicional si es necesaria
        }

        private void btnSeleccionarCargador_Click(object sender, EventArgs e)
        {
            // Lógica para seleccionar cargador
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddCelular_Load_1(object sender, EventArgs e)
        {

        }
    }
}
