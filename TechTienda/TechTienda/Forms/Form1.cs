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
            var menuCelular = new ToolStripMenuItem("Celular");
            menuCelular.DropDownItems.AddRange(new[] {
            CreateMenuItem("Nuevo Celular", () => new AddCelular(_apiClient)),
            CreateMenuItem("Buscar Celular", () => new SearchCelular(_apiClient)),
            CreateMenuItem("Listar Celulares", () => new ListCelularForm(_apiClient)),
            });

            var menuCargador = new ToolStripMenuItem("Cargador");
            //menuCargador.DropDownItems.AddRange(new[] {
            //CreateMenuItem("Nuevo Cargador", () => new AddCargador(_apiClient)),
            //CreateMenuItem("Buscar Cargador", () => new SearchCargador(_apiClient)),
            //CreateMenuItem("Listar Cargadores", () => new ListCargador(_apiClient)),
            //});

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
