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
    public partial class ListCargadorForm : Form
    {
        private readonly ApiClient _apiClient;

        public ListCargadorForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            ConfigureGrid();
            LoadData();

            // Vincular evento
            this.btnActualizar.Click += BtnActualizar_Click;
        }

        private void ConfigureGrid()
        {
            dgvCargadores.AutoGenerateColumns = false;

            // Configurar columnas
            dgvCargadores.Columns.Add("Marca", "Marca");
            dgvCargadores.Columns.Add("Capacidad", "Capacidad");
            dgvCargadores.Columns.Add("Longitud", "Longitud (m)");
            dgvCargadores.Columns.Add("Garantia", "Garantía (meses)");
        }

        private async void LoadData()
        {
            try
            {
                var cargadores = await _apiClient.GetCargadoresAsync();
                dgvCargadores.DataSource = cargadores;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando datos: {ex.Message}");
            }
        }
        private void ListCargadorForm_Load(object sender, EventArgs e)
        {
            // Lógica de carga inicial (si es necesaria)
            LoadData();
        }
        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            LoadData();
        }


    }
}
