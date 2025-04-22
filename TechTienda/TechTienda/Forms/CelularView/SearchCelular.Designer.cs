namespace TechTienda.Forms.Celular
{
    partial class SearchCelular
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.cmbCriterio = new System.Windows.Forms.ComboBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.numPrecioMin = new System.Windows.Forms.NumericUpDown();
            this.numPrecioMax = new System.Windows.Forms.NumericUpDown();
            this.lblRango = new System.Windows.Forms.Label();
            this.panelRango = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMax)).BeginInit();
            this.panelRango.SuspendLayout();
            this.SuspendLayout();

            // cmbCriterio
            this.cmbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCriterio.FormattingEnabled = true;
            this.cmbCriterio.Location = new System.Drawing.Point(150, 30);
            this.cmbCriterio.Name = "cmbCriterio";
            this.cmbCriterio.Size = new System.Drawing.Size(200, 21);
            this.cmbCriterio.TabIndex = 0;

            // txtValor
            this.txtValor.Location = new System.Drawing.Point(150, 70);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(200, 20);
            this.txtValor.TabIndex = 1;

            // btnBuscar
            this.btnBuscar.Location = new System.Drawing.Point(360, 68);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;

            // dgvResultados
            this.dgvResultados.AllowUserToAddRows = false;
            this.dgvResultados.AllowUserToDeleteRows = false;
            this.dgvResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(20, 150);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.ReadOnly = true;
            this.dgvResultados.Size = new System.Drawing.Size(760, 300);
            this.dgvResultados.TabIndex = 3;

            // lblCriterio
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(20, 33);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(42, 13);
            this.lblCriterio.TabIndex = 4;
            this.lblCriterio.Text = "Criterio:";

            // lblValor
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(20, 73);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(34, 13);
            this.lblValor.TabIndex = 5;
            this.lblValor.Text = "Valor:";

            // numPrecioMin
            this.numPrecioMin.DecimalPlaces = 2;
            this.numPrecioMin.Location = new System.Drawing.Point(10, 3);
            this.numPrecioMin.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPrecioMin.Name = "numPrecioMin";
            this.numPrecioMin.Size = new System.Drawing.Size(120, 20);
            this.numPrecioMin.TabIndex = 6;

            // numPrecioMax
            this.numPrecioMax.DecimalPlaces = 2;
            this.numPrecioMax.Location = new System.Drawing.Point(150, 3);
            this.numPrecioMax.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPrecioMax.Name = "numPrecioMax";
            this.numPrecioMax.Size = new System.Drawing.Size(120, 20);
            this.numPrecioMax.TabIndex = 7;

            // lblRango
            this.lblRango.AutoSize = true;
            this.lblRango.Location = new System.Drawing.Point(136, 6);
            this.lblRango.Name = "lblRango";
            this.lblRango.Size = new System.Drawing.Size(13, 13);
            this.lblRango.TabIndex = 8;
            this.lblRango.Text = "a";

            // panelRango
            this.panelRango.Controls.Add(this.numPrecioMin);
            this.panelRango.Controls.Add(this.lblRango);
            this.panelRango.Controls.Add(this.numPrecioMax);
            this.panelRango.Location = new System.Drawing.Point(150, 70);
            this.panelRango.Name = "panelRango";
            this.panelRango.Size = new System.Drawing.Size(280, 26);
            this.panelRango.TabIndex = 9;
            this.panelRango.Visible = false;

            // SearchCelular
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.panelRango);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.dgvResultados);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.cmbCriterio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchCelular";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar Celulares";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioMax)).EndInit();
            this.panelRango.ResumeLayout(false);
            this.panelRango.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCriterio;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.NumericUpDown numPrecioMin;
        private System.Windows.Forms.NumericUpDown numPrecioMax;
        private System.Windows.Forms.Label lblRango;
        private System.Windows.Forms.Panel panelRango;
    }
}