namespace PracticCine
{
    partial class TipoBoleto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TipoBoleto));
            txtClave = new TextBox();
            txtDescripcion = new TextBox();
            txtIDTipoBoleto = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtPrecio = new TextBox();
            label4 = new Label();
            dgvTpoBoleto = new DataGridView();
            toolStrip1 = new ToolStrip();
            btnNuevo = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnEliminar = new ToolStripButton();
            btnGuardar = new ToolStripButton();
            btnCancelar = new ToolStripButton();
            btnObtenerDatos = new ToolStripButton();
            btnSalir = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)dgvTpoBoleto).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtClave
            // 
            txtClave.Location = new Point(429, 352);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(100, 23);
            txtClave.TabIndex = 61;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(127, 448);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(100, 23);
            txtDescripcion.TabIndex = 60;
            // 
            // txtIDTipoBoleto
            // 
            txtIDTipoBoleto.Location = new Point(127, 352);
            txtIDTipoBoleto.Name = "txtIDTipoBoleto";
            txtIDTipoBoleto.Size = new Size(100, 23);
            txtIDTipoBoleto.TabIndex = 59;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(338, 355);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 58;
            label3.Text = "Clave";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 451);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 57;
            label2.Text = "Descripcion";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 355);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 56;
            label1.Text = "IDTipoBoleto";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(429, 448);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 63;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(338, 451);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 62;
            label4.Text = "Precio";
            // 
            // dgvTpoBoleto
            // 
            dgvTpoBoleto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTpoBoleto.Location = new Point(10, 34);
            dgvTpoBoleto.Name = "dgvTpoBoleto";
            dgvTpoBoleto.RowHeadersWidth = 62;
            dgvTpoBoleto.Size = new Size(839, 232);
            dgvTpoBoleto.TabIndex = 54;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNuevo, btnEditar, btnEliminar, btnGuardar, btnCancelar, btnObtenerDatos, btnSalir });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 2, 0);
            toolStrip1.Size = new Size(861, 31);
            toolStrip1.TabIndex = 64;
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
            // TipoBoleto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(861, 548);
            Controls.Add(toolStrip1);
            Controls.Add(txtClave);
            Controls.Add(txtDescripcion);
            Controls.Add(txtIDTipoBoleto);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPrecio);
            Controls.Add(label4);
            Controls.Add(dgvTpoBoleto);
            Name = "TipoBoleto";
            Text = "TipoBoleto";
            ((System.ComponentModel.ISupportInitialize)dgvTpoBoleto).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtClave;
        private TextBox txtDescripcion;
        private TextBox txtIDTipoBoleto;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtPrecio;
        private Label label4;
        private DataGridView dgvTpoBoleto;
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