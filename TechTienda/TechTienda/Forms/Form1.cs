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

namespace TechTienda
{
    public partial class Form1 : Form
    {
        private readonly ApiClient _apiClient = new ApiClient();
        public Form1()
        {
            InitializeComponent();
            // Inicializar el cliente API
            ConfigureMenu();
        }
        private void ConfigureMenu()
        {
            // Menú Celular
            var celularMenu = new ToolStripMenuItem("Celular");
            celularMenu.DropDownItems.AddRange(new[] {
            CreateMenuItem("Nuevo Celular", () => new AddCelular(_apiClient)),
            CreateMenuItem("Buscar Celular", () => new SearchCelular(_apiClient)),
            // Agregar demás opciones...
        });

            // Menú Cargador
            var cargadorMenu = new ToolStripMenuItem("Cargador");
            // ... misma estructura que Celular

            // Menú Ayuda
            var ayudaMenu = new ToolStripMenuItem("Ayuda");
            ayudaMenu.DropDownItems.Add("Acerca de...", null, (s, e) => new AboutUs().ShowDialog());

            menuStrip1.Items.AddRange(new[] { celularMenu, cargadorMenu, ayudaMenu });
        }

        private ToolStripMenuItem CreateMenuItem(string text, Func<Form> formCreator)
        {
            var item = new ToolStripMenuItem(text);
            item.Click += (s, e) => formCreator().Show();
            return item;
        }

    }
}
