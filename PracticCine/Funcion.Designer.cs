namespace PracticCine
{
    partial class Funcion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Funcion));
            dgvFuncion = new DataGridView();
            txtHora = new TextBox();
            label4 = new Label();
            txtIDFuncion = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label5 = new Label();
            dtFecha = new DateTimePicker();
            cBoxIDPelicula = new ComboBox();
            cBoxIDSala = new ComboBox();
            toolStrip1 = new ToolStrip();
            btnNuevo = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnEliminar = new ToolStripButton();
            btnGuardar = new ToolStripButton();
            btnCancelar = new ToolStripButton();
            btnObtenerDatos = new ToolStripButton();
            btnSalir = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)dgvFuncion).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvFuncion
            // 
            dgvFuncion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFuncion.Location = new Point(17, 47);
            dgvFuncion.Margin = new Padding(4, 5, 4, 5);
            dgvFuncion.Name = "dgvFuncion";
            dgvFuncion.RowHeadersWidth = 62;
            dgvFuncion.Size = new Size(1199, 387);
            dgvFuncion.TabIndex = 20;
            // 
            // txtHora
            // 
            txtHora.Location = new Point(563, 718);
            txtHora.Margin = new Padding(4, 5, 4, 5);
            txtHora.Name = "txtHora";
            txtHora.Size = new Size(141, 31);
            txtHora.TabIndex = 49;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(474, 723);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(51, 25);
            label4.TabIndex = 48;
            label4.Text = "Hora";
            // 
            // txtIDFuncion
            // 
            txtIDFuncion.Location = new Point(191, 553);
            txtIDFuncion.Margin = new Padding(4, 5, 4, 5);
            txtIDFuncion.Name = "txtIDFuncion";
            txtIDFuncion.Size = new Size(141, 31);
            txtIDFuncion.TabIndex = 45;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(474, 558);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 44;
            label3.Text = "IDPelicula";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 723);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(57, 25);
            label2.TabIndex = 43;
            label2.Text = "Fecha";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 558);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(92, 25);
            label1.TabIndex = 42;
            label1.Text = "IDFuncion";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(821, 558);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(62, 25);
            label5.TabIndex = 50;
            label5.Text = "IDSala";
            // 
            // dtFecha
            // 
            dtFecha.Location = new Point(139, 717);
            dtFecha.Margin = new Padding(4, 5, 4, 5);
            dtFecha.Name = "dtFecha";
            dtFecha.Size = new Size(284, 31);
            dtFecha.TabIndex = 52;
            // 
            // cBoxIDPelicula
            // 
            cBoxIDPelicula.FormattingEnabled = true;
            cBoxIDPelicula.Location = new Point(568, 555);
            cBoxIDPelicula.Name = "cBoxIDPelicula";
            cBoxIDPelicula.Size = new Size(182, 33);
            cBoxIDPelicula.TabIndex = 53;
            // 
            // cBoxIDSala
            // 
            cBoxIDSala.FormattingEnabled = true;
            cBoxIDSala.Location = new Point(890, 558);
            cBoxIDSala.Name = "cBoxIDSala";
            cBoxIDSala.Size = new Size(182, 33);
            cBoxIDSala.TabIndex = 54;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNuevo, btnEditar, btnEliminar, btnGuardar, btnCancelar, btnObtenerDatos, btnSalir });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 3, 0);
            toolStrip1.Size = new Size(1234, 34);
            toolStrip1.TabIndex = 55;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnNuevo
            // 
            btnNuevo.Image = (Image)resources.GetObject("btnNuevo.Image");
            btnNuevo.ImageTransparentColor = Color.Magenta;
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(92, 29);
            btnNuevo.Text = "Nuevo";
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEditar
            // 
            btnEditar.Image = (Image)resources.GetObject("btnEditar.Image");
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(85, 29);
            btnEditar.Text = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Image = (Image)resources.GetObject("btnEliminar.Image");
            btnEliminar.ImageTransparentColor = Color.Magenta;
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(102, 29);
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Image = (Image)resources.GetObject("btnGuardar.Image");
            btnGuardar.ImageTransparentColor = Color.Magenta;
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(103, 29);
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.ImageTransparentColor = Color.Magenta;
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(106, 29);
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnObtenerDatos
            // 
            btnObtenerDatos.Image = (Image)resources.GetObject("btnObtenerDatos.Image");
            btnObtenerDatos.ImageTransparentColor = Color.Magenta;
            btnObtenerDatos.Name = "btnObtenerDatos";
            btnObtenerDatos.Size = new Size(157, 29);
            btnObtenerDatos.Text = "Obtener Datos";
            // 
            // btnSalir
            // 
            btnSalir.Alignment = ToolStripItemAlignment.Right;
            btnSalir.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnSalir.Image = (Image)resources.GetObject("btnSalir.Image");
            btnSalir.ImageTransparentColor = Color.Magenta;
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(49, 29);
            btnSalir.Text = "Salir";
            btnSalir.Click += btnSalir_Click;
            // 
            // Funcion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 890);
            Controls.Add(toolStrip1);
            Controls.Add(cBoxIDSala);
            Controls.Add(cBoxIDPelicula);
            Controls.Add(dtFecha);
            Controls.Add(label5);
            Controls.Add(txtHora);
            Controls.Add(label4);
            Controls.Add(txtIDFuncion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvFuncion);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Funcion";
            Text = "Funcion";
            ((System.ComponentModel.ISupportInitialize)dgvFuncion).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox DescripcionGenero;
        private TextBox txtIDGenero;
        private DataGridView dgvFuncion;
        private TextBox txtHora;
        private Label label4;
        private TextBox txtIDFuncion;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private DateTimePicker dtFecha;
        private TextBox textBox2;
        private ComboBox cBoxIDPelicula;
        private ComboBox cBoxIDSala;
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