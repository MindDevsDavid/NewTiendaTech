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

namespace TechTienda.Forms.Celular
{
    public partial class ListCelular : Form
    {

        private readonly ApiClient _apiClient;

        public ListCelular(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            ConfigureGrid();
            LoadData();

            // Vincular eventos
            this.btnActualizar.Click += BtnActualizar_Click;
            this.btnExportar.Click += BtnExportar_Click;
        }

        private void ConfigureGrid()
        {
            dgvCelulares.AutoGenerateColumns = false;

            // Configurar columnas manualmente
            dgvCelulares.Columns.Add("Nombre", "Nombre");
            dgvCelulares.Columns.Add("Marca", "Marca");
            dgvCelulares.Columns.Add("Precio", "Precio");
            dgvCelulares.Columns.Add("Stock", "Stock");
            dgvCelulares.Columns.Add("Almacenamiento", "Almacenamiento (GB)");
            dgvCelulares.Columns.Add("FechaLanzamiento", "Fecha Lanzamiento");
            dgvCelulares.Columns.Add("Cargador", "Cargador");

            // Formato de columnas
            dgvCelulares.Columns["Precio"].DefaultCellStyle.Format = "C2";
            dgvCelulares.Columns["FechaLanzamiento"].DefaultCellStyle.Format = "d";
        }

        private async void LoadData()
        {
            try
            {
                var celulares = await _apiClient.GetCelularesAsync();
                dgvCelulares.DataSource = celulares;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando datos: {ex.Message}");
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            // Implementar lógica de exportación a CSV
            MessageBox.Show("Función de exportación no implementada aún");
        }

        private void ListCelular_Load(object sender, EventArgs e)
        {

        }
    }
}
