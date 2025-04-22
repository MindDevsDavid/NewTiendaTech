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
    public partial class AddCargadorForm : Form
    {
        private readonly ApiClient _apiClient;

        public AddCargadorForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            ConfigureControls();

            // Vincular eventos
            this.btnGuardar.Click += BtnGuardar_Click;
            this.btnCancelar.Click += BtnCancelar_Click;
        }

        private void ConfigureControls()
        {
            numLongitud.DecimalPlaces = 2;
            numGarantia.Minimum = 0;
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var nuevoCargador = new Cargador
            {
                Capacidad = txtCapacidad.Text,
                Longitud = numLongitud.Value,
                Marca = txtMarca.Text,
                Garantia = (int)numGarantia.Value
            };

            try
            {
                await _apiClient.CreateCargadorAsync(nuevoCargador);
                MessageBox.Show("Cargador creado exitosamente!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtCapacidad.Text))
            {
                MessageBox.Show("La capacidad es requerida");
                return false;
            }
            return true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
