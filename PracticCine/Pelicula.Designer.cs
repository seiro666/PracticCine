namespace PracticCine
{
    partial class Pelicula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pelicula));
            txtNombrePelicula = new TextBox();
            txtDuracion = new TextBox();
            txtIDPelicula = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvPelicula = new DataGridView();
            label4 = new Label();
            label5 = new Label();
            cBoxIDClasificacion = new ComboBox();
            cBoxIDGenero = new ComboBox();
            toolStrip1 = new ToolStrip();
            btnNuevo = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnEliminar = new ToolStripButton();
            btnGuardar = new ToolStripButton();
            btnCancelar = new ToolStripButton();
            btnObtenerDatos = new ToolStripButton();
            btnSalir = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)dgvPelicula).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtNombrePelicula
            // 
            txtNombrePelicula.Location = new Point(380, 343);
            txtNombrePelicula.Name = "txtNombrePelicula";
            txtNombrePelicula.Size = new Size(100, 23);
            txtNombrePelicula.TabIndex = 27;
            // 
            // txtDuracion
            // 
            txtDuracion.Location = new Point(134, 439);
            txtDuracion.Name = "txtDuracion";
            txtDuracion.Size = new Size(100, 23);
            txtDuracion.TabIndex = 26;
            // 
            // txtIDPelicula
            // 
            txtIDPelicula.Location = new Point(134, 346);
            txtIDPelicula.Name = "txtIDPelicula";
            txtIDPelicula.Size = new Size(100, 23);
            txtIDPelicula.TabIndex = 25;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(270, 346);
            label3.Name = "label3";
            label3.Size = new Size(95, 15);
            label3.TabIndex = 24;
            label3.Text = "Nombre Pelicula";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 442);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 23;
            label2.Text = "Duracion";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 346);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 22;
            label1.Text = "ID Pelicula";
            // 
            // dgvPelicula
            // 
            dgvPelicula.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPelicula.Location = new Point(12, 34);
            dgvPelicula.Name = "dgvPelicula";
            dgvPelicula.RowHeadersWidth = 62;
            dgvPelicula.Size = new Size(839, 232);
            dgvPelicula.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(270, 442);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 28;
            label4.Text = "IDGenero";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(524, 346);
            label5.Name = "label5";
            label5.Size = new Size(85, 15);
            label5.TabIndex = 30;
            label5.Text = "IDClasificacion";
            // 
            // cBoxIDClasificacion
            // 
            cBoxIDClasificacion.FormattingEnabled = true;
            cBoxIDClasificacion.Location = new Point(617, 345);
            cBoxIDClasificacion.Margin = new Padding(2, 2, 2, 2);
            cBoxIDClasificacion.Name = "cBoxIDClasificacion";
            cBoxIDClasificacion.Size = new Size(129, 23);
            cBoxIDClasificacion.TabIndex = 31;
            // 
            // cBoxIDGenero
            // 
            cBoxIDGenero.FormattingEnabled = true;
            cBoxIDGenero.Location = new Point(336, 440);
            cBoxIDGenero.Margin = new Padding(2, 2, 2, 2);
            cBoxIDGenero.Name = "cBoxIDGenero";
            cBoxIDGenero.Size = new Size(129, 23);
            cBoxIDGenero.TabIndex = 32;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNuevo, btnEditar, btnEliminar, btnGuardar, btnCancelar, btnObtenerDatos, btnSalir });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 2, 0);
            toolStrip1.Size = new Size(867, 31);
            toolStrip1.TabIndex = 33;
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
            // Pelicula
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 507);
            Controls.Add(toolStrip1);
            Controls.Add(cBoxIDGenero);
            Controls.Add(cBoxIDClasificacion);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtNombrePelicula);
            Controls.Add(txtDuracion);
            Controls.Add(txtIDPelicula);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvPelicula);
            Name = "Pelicula";
            Text = "Pelicula";
            ((System.ComponentModel.ISupportInitialize)dgvPelicula).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombrePelicula;
        private TextBox txtDuracion;
        private TextBox txtIDPelicula;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dgvPelicula;
        private Label label4;
        private Label label5;
        private ComboBox cBoxIDClasificacion;
        private ComboBox cBoxIDGenero;
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