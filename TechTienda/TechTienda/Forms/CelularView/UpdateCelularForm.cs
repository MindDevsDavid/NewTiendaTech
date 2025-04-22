using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTienda.Models;
using TechTienda.Services;
namespace TechTienda.Forms.CelularView
{
    public partial class UpdateCelularForm : Form
    {
        private readonly ApiClient _apiClient;
        private TechTienda.Models.Celular _celular;

        public UpdateCelularForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
            ConfigureForm();
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
        }

        private void ConfigureForm()
        {
            dtpFechaLanzamiento.Format = DateTimePickerFormat.Short;
            numPrecio.DecimalPlaces = 2;
            numAlmacenamiento.Minimum = 1;
            numStock.Minimum = 0;

            btnGuardar.Enabled = false;
            LoadCargadores();
        }

        private async void LoadCargadores()
        {
            try
            {
                var cargadores = await _apiClient.GetCargadoresAsync();
                cmbCargador.DataSource = cargadores;
                cmbCargador.DisplayMember = "Marca";
                cmbCargador.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando cargadores: {ex.Message}");
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                _celular = await _apiClient.GetCelularByIdAsync((int)numId.Value);
                if (_celular != null)
                {
                    LoadCelularData();
                    btnGuardar.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Celular no encontrado");
            }
        }

        private void LoadCelularData()
        {
            txtNombre.Text = _celular.Nombre;
            txtDescripcion.Text = _celular.Descripcion;
            numPrecio.Value = _celular.Precio;
            numStock.Value = _celular.Stock;
            txtMarca.Text = _celular.Marca;
            numAlmacenamiento.Value = _celular.Almacenamiento;
            dtpFechaLanzamiento.Value = _celular.FechaLanzamiento;
            cmbCargador.SelectedValue = _celular.Cargador?.Id ?? -1;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                UpdateCelularFromForm();
                await _apiClient.UpdateCelularAsync(_celular);
                MessageBox.Show("Celular actualizado exitosamente!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void UpdateCelularFromForm()
        {
            _celular.Nombre = txtNombre.Text;
            _celular.Descripcion = txtDescripcion.Text;
            _celular.Precio = numPrecio.Value;
            _celular.Stock = (int)numStock.Value;
            _celular.Marca = txtMarca.Text;
            _celular.Almacenamiento = (int)numAlmacenamiento.Value;
            _celular.FechaLanzamiento = dtpFechaLanzamiento.Value;
            _celular.Cargador = (Cargador)cmbCargador.SelectedItem;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es requerido");
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateCelularForm_Load(object sender, EventArgs e)
        {

        }
    }
}