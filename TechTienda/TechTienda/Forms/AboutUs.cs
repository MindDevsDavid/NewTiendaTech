using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechTienda.Forms
{
    public partial class AboutUs : Form
    {
        public AboutUs()
        {
            InitializeComponent();
            lblVersion.Text = $"Versión: {Assembly.GetExecutingAssembly().GetName().Version}";
            lblTeam.Text = "Desarrollado por:\n- Julian Rubiano\n- David Alejandro Gutierrez\n- David Alejandro De Los Reyes\n- José Ariél Resendiz";
        }
    }
}
