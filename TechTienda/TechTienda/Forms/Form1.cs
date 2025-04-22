using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechTienda.Forms.Celular;
using TechTienda.Models;
using TechTienda.Services;
using TechTienda.Forms.CargadorView;
using System.Configuration;
using TechTienda.Forms;
using TechTienda.Forms.CelularView;




namespace TechTienda
{
    public partial class Form1 : Form
    {
        private readonly ApiClient _apiClient = new ApiClient();

        public Form1()
        {
            InitializeComponent();
        }

        // Manejadores de eventos para Celular
        private void NuevoCelularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TechTienda.Forms.Celular.AddCelular(_apiClient);
            form.ShowDialog();
        }

        private void BuscarCelularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TechTienda.Forms.Celular.SearchCelular(_apiClient);
            form.Show();
        }

        //private void ListarCelularesToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    var form = new TechTienda.Forms.Celular.ListCelular(_apiClient);
        //    form.Show();
        //}

        //private void EliminarCelularToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    var form = new TechTienda.Forms.CelularView.DeleteCelularForm(_apiClient);
        //    form.ShowDialog();
        //}

        //private void ActualizarCelularToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    var form = new TechTienda.Forms.Celular.UpdateCelularForm(_apiClient);
        //    form.ShowDialog();
        //}


        // Manejadores de eventos para Cargador
        private void NuevoCargadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TechTienda.Forms.CargadorView.AddCargadorForm(_apiClient);
            form.ShowDialog();
        }

        private void BuscarCargadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TechTienda.Forms.CargadorView.SearchCargadorForm(_apiClient);
            form.Show();
        }

        private void ListarCargadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TechTienda.Forms.CargadorView.ListCargadorForm(_apiClient);
            form.Show();
        }

        private void EliminarCargadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TechTienda.Forms.CargadorView.DeleteCargadorForm(_apiClient);
            form.ShowDialog();
        }

        private void ActualizarCargadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TechTienda.Forms.
                CargadorView.UpdateCargadorForm(_apiClient);
            form.ShowDialog();
        }


        private void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutUs();
            form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
