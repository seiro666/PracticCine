namespace PracticCine
{
    partial class Estado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Estado));
            txtNombreEstado = new TextBox();
            txtSiglasEstado = new TextBox();
            txtIDEstado = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtClaveEstado = new TextBox();
            label12 = new Label();
            label7 = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            dgvEstado = new DataGridView();
            toolStrip1 = new ToolStrip();
            btnNuevo = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnEliminar = new ToolStripButton();
            btnGuardar = new ToolStripButton();
            btnCancelar = new ToolStripButton();
            btnObtenerDatos = new ToolStripButton();
            btnSalir = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)dgvEstado).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtNombreEstado
            // 
            txtNombreEstado.Location = new Point(350, 433);
            txtNombreEstado.Name = "txtNombreEstado";
            txtNombreEstado.Size = new Size(100, 23);
            txtNombreEstado.TabIndex = 105;
            // 
            // txtSiglasEstado
            // 
            txtSiglasEstado.Location = new Point(350, 364);
            txtSiglasEstado.Name = "txtSiglasEstado";
            txtSiglasEstado.Size = new Size(100, 23);
            txtSiglasEstado.TabIndex = 104;
            // 
            // txtIDEstado
            // 
            txtIDEstado.Location = new Point(350, 331);
            txtIDEstado.Name = "txtIDEstado";
            txtIDEstado.Size = new Size(100, 23);
            txtIDEstado.TabIndex = 103;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(246, 436);
            label9.Name = "label9";
            label9.Size = new Size(89, 15);
            label9.TabIndex = 102;
            label9.Text = "Nombre Estado";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(246, 367);
            label10.Name = "label10";
            label10.Size = new Size(75, 15);
            label10.TabIndex = 101;
            label10.Text = "Siglas Estado";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(246, 334);
            label11.Name = "label11";
            label11.Size = new Size(53, 15);
            label11.TabIndex = 100;
            label11.Text = "IDEstado";
            // 
            // txtClaveEstado
            // 
            txtClaveEstado.Location = new Point(350, 398);
            txtClaveEstado.Name = "txtClaveEstado";
            txtClaveEstado.Size = new Size(100, 23);
            txtClaveEstado.TabIndex = 107;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(246, 401);
            label12.Name = "label12";
            label12.Size = new Size(74, 15);
            label12.TabIndex = 106;
            label12.Text = "Clave Estado";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(337, 289);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 99;
            label7.Text = "Estado";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // dgvEstado
            // 
            dgvEstado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEstado.Location = new Point(12, 34);
            dgvEstado.Name = "dgvEstado";
            dgvEstado.RowHeadersWidth = 62;
            dgvEstado.Size = new Size(839, 232);
            dgvEstado.TabIndex = 87;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNuevo, btnEditar, btnEliminar, btnGuardar, btnCancelar, btnObtenerDatos, btnSalir });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 2, 0);
            toolStrip1.Size = new Size(855, 31);
            toolStrip1.TabIndex = 108;
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
            // Estado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 518);
            Controls.Add(toolStrip1);
            Controls.Add(txtNombreEstado);
            Controls.Add(txtSiglasEstado);
            Controls.Add(txtIDEstado);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(txtClaveEstado);
            Controls.Add(label12);
            Controls.Add(label7);
            Controls.Add(dgvEstado);
            Margin = new Padding(2);
            Name = "Estado";
            Text = "Estado";
            ((System.ComponentModel.ISupportInitialize)dgvEstado).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombreEstado;
        private TextBox txtSiglasEstado;
        private TextBox txtIDEstado;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txtClaveEstado;
        private Label label12;
        private Label label7;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private DataGridView dgvEstado;
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