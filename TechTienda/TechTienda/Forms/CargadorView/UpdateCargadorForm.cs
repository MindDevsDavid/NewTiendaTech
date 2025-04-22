using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechTienda.Models;
using TechTienda.Services;

namespace TechTienda.Forms.CargadorView
{
    public partial class UpdateCargadorForm : Form
    {
        private readonly ApiClient _apiClient;
        private Cargador _cargador;

        public UpdateCargadorForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            ConfigureForm();
        }

        private void ConfigureForm()
        {
            // Configuración similar a AddCargadorForm
            numLongitud.DecimalPlaces = 2;
            numGarantia.Minimum = 0;
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                _cargador = await _apiClient.GetCargadorByIdAsync((int)numId.Value);
                if (_cargador != null)
                {
                    CargarDatos();
                    btnGuardar.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Cargador no encontrado");
            }
        }

        private void CargarDatos()
        {
            txtCapacidad.Text = _cargador.Capacidad;
            numLongitud.Value = _cargador.Longitud;
            txtMarca.Text = _cargador.Marca;
            numGarantia.Value = _cargador.Garantia;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            try
            {
                _cargador.Capacidad = txtCapacidad.Text;
                _cargador.Longitud = numLongitud.Value;
                _cargador.Marca = txtMarca.Text;
                _cargador.Garantia = (int)numGarantia.Value;

                await _apiClient.UpdateCargadorAsync(_cargador);
                MessageBox.Show("Cargador actualizado!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtCapacidad.Text))
            {
                MessageBox.Show("La capacidad es requerida");
                return false;
            }
            return true;
        }
    }

}
