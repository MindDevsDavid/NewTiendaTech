namespace TechTienda.Forms.CelularView
{
    partial class UpdateCelularForm
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
            this.numId = new System.Windows.Forms.NumericUpDown();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.numPrecio = new System.Windows.Forms.NumericUpDown();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.numAlmacenamiento = new System.Windows.Forms.NumericUpDown();
            this.dtpFechaLanzamiento = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblAlmacenamiento = new System.Windows.Forms.Label();
            this.lblFechaLanzamiento = new System.Windows.Forms.Label();
            this.cmbCargador = new System.Windows.Forms.ComboBox();
            this.lblCargador = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlmacenamiento)).BeginInit();
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
            this.numId.Size = new System.Drawing.Size(120, 22);
            this.numId.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(280, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(150, 60);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 22);
            this.txtNombre.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(150, 100);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(200, 60);
            this.txtDescripcion.TabIndex = 3;
            // 
            // numPrecio
            // 
            this.numPrecio.DecimalPlaces = 2;
            this.numPrecio.Location = new System.Drawing.Point(150, 180);
            this.numPrecio.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPrecio.Name = "numPrecio";
            this.numPrecio.Size = new System.Drawing.Size(120, 22);
            this.numPrecio.TabIndex = 4;
            // 
            // numStock
            // 
            this.numStock.Location = new System.Drawing.Point(150, 220);
            this.numStock.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numStock.Name = "numStock";
            this.numStock.Size = new System.Drawing.Size(120, 22);
            this.numStock.TabIndex = 5;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(150, 260);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(200, 22);
            this.txtMarca.TabIndex = 6;
            // 
            // numAlmacenamiento
            // 
            this.numAlmacenamiento.Location = new System.Drawing.Point(150, 300);
            this.numAlmacenamiento.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAlmacenamiento.Name = "numAlmacenamiento";
            this.numAlmacenamiento.Size = new System.Drawing.Size(120, 22);
            this.numAlmacenamiento.TabIndex = 7;
            this.numAlmacenamiento.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // dtpFechaLanzamiento
            // 
            this.dtpFechaLanzamiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaLanzamiento.Location = new System.Drawing.Point(150, 340);
            this.dtpFechaLanzamiento.Name = "dtpFechaLanzamiento";
            this.dtpFechaLanzamiento.Size = new System.Drawing.Size(120, 22);
            this.dtpFechaLanzamiento.TabIndex = 8;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(150, 420);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 30);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(250, 420);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 30);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(30, 22);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(64, 13);
            this.lblId.TabIndex = 11;
            this.lblId.Text = "ID Celular:";
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(0, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 23);
            this.lblNombre.TabIndex = 0;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(0, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(100, 23);
            this.lblDescripcion.TabIndex = 0;
            // 
            // lblPrecio
            // 
            this.lblPrecio.Location = new System.Drawing.Point(0, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(100, 23);
            this.lblPrecio.TabIndex = 0;
            // 
            // lblStock
            // 
            this.lblStock.Location = new System.Drawing.Point(0, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(100, 23);
            this.lblStock.TabIndex = 0;
            // 
            // lblMarca
            // 
            this.lblMarca.Location = new System.Drawing.Point(0, 0);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(100, 23);
            this.lblMarca.TabIndex = 0;
            // 
            // lblAlmacenamiento
            // 
            this.lblAlmacenamiento.Location = new System.Drawing.Point(0, 0);
            this.lblAlmacenamiento.Name = "lblAlmacenamiento";
            this.lblAlmacenamiento.Size = new System.Drawing.Size(100, 23);
            this.lblAlmacenamiento.TabIndex = 0;
            // 
            // lblFechaLanzamiento
            // 
            this.lblFechaLanzamiento.Location = new System.Drawing.Point(0, 0);
            this.lblFechaLanzamiento.Name = "lblFechaLanzamiento";
            this.lblFechaLanzamiento.Size = new System.Drawing.Size(100, 23);
            this.lblFechaLanzamiento.TabIndex = 0;
            // 
            // cmbCargador
            // 
            this.cmbCargador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCargador.FormattingEnabled = true;
            this.cmbCargador.Location = new System.Drawing.Point(200, 468);
            this.cmbCargador.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbCargador.Name = "cmbCargador";
            this.cmbCargador.Size = new System.Drawing.Size(265, 24);
            this.cmbCargador.TabIndex = 12;
            // 
            // lblCargador
            // 
            this.lblCargador.Location = new System.Drawing.Point(0, 0);
            this.lblCargador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCargador.Name = "lblCargador";
            this.lblCargador.Size = new System.Drawing.Size(133, 28);
            this.lblCargador.TabIndex = 13;
            // 
            // UpdateCelularForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 578);
            this.Controls.Add(this.cmbCargador);
            this.Controls.Add(this.lblCargador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateCelularForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Actualizar Celular";
            this.Load += new System.EventHandler(this.UpdateCelularForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlmacenamiento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numId;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.NumericUpDown numPrecio;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.NumericUpDown numAlmacenamiento;
        private System.Windows.Forms.DateTimePicker dtpFechaLanzamiento;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblAlmacenamiento;
        private System.Windows.Forms.Label lblFechaLanzamiento;
        private System.Windows.Forms.ComboBox cmbCargador;
        private System.Windows.Forms.Label lblCargador;
    }
}