
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace PracticCine
{
    public partial class Sucursal : Form
    {
        private bool Editar = false;
        private String conexion = "";

        public Sucursal()
        {
            InitializeComponent();

            conexion = @"Server=DESKTOP-1FP15IR;Database=Cine;Integrated Security=True;TrustServerCertificate=True;";

            dgvSucursal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSucursal.MultiSelect = false;
            dgvSucursal.AllowUserToAddRows = false;

            llenaComboIDCiudad();
            ObtenerDatosBD();
            CambiarEstado(false);

            dgvSucursal.SelectionChanged += dgvSucursal_SelectionChanged;

            CargarFilaSeleccionada();
        }

        private void ObtenerDatosBD()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta = "SELECT * FROM dbo.Sucursal";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable dtSucursal = new DataTable();

                    adapter.Fill(dtSucursal);
                    dgvSucursal.DataSource = dtSucursal;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void llenaComboIDCiudad()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta =
                        "SELECT IDCiudad, NombreCiudad FROM dbo.Ciudad";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable datos = new DataTable();

                    adapter.Fill(datos);

                    cBoxIDCiudad.DisplayMember = "NombreCiudad";
                    cBoxIDCiudad.ValueMember = "IDCiudad";
                    cBoxIDCiudad.DataSource = datos;
                    cBoxIDCiudad.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void CambiarEstado(bool habilitar)
        {
            txtIDSucursal.Enabled = false;

            txtNombreSucursal.Enabled = habilitar;
            txtDireccion.Enabled = habilitar;
            cBoxIDCiudad.Enabled = habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
            btnObtenerDatos.Enabled = !habilitar;
            btnSalir.Enabled = !habilitar;

            dgvSucursal.Enabled = !habilitar;
        }

        private void LimpiarCampos()
        {
            txtIDSucursal.Text = "0";
            txtNombreSucursal.Text = "";
            txtDireccion.Text = "";
            cBoxIDCiudad.SelectedIndex = -1;
        }

        private void ObtenerSiguienteID()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    sqlConn.Open();

                    String consulta = @"
                        SELECT
                            CASE
                                WHEN EXISTS (
                                    SELECT 1 FROM dbo.Sucursal
                                )
                                THEN CONVERT(INT,
                                    IDENT_CURRENT('dbo.Sucursal') +
                                    IDENT_INCR('dbo.Sucursal'))
                                ELSE CONVERT(INT,
                                    IDENT_SEED('dbo.Sucursal'))
                            END";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);

                    int siguienteID =
                        Convert.ToInt32(comando.ExecuteScalar());

                    txtIDSucursal.Text = siguienteID.ToString();
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
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvSucursal.SelectedRows.Count != 1 ||
                dgvSucursal.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Selecciona una sucursal para editar.");
                return;
            }

            Editar = true;

            CargarFilaSeleccionada();
            CambiarEstado(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreSucursal.Text))
            {
                MessageBox.Show("Ingresa el nombre de la sucursal.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Ingresa la dirección de la sucursal.");
                return;
            }

            if (cBoxIDCiudad.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona una ciudad.");
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
                            "INSERT INTO dbo.Sucursal " +
                            "(Nombre, Direccion, IDCiudad) " +
                            "VALUES (@Nombre, @Direccion, @IDCiudad)";
                    }
                    else
                    {
                        consulta =
                            "UPDATE dbo.Sucursal SET " +
                            "Nombre = @Nombre, " +
                            "Direccion = @Direccion, " +
                            "IDCiudad = @IDCiudad " +
                            "WHERE IDSucursal = @IDSucursal";
                    }

                    SqlCommand comando =
                        new SqlCommand(consulta, sqlConn);

                    comando.Parameters.Add(
                        "@Nombre", SqlDbType.VarChar).Value =
                        txtNombreSucursal.Text.Trim();

                    comando.Parameters.Add(
                        "@Direccion", SqlDbType.VarChar).Value =
                        txtDireccion.Text.Trim();

                    comando.Parameters.Add(
                        "@IDCiudad", SqlDbType.Int).Value =
                        Convert.ToInt32(cBoxIDCiudad.SelectedValue);

                    if (Editar == true)
                    {
                        comando.Parameters.Add(
                            "@IDSucursal", SqlDbType.Int).Value =
                            Convert.ToInt32(txtIDSucursal.Text);
                    }

                    int renglonesAfectados =
                        comando.ExecuteNonQuery();

                    if (renglonesAfectados == 1)
                    {
                        if (Editar == false)
                        {
                            MessageBox.Show(
                                "Sucursal registrada correctamente.");
                        }
                        else
                        {
                            MessageBox.Show(
                                "Sucursal actualizada correctamente.");
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
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvSucursal.SelectedRows.Count != 1 ||
                dgvSucursal.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Selecciona una sucursal para eliminar.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Seguro deseas eliminar la sucursal?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                int idSucursal = Convert.ToInt32(
                    dgvSucursal.SelectedRows[0]
                    .Cells["IDSucursal"].Value);

                try
                {
                    using (SqlConnection sqlConn = new SqlConnection(conexion))
                    {
                        sqlConn.Open();

                        String consulta =
                            "DELETE FROM dbo.Sucursal " +
                            "WHERE IDSucursal = @IDSucursal";

                        SqlCommand comando =
                            new SqlCommand(consulta, sqlConn);

                        comando.Parameters.Add(
                            "@IDSucursal", SqlDbType.Int).Value =
                            idSucursal;

                        int renglonesAfectados =
                            comando.ExecuteNonQuery();

                        if (renglonesAfectados >= 1)
                        {
                            MessageBox.Show(
                                "Sucursal eliminada correctamente.");

                            ObtenerDatosBD();
                            CargarFilaSeleccionada();
                        }
                        else
                        {
                            MessageBox.Show(
                                "No existe una sucursal con ese ID.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepción: " + ex.Message);
                }
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
            llenaComboIDCiudad();
            ObtenerDatosBD();
            CargarFilaSeleccionada();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSucursal_SelectionChanged(
            object sender, EventArgs e)
        {
            if (dgvSucursal.Enabled == false)
                return;

            CargarFilaSeleccionada();
        }

        private void CargarFilaSeleccionada()
        {
            if (dgvSucursal.SelectedRows.Count == 0 ||
                dgvSucursal.SelectedRows[0].IsNewRow)
            {
                LimpiarCampos();
                return;
            }

            DataGridViewRow fila =
                dgvSucursal.SelectedRows[0];

            txtIDSucursal.Text =
                fila.Cells["IDSucursal"].Value?.ToString() ?? "";

            txtNombreSucursal.Text =
                fila.Cells["Nombre"].Value?.ToString() ?? "";

            txtDireccion.Text =
                fila.Cells["Direccion"].Value?.ToString() ?? "";

            if (fila.Cells["IDCiudad"].Value != null &&
                fila.Cells["IDCiudad"].Value != DBNull.Value)
            {
                cBoxIDCiudad.SelectedValue =
                    Convert.ToInt32(fila.Cells["IDCiudad"].Value);
            }
            else
            {
                cBoxIDCiudad.SelectedIndex = -1;
            }
        }
    }
}
