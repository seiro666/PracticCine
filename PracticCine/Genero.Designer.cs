namespace PracticCine
{
    partial class Genero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Genero));
            txtNombreGenero = new TextBox();
            txtDescripcionGenero = new TextBox();
            txtIDGenero = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvGenero = new DataGridView();
            toolStrip1 = new ToolStrip();
            btnNuevo = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnEliminar = new ToolStripButton();
            btnGuardar = new ToolStripButton();
            btnCancelar = new ToolStripButton();
            btnObtenerDatos = new ToolStripButton();
            btnSalir = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)dgvGenero).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtNombreGenero
            // 
            txtNombreGenero.Location = new Point(449, 343);
            txtNombreGenero.Name = "txtNombreGenero";
            txtNombreGenero.Size = new Size(100, 23);
            txtNombreGenero.TabIndex = 19;
            // 
            // txtDescripcionGenero
            // 
            txtDescripcionGenero.Location = new Point(159, 439);
            txtDescripcionGenero.Name = "txtDescripcionGenero";
            txtDescripcionGenero.Size = new Size(100, 23);
            txtDescripcionGenero.TabIndex = 18;
            // 
            // txtIDGenero
            // 
            txtIDGenero.Location = new Point(134, 346);
            txtIDGenero.Name = "txtIDGenero";
            txtIDGenero.Size = new Size(100, 23);
            txtIDGenero.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(351, 346);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 15;
            label3.Text = "Nombre Genero";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 442);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 14;
            label2.Text = "Descripcion Genero";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 346);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 13;
            label1.Text = "IDGenero";
            // 
            // dgvGenero
            // 
            dgvGenero.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGenero.Location = new Point(12, 34);
            dgvGenero.Name = "dgvGenero";
            dgvGenero.RowHeadersWidth = 62;
            dgvGenero.Size = new Size(839, 232);
            dgvGenero.TabIndex = 11;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNuevo, btnEditar, btnEliminar, btnGuardar, btnCancelar, btnObtenerDatos, btnSalir });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 2, 0);
            toolStrip1.Size = new Size(865, 31);
            toolStrip1.TabIndex = 20;
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
            // Genero
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 503);
            Controls.Add(toolStrip1);
            Controls.Add(txtNombreGenero);
            Controls.Add(txtDescripcionGenero);
            Controls.Add(txtIDGenero);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvGenero);
            Name = "Genero";
            Text = "Genero";
            ((System.ComponentModel.ISupportInitialize)dgvGenero).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombreGenero;
        private TextBox txtDescripcionGenero;
        private TextBox txtIDGenero;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dgvGenero;
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