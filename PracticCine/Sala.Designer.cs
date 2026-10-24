namespace PracticCine
{
    partial class Sala
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sala));
            txtCantidadAsientos = new TextBox();
            label4 = new Label();
            dgvSala = new DataGridView();
            txtTipoSala = new TextBox();
            txtIDSala = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtNumeroSala = new TextBox();
            label5 = new Label();
            cBoxIDSucursal = new ComboBox();
            toolStrip1 = new ToolStrip();
            btnNuevo = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnEliminar = new ToolStripButton();
            btnGuardar = new ToolStripButton();
            btnCancelar = new ToolStripButton();
            btnObtenerDatos = new ToolStripButton();
            btnSalir = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)dgvSala).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtCantidadAsientos
            // 
            txtCantidadAsientos.Location = new Point(411, 419);
            txtCantidadAsientos.Name = "txtCantidadAsientos";
            txtCantidadAsientos.Size = new Size(100, 23);
            txtCantidadAsientos.TabIndex = 51;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(302, 422);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 50;
            label4.Text = "Cantidad Asientos";
            // 
            // dgvSala
            // 
            dgvSala.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSala.Location = new Point(12, 34);
            dgvSala.Name = "dgvSala";
            dgvSala.RowHeadersWidth = 62;
            dgvSala.Size = new Size(839, 232);
            dgvSala.TabIndex = 42;
            // 
            // txtTipoSala
            // 
            txtTipoSala.Location = new Point(140, 419);
            txtTipoSala.Name = "txtTipoSala";
            txtTipoSala.Size = new Size(100, 23);
            txtTipoSala.TabIndex = 48;
            // 
            // txtIDSala
            // 
            txtIDSala.Location = new Point(140, 323);
            txtIDSala.Name = "txtIDSala";
            txtIDSala.Size = new Size(100, 23);
            txtIDSala.TabIndex = 47;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(302, 326);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 46;
            label3.Text = "IDSucursal";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 422);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 45;
            label2.Text = "Tipo Sala";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 326);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 44;
            label1.Text = "IDSala";
            // 
            // txtNumeroSala
            // 
            txtNumeroSala.Location = new Point(650, 323);
            txtNumeroSala.Name = "txtNumeroSala";
            txtNumeroSala.Size = new Size(100, 23);
            txtNumeroSala.TabIndex = 53;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(569, 326);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 52;
            label5.Text = "Numero Sala";
            // 
            // cBoxIDSucursal
            // 
            cBoxIDSucursal.FormattingEnabled = true;
            cBoxIDSucursal.Location = new Point(373, 324);
            cBoxIDSucursal.Margin = new Padding(2, 2, 2, 2);
            cBoxIDSucursal.Name = "cBoxIDSucursal";
            cBoxIDSucursal.Size = new Size(129, 23);
            cBoxIDSucursal.TabIndex = 54;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNuevo, btnEditar, btnEliminar, btnGuardar, btnCancelar, btnObtenerDatos, btnSalir });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 2, 0);
            toolStrip1.Size = new Size(863, 31);
            toolStrip1.TabIndex = 55;
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
            // Sala
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(863, 537);
            Controls.Add(toolStrip1);
            Controls.Add(cBoxIDSucursal);
            Controls.Add(txtNumeroSala);
            Controls.Add(label5);
            Controls.Add(txtCantidadAsientos);
            Controls.Add(label4);
            Controls.Add(dgvSala);
            Controls.Add(txtTipoSala);
            Controls.Add(txtIDSala);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Sala";
            Text = "Sala";
            ((System.ComponentModel.ISupportInitialize)dgvSala).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCantidadAsientos;
        private Label label4;
        private DataGridView dgvSala;
        private TextBox txtTipoSala;
        private TextBox txtIDSala;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtNumeroSala;
        private Label label5;
        private ComboBox cBoxIDSucursal;
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