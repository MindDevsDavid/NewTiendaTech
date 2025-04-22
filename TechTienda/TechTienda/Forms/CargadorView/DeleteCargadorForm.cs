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
    public partial class DeleteCargadorForm : Form
    {
        private readonly ApiClient _apiClient;

        public DeleteCargadorForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var cargador = await _apiClient.GetCargadorByIdAsync((int)numId.Value);
                if (cargador != null)
                {
                    MostrarDatos(cargador);
                    btnEliminar.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Cargador no encontrado");
            }
        }

        private void MostrarDatos(Cargador cargador)
        {
            txtCapacidad.Text = cargador.Capacidad;
            txtMarca.Text = cargador.Marca;
            numLongitud.Value = cargador.Longitud;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Eliminar este cargador?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    await _apiClient.DeleteCargadorAsync((int)numId.Value);
                    MessageBox.Show("Cargador eliminado");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario
        }
    }
}
