namespace PracticCine
{
    partial class Sucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sucursal));
            label4 = new Label();
            dgvSucursal = new DataGridView();
            txtNombreSucursal = new TextBox();
            txtDireccion = new TextBox();
            txtIDSucursal = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cBoxIDCiudad = new ComboBox();
            toolStrip1 = new ToolStrip();
            btnNuevo = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnEliminar = new ToolStripButton();
            btnGuardar = new ToolStripButton();
            btnCancelar = new ToolStripButton();
            btnObtenerDatos = new ToolStripButton();
            btnSalir = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)dgvSucursal).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(343, 442);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 40;
            label4.Text = "IDCiudad";
            // 
            // dgvSucursal
            // 
            dgvSucursal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSucursal.Location = new Point(12, 34);
            dgvSucursal.Name = "dgvSucursal";
            dgvSucursal.RowHeadersWidth = 62;
            dgvSucursal.Size = new Size(839, 232);
            dgvSucursal.TabIndex = 32;
            // 
            // txtNombreSucursal
            // 
            txtNombreSucursal.Location = new Point(453, 343);
            txtNombreSucursal.Name = "txtNombreSucursal";
            txtNombreSucursal.Size = new Size(100, 23);
            txtNombreSucursal.TabIndex = 39;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(134, 439);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(100, 23);
            txtDireccion.TabIndex = 38;
            // 
            // txtIDSucursal
            // 
            txtIDSucursal.Location = new Point(134, 343);
            txtIDSucursal.Name = "txtIDSucursal";
            txtIDSucursal.Size = new Size(100, 23);
            txtIDSucursal.TabIndex = 37;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(343, 346);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 36;
            label3.Text = "Nombre Sucursal";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 442);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 35;
            label2.Text = "Direccion";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 346);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 34;
            label1.Text = "IDSucursal";
            // 
            // cBoxIDCiudad
            // 
            cBoxIDCiudad.FormattingEnabled = true;
            cBoxIDCiudad.Location = new Point(436, 440);
            cBoxIDCiudad.Margin = new Padding(2, 2, 2, 2);
            cBoxIDCiudad.Name = "cBoxIDCiudad";
            cBoxIDCiudad.Size = new Size(129, 23);
            cBoxIDCiudad.TabIndex = 41;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNuevo, btnEditar, btnEliminar, btnGuardar, btnCancelar, btnObtenerDatos, btnSalir });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 2, 0);
            toolStrip1.Size = new Size(863, 31);
            toolStrip1.TabIndex = 42;
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
            // Sucursal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(863, 522);
            Controls.Add(toolStrip1);
            Controls.Add(cBoxIDCiudad);
            Controls.Add(label4);
            Controls.Add(dgvSucursal);
            Controls.Add(txtNombreSucursal);
            Controls.Add(txtDireccion);
            Controls.Add(txtIDSucursal);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Sucursal";
            Text = "Sucursal";
            ((System.ComponentModel.ISupportInitialize)dgvSucursal).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label4;
        private DataGridView dgvSucursal;
        private TextBox txtNombreSucursal;
        private TextBox txtDireccion;
        private TextBox txtIDSucursal;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cBoxIDCiudad;
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