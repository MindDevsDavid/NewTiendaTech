namespace TechTienda.Forms.CargadorView
{
    partial class AddCargadorForm
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
            this.txtCapacidad = new System.Windows.Forms.TextBox();
            this.numLongitud = new System.Windows.Forms.NumericUpDown();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.numGarantia = new System.Windows.Forms.NumericUpDown();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblCapacidad = new System.Windows.Forms.Label();
            this.lblLongitud = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblGarantia = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numLongitud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGarantia)).BeginInit();
            this.SuspendLayout();

            // txtCapacidad
            this.txtCapacidad.Location = new System.Drawing.Point(150, 30);
            this.txtCapacidad.Name = "txtCapacidad";
            this.txtCapacidad.Size = new System.Drawing.Size(200, 20);
            this.txtCapacidad.TabIndex = 0;

            // numLongitud
            this.numLongitud.DecimalPlaces = 2;
            this.numLongitud.Location = new System.Drawing.Point(150, 70);
            this.numLongitud.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numLongitud.Name = "numLongitud";
            this.numLongitud.Size = new System.Drawing.Size(100, 20);
            this.numLongitud.TabIndex = 1;

            // txtMarca
            this.txtMarca.Location = new System.Drawing.Point(150, 110);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(200, 20);
            this.txtMarca.TabIndex = 2;

            // numGarantia
            this.numGarantia.Location = new System.Drawing.Point(150, 150);
            this.numGarantia.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numGarantia.Name = "numGarantia";
            this.numGarantia.Size = new System.Drawing.Size(100, 20);
            this.numGarantia.TabIndex = 3;

            // btnGuardar
            this.btnGuardar.Location = new System.Drawing.Point(150, 200);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 30);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(250, 200);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 30);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;

            // lblCapacidad
            this.lblCapacidad.AutoSize = true;
            this.lblCapacidad.Location = new System.Drawing.Point(30, 33);
            this.lblCapacidad.Name = "lblCapacidad";
            this.lblCapacidad.Size = new System.Drawing.Size(61, 13);
            this.lblCapacidad.TabIndex = 6;
            this.lblCapacidad.Text = "Capacidad:";

            // lblLongitud
            this.lblLongitud.AutoSize = true;
            this.lblLongitud.Location = new System.Drawing.Point(30, 73);
            this.lblLongitud.Name = "lblLongitud";
            this.lblLongitud.Size = new System.Drawing.Size(93, 13);
            this.lblLongitud.TabIndex = 7;
            this.lblLongitud.Text = "Longitud (metros):";

            // lblMarca
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(30, 113);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(40, 13);
            this.lblMarca.TabIndex = 8;
            this.lblMarca.Text = "Marca:";

            // lblGarantia
            this.lblGarantia.AutoSize = true;
            this.lblGarantia.Location = new System.Drawing.Point(30, 153);
            this.lblGarantia.Name = "lblGarantia";
            this.lblGarantia.Size = new System.Drawing.Size(96, 13);
            this.lblGarantia.TabIndex = 9;
            this.lblGarantia.Text = "Garantía (meses):";

            // AddCargadorForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.lblGarantia);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblLongitud);
            this.Controls.Add(this.lblCapacidad);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.numGarantia);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.numLongitud);
            this.Controls.Add(this.txtCapacidad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCargadorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nuevo Cargador";
            ((System.ComponentModel.ISupportInitialize)(this.numLongitud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGarantia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtCapacidad;
        private System.Windows.Forms.NumericUpDown numLongitud;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.NumericUpDown numGarantia;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblCapacidad;
        private System.Windows.Forms.Label lblLongitud;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblGarantia;
    }
}