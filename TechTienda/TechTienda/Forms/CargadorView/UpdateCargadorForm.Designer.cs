namespace TechTienda.Forms.CargadorView
{
    partial class UpdateCargadorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numId = new System.Windows.Forms.NumericUpDown();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCapacidad = new System.Windows.Forms.TextBox();
            this.numLongitud = new System.Windows.Forms.NumericUpDown();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.numGarantia = new System.Windows.Forms.NumericUpDown();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.lblCapacidad = new System.Windows.Forms.Label();
            this.lblLongitud = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblGarantia = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLongitud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGarantia)).BeginInit();
            this.SuspendLayout();
            // 
            // numId
            // 
            this.numId.Location = new System.Drawing.Point(150, 20);
            this.numId.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numId.Name = "numId";
            this.numId.Size = new System.Drawing.Size(100, 20);
            this.numId.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(260, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtCapacidad
            // 
            this.txtCapacidad.Location = new System.Drawing.Point(150, 60);
            this.txtCapacidad.Name = "txtCapacidad";
            this.txtCapacidad.Size = new System.Drawing.Size(200, 20);
            this.txtCapacidad.TabIndex = 2;
            // 
            // numLongitud
            // 
            this.numLongitud.DecimalPlaces = 2;
            this.numLongitud.Location = new System.Drawing.Point(150, 100);
            this.numLongitud.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numLongitud.Name = "numLongitud";
            this.numLongitud.Size = new System.Drawing.Size(100, 20);
            this.numLongitud.TabIndex = 3;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(150, 140);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(200, 20);
            this.txtMarca.TabIndex = 4;
            // 
            // numGarantia
            // 
            this.numGarantia.Location = new System.Drawing.Point(150, 180);
            this.numGarantia.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numGarantia.Name = "numGarantia";
            this.numGarantia.Size = new System.Drawing.Size(100, 20);
            this.numGarantia.TabIndex = 5;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(150, 220);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(250, 220);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(20, 22);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(64, 13);
            this.lblId.TabIndex = 8;
            this.lblId.Text = "ID Cargador";
            // 
            // lblCapacidad
            // 
            this.lblCapacidad.AutoSize = true;
            this.lblCapacidad.Location = new System.Drawing.Point(20, 63);
            this.lblCapacidad.Name = "lblCapacidad";
            this.lblCapacidad.Size = new System.Drawing.Size(58, 13);
            this.lblCapacidad.TabIndex = 9;
            this.lblCapacidad.Text = "Capacidad";
            // 
            // lblLongitud
            // 
            this.lblLongitud.AutoSize = true;
            this.lblLongitud.Location = new System.Drawing.Point(20, 102);
            this.lblLongitud.Name = "lblLongitud";
            this.lblLongitud.Size = new System.Drawing.Size(93, 13);
            this.lblLongitud.TabIndex = 10;
            this.lblLongitud.Text = "Longitud (metros)";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(20, 143);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(37, 13);
            this.lblMarca.TabIndex = 11;
            this.lblMarca.Text = "Marca";
            // 
            // lblGarantia
            // 
            this.lblGarantia.AutoSize = true;
            this.lblGarantia.Location = new System.Drawing.Point(20, 182);
            this.lblGarantia.Name = "lblGarantia";
            this.lblGarantia.Size = new System.Drawing.Size(96, 13);
            this.lblGarantia.TabIndex = 12;
            this.lblGarantia.Text = "Garantía (meses)";
            // 
            // UpdateCargadorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 260);
            this.Controls.Add(this.lblGarantia);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblLongitud);
            this.Controls.Add(this.lblCapacidad);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.numGarantia);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.numLongitud);
            this.Controls.Add(this.txtCapacidad);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.numId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateCargadorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Actualizar Cargador";
            ((System.ComponentModel.ISupportInitialize)(this.numId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLongitud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGarantia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numId;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCapacidad;
        private System.Windows.Forms.NumericUpDown numLongitud;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.NumericUpDown numGarantia;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblCapacidad;
        private System.Windows.Forms.Label lblLongitud;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblGarantia;
    }
}