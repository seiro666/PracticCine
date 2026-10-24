namespace PracticCine
{
    partial class Venta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Venta));
            dgvVenta = new DataGridView();
            txtIDVenta = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label5 = new Label();
            txtPrecio = new TextBox();
            label4 = new Label();
            cBoxIDCliente = new ComboBox();
            cBoxIDFuncion = new ComboBox();
            cBoxIDTipoBoleto = new ComboBox();
            toolStrip1 = new ToolStrip();
            btnNuevo = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnEliminar = new ToolStripButton();
            btnGuardar = new ToolStripButton();
            btnCancelar = new ToolStripButton();
            btnObtenerDatos = new ToolStripButton();
            btnSalir = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)dgvVenta).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvVenta
            // 
            dgvVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVenta.Location = new Point(13, 34);
            dgvVenta.Name = "dgvVenta";
            dgvVenta.RowHeadersWidth = 62;
            dgvVenta.Size = new Size(839, 232);
            dgvVenta.TabIndex = 65;
            // 
            // txtIDVenta
            // 
            txtIDVenta.Location = new Point(131, 350);
            txtIDVenta.Name = "txtIDVenta";
            txtIDVenta.Size = new Size(100, 23);
            txtIDVenta.TabIndex = 70;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(329, 353);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 69;
            label3.Text = "IDCliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 455);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 68;
            label2.Text = "IDTipoBoleto";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 353);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 67;
            label1.Text = "IDVenta";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(572, 353);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 74;
            label5.Text = "IDFuncion";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(391, 449);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 73;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(329, 452);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 72;
            label4.Text = "Precio";
            // 
            // cBoxIDCliente
            // 
            cBoxIDCliente.FormattingEnabled = true;
            cBoxIDCliente.Location = new Point(400, 351);
            cBoxIDCliente.Margin = new Padding(2, 2, 2, 2);
            cBoxIDCliente.Name = "cBoxIDCliente";
            cBoxIDCliente.Size = new Size(129, 23);
            cBoxIDCliente.TabIndex = 75;
            // 
            // cBoxIDFuncion
            // 
            cBoxIDFuncion.FormattingEnabled = true;
            cBoxIDFuncion.Location = new Point(641, 351);
            cBoxIDFuncion.Margin = new Padding(2, 2, 2, 2);
            cBoxIDFuncion.Name = "cBoxIDFuncion";
            cBoxIDFuncion.Size = new Size(129, 23);
            cBoxIDFuncion.TabIndex = 76;
            // 
            // cBoxIDTipoBoleto
            // 
            cBoxIDTipoBoleto.FormattingEnabled = true;
            cBoxIDTipoBoleto.Location = new Point(125, 453);
            cBoxIDTipoBoleto.Margin = new Padding(2, 2, 2, 2);
            cBoxIDTipoBoleto.Name = "cBoxIDTipoBoleto";
            cBoxIDTipoBoleto.Size = new Size(129, 23);
            cBoxIDTipoBoleto.TabIndex = 77;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNuevo, btnEditar, btnEliminar, btnGuardar, btnCancelar, btnObtenerDatos, btnSalir });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 2, 0);
            toolStrip1.Size = new Size(864, 31);
            toolStrip1.TabIndex = 78;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnNuevo
            // 
            btnNuevo.Image = (Image)resources.GetObject("btnNuevo.Image");
            btnNuevo.ImageTransparentColor = Color.Magenta;
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(70, 28);
            btnNuevo.Text = "Nuevo";
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEditar
            // 
            btnEditar.Image = (Image)resources.GetObject("btnEditar.Image");
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(65, 28);
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Image = (Image)resources.GetObject("btnEliminar.Image");
            btnEliminar.ImageTransparentColor = Color.Magenta;
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(78, 28);
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Image = (Image)resources.GetObject("btnGuardar.Image");
            btnGuardar.ImageTransparentColor = Color.Magenta;
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(77, 28);
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.ImageTransparentColor = Color.Magenta;
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(81, 28);
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnObtenerDatos
            // 
            btnObtenerDatos.Image = (Image)resources.GetObject("btnObtenerDatos.Image");
            btnObtenerDatos.ImageTransparentColor = Color.Magenta;
            btnObtenerDatos.Name = "btnObtenerDatos";
            btnObtenerDatos.Size = new Size(111, 28);
            btnObtenerDatos.Text = "Obtener Datos";
            btnObtenerDatos.Click += btnObtenerDatos_Click;
            // 
            // btnSalir
            // 
            btnSalir.Alignment = ToolStripItemAlignment.Right;
            btnSalir.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnSalir.Image = (Image)resources.GetObject("btnSalir.Image");
            btnSalir.ImageTransparentColor = Color.Magenta;
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(33, 28);
            btnSalir.Text = "Salir";
            btnSalir.Click += btnSalir_Click;
            // 
            // Venta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 552);
            Controls.Add(toolStrip1);
            Controls.Add(cBoxIDTipoBoleto);
            Controls.Add(cBoxIDFuncion);
            Controls.Add(cBoxIDCliente);
            Controls.Add(dgvVenta);
            Controls.Add(txtIDVenta);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(txtPrecio);
            Controls.Add(label4);
            Name = "Venta";
            Text = "Venta";
            ((System.ComponentModel.ISupportInitialize)dgvVenta).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvVenta;
        private TextBox txtIDVenta;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private TextBox txtPrecio;
        private Label label4;
        private ComboBox cBoxIDCliente;
        private ComboBox cBoxIDFuncion;
        private ComboBox cBoxIDTipoBoleto;
        private ToolStrip toolStrip1;
        private ToolStripButton btnNuevo;
        private ToolStripButton btnEditar;
        private ToolStripButton btnEliminar;
        private ToolStripButton btnGuardar;
        private ToolStripButton btnCancelar;
        private ToolStripButton btnObtenerDatos;
        private ToolStripButton btnSalir;
    }
}