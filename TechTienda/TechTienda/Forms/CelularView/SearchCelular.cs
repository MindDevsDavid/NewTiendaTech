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
    public partial class SearchCelular : Form
    {
        private readonly ApiClient _apiClient;

        public SearchCelular(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            ConfigureSearchCriteria();
        }

        private void ConfigureSearchCriteria()
        {
            cmbCriterio.Items.AddRange(new[] {
            "Nombre",
            "Marca",
            "Rango de Precios",
            "Fecha Lanzamiento"
        });

            cmbCriterio.SelectedIndexChanged += CmbCriterio_SelectedIndexChanged;
        }

        private void CmbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            var criterio = cmbCriterio.SelectedItem.ToString();

            panelRango.Visible = (criterio == "Rango de Precios");
            txtValor.Visible = !panelRango.Visible;
        }

        private void cmbCriterio_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var criterios = BuildSearchCriteria();
                var resultados = await _apiClient.SearchCelularesAsync(criterios);
                dgvResultados.DataSource = resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private Dictionary<string, object> BuildSearchCriteria()
        {
            var criterios = new Dictionary<string, object>();
            string criterio = cmbCriterio.SelectedItem.ToString();

            switch (criterio)
            {
                case "Nombre":
                    criterios.Add("nombre", txtValor.Text);
                    break;
                case "Marca":
                    criterios.Add("marca", txtValor.Text);
                    break;
                case "Rango de Precios":
                    criterios.Add("precioMin", numPrecioMin.Value);
                    criterios.Add("precioMax", numPrecioMax.Value);
                    break;
            }
            return criterios;
        }
    }
}
