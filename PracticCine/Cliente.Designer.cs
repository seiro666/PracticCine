namespace PracticCine
{
    partial class Cliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cliente));
            txtNombre = new TextBox();
            label5 = new Label();
            txtCorreo = new TextBox();
            dgvCliente = new DataGridView();
            label4 = new Label();
            txtIDCliente = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtCelular = new TextBox();
            cBoxIDCiudad = new ComboBox();
            toolStrip1 = new ToolStrip();
            btnNuevo = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnEliminar = new ToolStripButton();
            btnGuardar = new ToolStripButton();
            btnCancelar = new ToolStripButton();
            btnObtenerDatos = new ToolStripButton();
            btnSalir = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)dgvCliente).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(633, 352);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 63;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(570, 355);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 62;
            label5.Text = "Nombre";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(389, 451);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(100, 23);
            txtCorreo.TabIndex = 61;
            // 
            // dgvCliente
            // 
            dgvCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCliente.Location = new Point(12, 28);
            dgvCliente.Name = "dgvCliente";
            dgvCliente.RowHeadersWidth = 62;
            dgvCliente.Size = new Size(839, 232);
            dgvCliente.TabIndex = 53;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(327, 454);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 60;
            label4.Text = "Correo";
            // 
            // txtIDCliente
            // 
            txtIDCliente.Location = new Point(129, 352);
            txtIDCliente.Name = "txtIDCliente";
            txtIDCliente.Size = new Size(100, 23);
            txtIDCliente.TabIndex = 58;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(327, 355);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 57;
            label3.Text = "IDCiudad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 457);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 56;
            label2.Text = "Celular";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 355);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 55;
            label1.Text = "IDCliente";
            // 
            // txtCelular
            // 
            txtCelular.Location = new Point(129, 454);
            txtCelular.Name = "txtCelular";
            txtCelular.Size = new Size(100, 23);
            txtCelular.TabIndex = 64;
            // 
            // cBoxIDCiudad
            // 
            cBoxIDCiudad.FormattingEnabled = true;
            cBoxIDCiudad.Location = new Point(392, 352);
            cBoxIDCiudad.Margin = new Padding(2, 2, 2, 2);
            cBoxIDCiudad.Name = "cBoxIDCiudad";
            cBoxIDCiudad.Size = new Size(129, 23);
            cBoxIDCiudad.TabIndex = 65;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNuevo, btnEditar, btnEliminar, btnGuardar, btnCancelar, btnObtenerDatos, btnSalir });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 2, 0);
            toolStrip1.Size = new Size(862, 31);
            toolStrip1.TabIndex = 66;
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
            // Cliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(862, 535);
            Controls.Add(toolStrip1);
            Controls.Add(cBoxIDCiudad);
            Controls.Add(txtCelular);
            Controls.Add(txtNombre);
            Controls.Add(label5);
            Controls.Add(txtCorreo);
            Controls.Add(dgvCliente);
            Controls.Add(label4);
            Controls.Add(txtIDCliente);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Cliente";
            Text = "Cliente";
            ((System.ComponentModel.ISupportInitialize)dgvCliente).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private Label label5;
        private TextBox txtCorreo;
        private DataGridView dgvCliente;
        private Label label4;
        private TextBox txtIDCliente;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtCelular;
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