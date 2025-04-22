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

namespace TechTienda.Forms.CargadorView
{
    public partial class SearchCargadorForm : Form
    {
        private readonly ApiClient _apiClient;

        public SearchCargadorForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            ConfigureGrid();

            // Vincular evento
            this.btnBuscar.Click += BtnBuscar_Click;
        }

        private void ConfigureGrid()
        {
            dgvResultados.AutoGenerateColumns = false;
            dgvResultados.Columns.Add("Marca", "Marca");
            dgvResultados.Columns.Add("Capacidad", "Capacidad");
            dgvResultados.Columns.Add("Longitud", "Longitud (m)");
        }

        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var criterios = new Dictionary<string, object>
            {
                { cmbCriterio.SelectedItem.ToString(), txtValor.Text }
            };

                var resultados = await _apiClient.SearchCargadoresAsync(criterios);
                dgvResultados.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
