namespace PracticCine
{
    partial class VP
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            clasificacionToolStripMenuItem = new ToolStripMenuItem();
            generoToolStripMenuItem = new ToolStripMenuItem();
            peliculaToolStripMenuItem = new ToolStripMenuItem();
            sucursalToolStripMenuItem = new ToolStripMenuItem();
            salaToolStripMenuItem = new ToolStripMenuItem();
            tipoBoletoToolStripMenuItem = new ToolStripMenuItem();
            ciudadYEstadoToolStripMenuItem = new ToolStripMenuItem();
            estadoToolStripMenuItem = new ToolStripMenuItem();
            funcionToolStripMenuItem = new ToolStripMenuItem();
            clienteToolStripMenuItem = new ToolStripMenuItem();
            ventaToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { clasificacionToolStripMenuItem, generoToolStripMenuItem, peliculaToolStripMenuItem, sucursalToolStripMenuItem, salaToolStripMenuItem, tipoBoletoToolStripMenuItem, ciudadYEstadoToolStripMenuItem, estadoToolStripMenuItem, funcionToolStripMenuItem, clienteToolStripMenuItem, ventaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // clasificacionToolStripMenuItem
            // 
            clasificacionToolStripMenuItem.Name = "clasificacionToolStripMenuItem";
            clasificacionToolStripMenuItem.Size = new Size(86, 20);
            clasificacionToolStripMenuItem.Text = "Clasificacion";
            clasificacionToolStripMenuItem.Click += clasificacionToolStripMenuItem_Click;
            // 
            // generoToolStripMenuItem
            // 
            generoToolStripMenuItem.Name = "generoToolStripMenuItem";
            generoToolStripMenuItem.Size = new Size(57, 20);
            generoToolStripMenuItem.Text = "Genero";
            generoToolStripMenuItem.Click += generoToolStripMenuItem_Click;
            // 
            // peliculaToolStripMenuItem
            // 
            peliculaToolStripMenuItem.Name = "peliculaToolStripMenuItem";
            peliculaToolStripMenuItem.Size = new Size(60, 20);
            peliculaToolStripMenuItem.Text = "Pelicula";
            peliculaToolStripMenuItem.Click += peliculaToolStripMenuItem_Click;
            // 
            // sucursalToolStripMenuItem
            // 
            sucursalToolStripMenuItem.Name = "sucursalToolStripMenuItem";
            sucursalToolStripMenuItem.Size = new Size(63, 20);
            sucursalToolStripMenuItem.Text = "Sucursal";
            sucursalToolStripMenuItem.Click += sucursalToolStripMenuItem_Click;
            // 
            // salaToolStripMenuItem
            // 
            salaToolStripMenuItem.Name = "salaToolStripMenuItem";
            salaToolStripMenuItem.Size = new Size(40, 20);
            salaToolStripMenuItem.Text = "Sala";
            salaToolStripMenuItem.Click += salaToolStripMenuItem_Click;
            // 
            // tipoBoletoToolStripMenuItem
            // 
            tipoBoletoToolStripMenuItem.Name = "tipoBoletoToolStripMenuItem";
            tipoBoletoToolStripMenuItem.Size = new Size(79, 20);
            tipoBoletoToolStripMenuItem.Text = "Tipo Boleto";
            tipoBoletoToolStripMenuItem.Click += tipoBoletoToolStripMenuItem_Click;
            // 
            // ciudadYEstadoToolStripMenuItem
            // 
            ciudadYEstadoToolStripMenuItem.Name = "ciudadYEstadoToolStripMenuItem";
            ciudadYEstadoToolStripMenuItem.Size = new Size(57, 20);
            ciudadYEstadoToolStripMenuItem.Text = "Ciudad";
            ciudadYEstadoToolStripMenuItem.Click += ciudadYEstadoToolStripMenuItem_Click;
            // 
            // estadoToolStripMenuItem
            // 
            estadoToolStripMenuItem.Name = "estadoToolStripMenuItem";
            estadoToolStripMenuItem.Size = new Size(54, 20);
            estadoToolStripMenuItem.Text = "Estado";
            estadoToolStripMenuItem.Click += estadoToolStripMenuItem_Click;
            // 
            // funcionToolStripMenuItem
            // 
            funcionToolStripMenuItem.Name = "funcionToolStripMenuItem";
            funcionToolStripMenuItem.Size = new Size(62, 20);
            funcionToolStripMenuItem.Text = "Funcion";
            funcionToolStripMenuItem.Click += funcionToolStripMenuItem_Click;
            // 
            // clienteToolStripMenuItem
            // 
            clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            clienteToolStripMenuItem.Size = new Size(56, 20);
            clienteToolStripMenuItem.Text = "Cliente";
            clienteToolStripMenuItem.Click += clienteToolStripMenuItem_Click;
            // 
            // ventaToolStripMenuItem
            // 
            ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            ventaToolStripMenuItem.Size = new Size(48, 20);
            ventaToolStripMenuItem.Text = "Venta";
            ventaToolStripMenuItem.Click += ventaToolStripMenuItem_Click;
            // 
            // VP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "VP";
            Text = "Ventana Principal Cine @Miguelon";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem clasificacionToolStripMenuItem;
        private ToolStripMenuItem generoToolStripMenuItem;
        private ToolStripMenuItem peliculaToolStripMenuItem;
        private ToolStripMenuItem sucursalToolStripMenuItem;
        private ToolStripMenuItem salaToolStripMenuItem;
        private ToolStripMenuItem tipoBoletoToolStripMenuItem;
        private ToolStripMenuItem ciudadYEstadoToolStripMenuItem;
        private ToolStripMenuItem funcionToolStripMenuItem;
        private ToolStripMenuItem clienteToolStripMenuItem;
        private ToolStripMenuItem ventaToolStripMenuItem;
        private ToolStripMenuItem estadoToolStripMenuItem;
    }
}
