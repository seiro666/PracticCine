
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace PracticCine
{
    public partial class TipoBoleto : Form
    {
        private bool Editar = false;
        private String conexion = "";

        public TipoBoleto()
        {
            InitializeComponent();

            conexion = @"Server=DESKTOP-1FP15IR;Database=Cine;Integrated Security=True;TrustServerCertificate=True;";

            dgvTpoBoleto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTpoBoleto.MultiSelect = false;
            dgvTpoBoleto.AllowUserToAddRows = false;

            dgvTpoBoleto.SelectionChanged += dgvTpoBoleto_SelectionChanged;

            CambiarEstado(false);
            ObtenerDatosBD();
            CargarFilaSeleccionada();
        }

        private void ObtenerDatosBD()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta = "SELECT * FROM dbo.TipoBoleto";

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(consulta, sqlConn))
                    {
                        DataTable dtTipoBoleto = new DataTable();
                        adapter.Fill(dtTipoBoleto);

                        dgvTpoBoleto.DataSource = dtTipoBoleto;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void CambiarEstado(bool habilitar)
        {
            txtIDTipoBoleto.Enabled = false;

            txtClave.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;
            txtPrecio.Enabled = habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
            btnObtenerDatos.Enabled = !habilitar;
            btnSalir.Enabled = !habilitar;

            dgvTpoBoleto.Enabled = !habilitar;
        }

        private void LimpiarCampos()
        {
            txtIDTipoBoleto.Text = "0";
            txtClave.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
        }

        private void ObtenerSiguienteID()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    sqlConn.Open();

                    String consulta = @"
                        SELECT CONVERT(INT,
                            IDENT_CURRENT('dbo.TipoBoleto') +
                            IDENT_INCR('dbo.TipoBoleto'))";

                    using (SqlCommand comando =
                        new SqlCommand(consulta, sqlConn))
                    {
                        int siguienteID =
                            Convert.ToInt32(comando.ExecuteScalar());

                        txtIDTipoBoleto.Text = siguienteID.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al obtener el siguiente ID: " + ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Editar = false;

            LimpiarCampos();
            ObtenerSiguienteID();

            CambiarEstado(true);
            txtClave.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvTpoBoleto.SelectedRows.Count != 1 ||
                dgvTpoBoleto.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Selecciona un tipo de boleto para editar.");
                return;
            }

            Editar = true;

            CargarFilaSeleccionada();
            CambiarEstado(true);

            txtClave.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Ingresa la clave del tipo de boleto.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Ingresa la descripción del tipo de boleto.");
                return;
            }

            decimal precio;

            string textoPrecio = txtPrecio.Text.Trim();

            bool precioValido =
                decimal.TryParse(
                    textoPrecio,
                    NumberStyles.Number,
                    CultureInfo.CurrentCulture,
                    out precio);

            if (!precioValido)
            {
                precioValido = decimal.TryParse(
                    textoPrecio,
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out precio);
            }

            if (!precioValido)
            {
                MessageBox.Show("El precio debe ser un número válido.");
                return;
            }

            if (precio < 0)
            {
                MessageBox.Show("El precio no puede ser negativo.");
                return;
            }

            if (precio > 99999999.99m)
            {
                MessageBox.Show("El precio excede el máximo permitido.");
                return;
            }

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    sqlConn.Open();

                    String consulta;

                    if (Editar == false)
                    {
                        consulta =
                            "INSERT INTO dbo.TipoBoleto " +
                            "(Clave, Descripcion, Precio) " +
                            "VALUES (@Clave, @Descripcion, @Precio)";
                    }
                    else
                    {
                        consulta =
                            "UPDATE dbo.TipoBoleto SET " +
                            "Clave = @Clave, " +
                            "Descripcion = @Descripcion, " +
                            "Precio = @Precio " +
                            "WHERE IDTipoBoleto = @IDTipoBoleto";
                    }

                    using (SqlCommand comando =
                        new SqlCommand(consulta, sqlConn))
                    {
                        comando.Parameters.Add(
                            "@Clave", SqlDbType.VarChar).Value =
                            txtClave.Text.Trim();

                        comando.Parameters.Add(
                            "@Descripcion", SqlDbType.VarChar).Value =
                            txtDescripcion.Text.Trim();

                        SqlParameter parametroPrecio =
                            comando.Parameters.Add(
                                "@Precio", SqlDbType.Decimal);

                        parametroPrecio.Precision = 10;
                        parametroPrecio.Scale = 2;
                        parametroPrecio.Value = precio;

                        if (Editar == true)
                        {
                            comando.Parameters.Add(
                                "@IDTipoBoleto", SqlDbType.Int).Value =
                                Convert.ToInt32(txtIDTipoBoleto.Text);
                        }

                        int renglonesAfectados =
                            comando.ExecuteNonQuery();

                        if (renglonesAfectados == 1)
                        {
                            if (Editar == false)
                            {
                                MessageBox.Show(
                                    "Tipo de boleto registrado correctamente.");
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Tipo de boleto actualizado correctamente.");
                            }

                            Editar = false;
                            CambiarEstado(false);
                            ObtenerDatosBD();
                            CargarFilaSeleccionada();
                        }
                        else
                        {
                            MessageBox.Show("No se realizó la operación.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTpoBoleto.SelectedRows.Count != 1 ||
                dgvTpoBoleto.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show(
                    "Selecciona un tipo de boleto para eliminar.");
                return;
            }

            int idTipoBoleto = Convert.ToInt32(
                dgvTpoBoleto.SelectedRows[0]
                .Cells["IDTipoBoleto"].Value);

            DialogResult resultado = MessageBox.Show(
                "¿Seguro deseas eliminar el tipo de boleto?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    sqlConn.Open();

                    String consulta =
                        "DELETE FROM dbo.TipoBoleto " +
                        "WHERE IDTipoBoleto = @IDTipoBoleto";

                    using (SqlCommand comando =
                        new SqlCommand(consulta, sqlConn))
                    {
                        comando.Parameters.Add(
                            "@IDTipoBoleto", SqlDbType.Int).Value =
                            idTipoBoleto;

                        int renglonesAfectados =
                            comando.ExecuteNonQuery();

                        if (renglonesAfectados >= 1)
                        {
                            MessageBox.Show(
                                "Tipo de boleto eliminado correctamente.");

                            ObtenerDatosBD();
                            CargarFilaSeleccionada();
                        }
                        else
                        {
                            MessageBox.Show(
                                "No existe un tipo de boleto con ese ID.");
                        }
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show(
                    "No se puede eliminar este tipo de boleto " +
                    "porque tiene registros relacionados.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Deseas cancelar la operación?",
                "Cancelar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Editar = false;
                CambiarEstado(false);
                ObtenerDatosBD();
                CargarFilaSeleccionada();
            }
        }

        private void btnObtenerDatos_Click(object sender, EventArgs e)
        {
            ObtenerDatosBD();
            CargarFilaSeleccionada();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTpoBoleto_SelectionChanged(
            object sender, EventArgs e)
        {
            if (!dgvTpoBoleto.Enabled || Editar)
                return;

            CargarFilaSeleccionada();
        }

        private void CargarFilaSeleccionada()
        {
            if (dgvTpoBoleto.SelectedRows.Count == 0 ||
                dgvTpoBoleto.SelectedRows[0].IsNewRow)
            {
                LimpiarCampos();
                return;
            }

            DataGridViewRow fila =
                dgvTpoBoleto.SelectedRows[0];

            txtIDTipoBoleto.Text =
                fila.Cells["IDTipoBoleto"].Value?.ToString() ?? "";

            txtClave.Text =
                fila.Cells["Clave"].Value?.ToString() ?? "";

            txtDescripcion.Text =
                fila.Cells["Descripcion"].Value?.ToString() ?? "";

            txtPrecio.Text =
                fila.Cells["Precio"].Value?.ToString() ?? "";
        }
    }
}
