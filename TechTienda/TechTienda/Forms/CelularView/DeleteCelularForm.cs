using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using TechTienda.Models;
using TechTienda.Services;

namespace TechTienda.Forms.CelularView
{
    public partial class DeleteCelularForm : Form
    {
        private readonly ApiClient _apiClient;
        private TechTienda.Models.Celular _celular;

        public DeleteCelularForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;

            // Vincular eventos
            this.btnBuscar.Click += BtnBuscar_Click;
            this.btnEliminar.Click += BtnEliminar_Click;
            this.btnCancelar.Click += BtnCancelar_Click;
        }

        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                _celular = await _apiClient.GetCelularByIdAsync((int)numId.Value);
                if (_celular != null)
                {
                    MostrarDatos();
                    btnEliminar.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Celular no encontrado");
                LimpiarCampos();
            }
        }

        private void MostrarDatos()
        {
            txtNombre.Text = _celular.Nombre;
            txtMarca.Text = _celular.Marca;
            numPrecio.Value = _celular.Precio;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtMarca.Text = string.Empty;
            numPrecio.Value = 0;
            btnEliminar.Enabled = false;
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de eliminar este celular?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    await _apiClient.DeleteCelularAsync(_celular.Id);
                    MessageBox.Show("Celular eliminado correctamente");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteCelularForm_Load(object sender, EventArgs e)
        {

        }
    }
}
