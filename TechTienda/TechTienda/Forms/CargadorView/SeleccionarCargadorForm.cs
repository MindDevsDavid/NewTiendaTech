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

// TechTienda/Forms/Cargador/SeleccionarCargadorForm.cs
namespace TechTienda.Forms.CargadorView
{
    public partial class SeleccionarCargadorForm : Form
    {
        public Models.Cargador CargadorSeleccionado { get; private set; }
        private readonly ApiClient _apiClient;

        public SeleccionarCargadorForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            CargarCargadores();
            ConfigurarEventos();
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            dgvCargadores.AutoGenerateColumns = false;

            dgvCargadores.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Marca",
                HeaderText = "Marca",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvCargadores.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Capacidad",
                HeaderText = "Capacidad",
                Width = 120
            });

            dgvCargadores.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Longitud",
                HeaderText = "Longitud (m)",
                Width = 100
            });
        }

        private async void CargarCargadores()
        {
            try
            {
                var cargadores = await _apiClient.GetCargadoresAsync();
                dgvCargadores.DataSource = cargadores;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando cargadores: {ex.Message}");
            }
        }

        private void ConfigurarEventos()
        {
            btnSeleccionar.Click += BtnSeleccionar_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvCargadores.SelectedRows.Count > 0)
            {
                CargadorSeleccionado = (Models.Cargador)dgvCargadores.SelectedRows[0].DataBoundItem;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
