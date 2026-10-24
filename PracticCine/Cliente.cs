
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace PracticCine
{
    public partial class Cliente : Form
    {
        private bool Editar = false;
        private String conexion = "";
        private SqlConnection sqlConnection = null;

        public Cliente()
        {
            InitializeComponent();

            conexion = @"Server=DESKTOP-1FP15IR;Database=Cine;Integrated Security=True;TrustServerCertificate=True;";
            sqlConnection = new SqlConnection(conexion);

            dgvCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCliente.MultiSelect = false;
            dgvCliente.AllowUserToAddRows = false;

            llenaComboIDCiudad();
            ObtenerDatosBD();
            CambiarEstado(false);

            dgvCliente.SelectionChanged += dgvCliente_SelectionChanged;
        }

        private void ObtenerDatosBD()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta = "SELECT * FROM dbo.Cliente";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable dtCliente = new DataTable();

                    adapter.Fill(dtCliente);
                    dgvCliente.DataSource = dtCliente;
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
            txtIDCliente.Enabled = false;

            txtNombre.Enabled = habilitar;
            txtCorreo.Enabled = habilitar;
            txtCelular.Enabled = habilitar;
            cBoxIDCiudad.Enabled = habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
            btnObtenerDatos.Enabled = !habilitar;
            btnSalir.Enabled = !habilitar;

            dgvCliente.Enabled = !habilitar;
        }

        private void LimpiarCampos()
        {
            txtIDCliente.Text = "0";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtCelular.Text = "";
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
                        SELECT CONVERT(INT,
                            IDENT_CURRENT('dbo.Cliente') +
                            IDENT_INCR('dbo.Cliente'))";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);

                    int siguienteID =
                        Convert.ToInt32(comando.ExecuteScalar());

                    txtIDCliente.Text = siguienteID.ToString();
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
            if (dgvCliente.SelectedRows.Count != 1 ||
                dgvCliente.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Selecciona un cliente para editar.");
                return;
            }

            Editar = true;

            DataGridViewRow fila = dgvCliente.SelectedRows[0];

            txtIDCliente.Text =
                fila.Cells["IDCliente"].Value.ToString();

            txtNombre.Text =
                fila.Cells["Nombre"].Value?.ToString() ?? "";

            txtCorreo.Text =
                fila.Cells["Correo"].Value?.ToString() ?? "";

            txtCelular.Text =
                fila.Cells["Celular"].Value?.ToString() ?? "";

            if (fila.Cells["IDCiudad"].Value != DBNull.Value)
            {
                cBoxIDCiudad.SelectedValue =
                    Convert.ToInt32(fila.Cells["IDCiudad"].Value);
            }
            else
            {
                cBoxIDCiudad.SelectedIndex = -1;
            }

            CambiarEstado(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtCelular.Text))
            {
                MessageBox.Show("Completa todos los campos.");
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
                            "INSERT INTO dbo.Cliente " +
                            "(Nombre, Correo, Celular, IDCiudad) " +
                            "VALUES (@Nombre, @Correo, @Celular, @IDCiudad)";
                    }
                    else
                    {
                        consulta =
                            "UPDATE dbo.Cliente SET " +
                            "Nombre = @Nombre, " +
                            "Correo = @Correo, " +
                            "Celular = @Celular, " +
                            "IDCiudad = @IDCiudad " +
                            "WHERE IDCliente = @IDCliente";
                    }

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);

                    comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value =
                        txtNombre.Text.Trim();

                    comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value =
                        txtCorreo.Text.Trim();

                    comando.Parameters.Add("@Celular", SqlDbType.VarChar).Value =
                        txtCelular.Text.Trim();

                    comando.Parameters.Add("@IDCiudad", SqlDbType.Int).Value =
                        Convert.ToInt32(cBoxIDCiudad.SelectedValue);

                    if (Editar == true)
                    {
                        comando.Parameters.Add("@IDCliente", SqlDbType.Int).Value =
                            Convert.ToInt32(txtIDCliente.Text);
                    }

                    int renglonesAfectados = comando.ExecuteNonQuery();

                    if (renglonesAfectados == 1)
                    {
                        if (Editar == false)
                        {
                            MessageBox.Show("Cliente registrado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Cliente actualizado correctamente.");
                        }

                        Editar = false;
                        CambiarEstado(false);
                        ObtenerDatosBD();
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
            if (dgvCliente.SelectedRows.Count != 1 ||
                dgvCliente.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Selecciona un cliente para eliminar.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Seguro deseas eliminar el cliente?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                int idCliente = Convert.ToInt32(
                    dgvCliente.SelectedRows[0]
                    .Cells["IDCliente"].Value);

                try
                {
                    using (SqlConnection sqlConn = new SqlConnection(conexion))
                    {
                        sqlConn.Open();

                        String consulta =
                            "DELETE FROM dbo.Cliente WHERE IDCliente = @IDCliente";

                        SqlCommand comando = new SqlCommand(consulta, sqlConn);

                        comando.Parameters.Add("@IDCliente", SqlDbType.Int).Value =
                            idCliente;

                        int renglonesAfectados = comando.ExecuteNonQuery();

                        if (renglonesAfectados >= 1)
                        {
                            MessageBox.Show("Cliente eliminado correctamente.");
                            ObtenerDatosBD();
                        }
                        else
                        {
                            MessageBox.Show("No existe un cliente con ese ID.");
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
            }
        }

        private void btnObtenerDatos_Click(object sender, EventArgs e)
        {
            ObtenerDatosBD();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCliente_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCliente.Enabled == false)
                return;

            if (dgvCliente.SelectedRows.Count >= 1 &&
                !dgvCliente.SelectedRows[0].IsNewRow)
            {
                DataGridViewRow fila = dgvCliente.SelectedRows[0];

                txtIDCliente.Text =
                    fila.Cells["IDCliente"].Value.ToString();

                txtNombre.Text =
                    fila.Cells["Nombre"].Value?.ToString() ?? "";

                txtCorreo.Text =
                    fila.Cells["Correo"].Value?.ToString() ?? "";

                txtCelular.Text =
                    fila.Cells["Celular"].Value?.ToString() ?? "";

                if (fila.Cells["IDCiudad"].Value != DBNull.Value)
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
}
