namespace TechTienda
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.celularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoCelularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarCelularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarCelularesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarCelularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarCelularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoCargadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarCargadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarCargadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarCargadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarCargadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.celularToolStripMenuItem,
            this.cargadorToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // celularToolStripMenuItem
            // 
            this.celularToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoCelularToolStripMenuItem,
            this.buscarCelularToolStripMenuItem,
            this.listarCelularesToolStripMenuItem,
            this.eliminarCelularToolStripMenuItem,
            this.actualizarCelularToolStripMenuItem});
            this.celularToolStripMenuItem.Name = "celularToolStripMenuItem";
            this.celularToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.celularToolStripMenuItem.Text = "Celular";
            // 
            // nuevoCelularToolStripMenuItem
            // 
            this.nuevoCelularToolStripMenuItem.Name = "nuevoCelularToolStripMenuItem";
            this.nuevoCelularToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nuevoCelularToolStripMenuItem.Text = "Nuevo Celular";
            this.nuevoCelularToolStripMenuItem.Click += new System.EventHandler(this.NuevoCelularToolStripMenuItem_Click);
            // 
            // buscarCelularToolStripMenuItem
            // 
            this.buscarCelularToolStripMenuItem.Name = "buscarCelularToolStripMenuItem";
            this.buscarCelularToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.buscarCelularToolStripMenuItem.Text = "Buscar Celular";
            this.buscarCelularToolStripMenuItem.Click += new System.EventHandler(this.BuscarCelularToolStripMenuItem_Click);
            // 
            // listarCelularesToolStripMenuItem
            // 
            this.listarCelularesToolStripMenuItem.Name = "listarCelularesToolStripMenuItem";
            this.listarCelularesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listarCelularesToolStripMenuItem.Text = "Listar Celulares";
            // 
            // eliminarCelularToolStripMenuItem
            // 
            this.eliminarCelularToolStripMenuItem.Name = "eliminarCelularToolStripMenuItem";
            this.eliminarCelularToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eliminarCelularToolStripMenuItem.Text = "Eliminar Celular";
            // 
            // actualizarCelularToolStripMenuItem
            // 
            this.actualizarCelularToolStripMenuItem.Name = "actualizarCelularToolStripMenuItem";
            this.actualizarCelularToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.actualizarCelularToolStripMenuItem.Text = "Actualizar Celular";
            // 
            // cargadorToolStripMenuItem
            // 
            this.cargadorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoCargadorToolStripMenuItem,
            this.buscarCargadorToolStripMenuItem,
            this.listarCargadoresToolStripMenuItem,
            this.eliminarCargadorToolStripMenuItem,
            this.actualizarCargadorToolStripMenuItem});
            this.cargadorToolStripMenuItem.Name = "cargadorToolStripMenuItem";
            this.cargadorToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.cargadorToolStripMenuItem.Text = "Cargador";
            // 
            // nuevoCargadorToolStripMenuItem
            // 
            this.nuevoCargadorToolStripMenuItem.Name = "nuevoCargadorToolStripMenuItem";
            this.nuevoCargadorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nuevoCargadorToolStripMenuItem.Text = "Nuevo Cargador";
            //this.nuevoCargadorToolStripMenuItem.Click += new System.EventHandler(this.NuevoCargadorToolStripMenuItem_Click);
            // 
            // buscarCargadorToolStripMenuItem
            // 
            this.buscarCargadorToolStripMenuItem.Name = "buscarCargadorToolStripMenuItem";
            this.buscarCargadorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.buscarCargadorToolStripMenuItem.Text = "Buscar Cargador";
            // 
            // listarCargadoresToolStripMenuItem
            // 
            this.listarCargadoresToolStripMenuItem.Name = "listarCargadoresToolStripMenuItem";
            this.listarCargadoresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listarCargadoresToolStripMenuItem.Text = "Listar Cargadores";
            // 
            // eliminarCargadorToolStripMenuItem
            // 
            this.eliminarCargadorToolStripMenuItem.Name = "eliminarCargadorToolStripMenuItem";
            this.eliminarCargadorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eliminarCargadorToolStripMenuItem.Text = "Eliminar Cargador";
            // 
            // actualizarCargadorToolStripMenuItem
            // 
            this.actualizarCargadorToolStripMenuItem.Name = "actualizarCargadorToolStripMenuItem";
            this.actualizarCargadorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.actualizarCargadorToolStripMenuItem.Text = "Actualizar Cargador";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.AcercaDeToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblEstado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblEstado
            // 
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(69, 17);
            this.lblEstado.Text = "Bienvenido!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "TechTienda - Gestión de Inventario";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem celularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoCelularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarCelularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarCelularesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarCelularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarCelularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoCargadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarCargadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarCargadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarCargadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarCargadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblEstado;
    }
}

