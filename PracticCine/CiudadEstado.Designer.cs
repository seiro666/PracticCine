namespace PracticCine
{
    partial class CiudadEstado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CiudadEstado));
            txtClaveCiudad = new TextBox();
            txtIDCiudad = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtSiglasCiudad = new TextBox();
            label4 = new Label();
            dgvCiudadEstado = new DataGridView();
            txtNombreCiudad = new TextBox();
            label5 = new Label();
            label6 = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            cBoxIDEstado = new ComboBox();
            toolStrip1 = new ToolStrip();
            btnNuevo = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnEliminar = new ToolStripButton();
            btnGuardar = new ToolStripButton();
            btnCancelar = new ToolStripButton();
            btnObtenerDatos = new ToolStripButton();
            btnSalir = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)dgvCiudadEstado).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtClaveCiudad
            // 
            txtClaveCiudad.Location = new Point(427, 432);
            txtClaveCiudad.Name = "txtClaveCiudad";
            txtClaveCiudad.Size = new Size(100, 23);
            txtClaveCiudad.TabIndex = 71;
            // 
            // txtIDCiudad
            // 
            txtIDCiudad.Location = new Point(427, 335);
            txtIDCiudad.Name = "txtIDCiudad";
            txtIDCiudad.Size = new Size(100, 23);
            txtIDCiudad.TabIndex = 69;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(322, 435);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 68;
            label3.Text = "Clave Ciudad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(322, 371);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 67;
            label2.Text = "IDEstado";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(322, 338);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 66;
            label1.Text = "IDCiudad";
            // 
            // txtSiglasCiudad
            // 
            txtSiglasCiudad.Location = new Point(427, 399);
            txtSiglasCiudad.Name = "txtSiglasCiudad";
            txtSiglasCiudad.Size = new Size(100, 23);
            txtSiglasCiudad.TabIndex = 73;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(322, 402);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 72;
            label4.Text = "Siglas Ciudad";
            // 
            // dgvCiudadEstado
            // 
            dgvCiudadEstado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCiudadEstado.Location = new Point(8, 28);
            dgvCiudadEstado.Name = "dgvCiudadEstado";
            dgvCiudadEstado.RowHeadersWidth = 62;
            dgvCiudadEstado.Size = new Size(839, 232);
            dgvCiudadEstado.TabIndex = 64;
            // 
            // txtNombreCiudad
            // 
            txtNombreCiudad.Location = new Point(427, 465);
            txtNombreCiudad.Name = "txtNombreCiudad";
            txtNombreCiudad.Size = new Size(100, 23);
            txtNombreCiudad.TabIndex = 75;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(322, 468);
            label5.Name = "label5";
            label5.Size = new Size(92, 15);
            label5.TabIndex = 74;
            label5.Text = "Nombre Ciudad";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(413, 293);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 76;
            label6.Text = "Ciudad";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // cBoxIDEstado
            // 
            cBoxIDEstado.FormattingEnabled = true;
            cBoxIDEstado.Location = new Point(427, 368);
            cBoxIDEstado.Margin = new Padding(2, 2, 2, 2);
            cBoxIDEstado.Name = "cBoxIDEstado";
            cBoxIDEstado.Size = new Size(129, 23);
            cBoxIDEstado.TabIndex = 86;
            cBoxIDEstado.SelectedIndexChanged += cBoxIDEstado_SelectedIndexChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNuevo, btnEditar, btnEliminar, btnGuardar, btnCancelar, btnObtenerDatos, btnSalir });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 2, 0);
            toolStrip1.Size = new Size(859, 31);
            toolStrip1.TabIndex = 87;
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
            // CiudadEstado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(859, 541);
            Controls.Add(toolStrip1);
            Controls.Add(cBoxIDEstado);
            Controls.Add(label6);
            Controls.Add(txtNombreCiudad);
            Controls.Add(label5);
            Controls.Add(txtClaveCiudad);
            Controls.Add(txtIDCiudad);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSiglasCiudad);
            Controls.Add(label4);
            Controls.Add(dgvCiudadEstado);
            Name = "CiudadEstado";
            Text = "CiudadEstado";
            ((System.ComponentModel.ISupportInitialize)dgvCiudadEstado).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtClaveCiudad;
        private TextBox txtIDCiudad;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtSiglasCiudad;
        private Label label4;
        private DataGridView dgvCiudadEstado;
        private TextBox txtNombreCiudad;
        private Label label5;
        private Label label6;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private ComboBox cBoxIDEstado;
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