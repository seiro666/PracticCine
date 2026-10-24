
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace PracticCine
{
    public partial class CiudadEstado : Form
    {
        private bool Editar = false;

        private String conexion = "";
        private SqlConnection sqlConnection = null;

        public CiudadEstado()
        {
            InitializeComponent();

            conexion = @"Server=DESKTOP-1FP15IR;Database=Cine;Integrated Security=True;TrustServerCertificate=True;";
            sqlConnection = new SqlConnection(conexion);

            dgvCiudadEstado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCiudadEstado.MultiSelect = false;
            dgvCiudadEstado.AllowUserToAddRows = false;

            llenaComboIDEstado();
            ObtenerDatosBD();
            CambiarEstado(false);

            dgvCiudadEstado.SelectionChanged += dgvCiudadEstado_SelectionChanged;
        }

        private void ObtenerDatosBD()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta = "SELECT * FROM dbo.Ciudad";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable dtCiudad = new DataTable();

                    adapter.Fill(dtCiudad);
                    dgvCiudadEstado.DataSource = dtCiudad;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void llenaComboIDEstado()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta =
                        "SELECT IDEstado, NombreEstado FROM dbo.Estado";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable datos = new DataTable();

                    adapter.Fill(datos);

                    cBoxIDEstado.DisplayMember = "NombreEstado";
                    cBoxIDEstado.ValueMember = "IDEstado";
                    cBoxIDEstado.DataSource = datos;
                    cBoxIDEstado.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void CambiarEstado(bool habilitar)
        {
            txtIDCiudad.Enabled = false;

            txtNombreCiudad.Enabled = habilitar;
            txtClaveCiudad.Enabled = habilitar;
            txtSiglasCiudad.Enabled = habilitar;
            cBoxIDEstado.Enabled = habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
            btnObtenerDatos.Enabled = !habilitar;
            btnSalir.Enabled = !habilitar;

            dgvCiudadEstado.Enabled = !habilitar;
        }

        private void LimpiarCampos()
        {
            txtIDCiudad.Text = "0";
            txtNombreCiudad.Text = "";
            txtClaveCiudad.Text = "";
            txtSiglasCiudad.Text = "";
            cBoxIDEstado.SelectedIndex = -1;
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
                            IDENT_CURRENT('dbo.Ciudad') +
                            IDENT_INCR('dbo.Ciudad'))";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);

                    int siguienteID =
                        Convert.ToInt32(comando.ExecuteScalar());

                    txtIDCiudad.Text = siguienteID.ToString();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCiudad.Text) ||
                string.IsNullOrWhiteSpace(txtClaveCiudad.Text) ||
                string.IsNullOrWhiteSpace(txtSiglasCiudad.Text))
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            if (cBoxIDEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un estado.");
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
                            "INSERT INTO dbo.Ciudad " +
                            "(NombreCiudad, ClaveCiudad, SiglasCiudad, IDEstado) " +
                            "VALUES (@NombreCiudad, @ClaveCiudad, @SiglasCiudad, @IDEstado)";
                    }
                    else
                    {
                        consulta =
                            "UPDATE dbo.Ciudad SET " +
                            "NombreCiudad = @NombreCiudad, " +
                            "ClaveCiudad = @ClaveCiudad, " +
                            "SiglasCiudad = @SiglasCiudad, " +
                            "IDEstado = @IDEstado " +
                            "WHERE IDCiudad = @IDCiudad";
                    }

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);

                    comando.Parameters.Add("@NombreCiudad", SqlDbType.VarChar).Value =
                        txtNombreCiudad.Text.Trim();

                    comando.Parameters.Add("@ClaveCiudad", SqlDbType.VarChar).Value =
                        txtClaveCiudad.Text.Trim();

                    comando.Parameters.Add("@SiglasCiudad", SqlDbType.VarChar).Value =
                        txtSiglasCiudad.Text.Trim();

                    comando.Parameters.Add("@IDEstado", SqlDbType.Int).Value =
                        Convert.ToInt32(cBoxIDEstado.SelectedValue);

                    if (Editar == true)
                    {
                        comando.Parameters.Add("@IDCiudad", SqlDbType.Int).Value =
                            Convert.ToInt32(txtIDCiudad.Text);
                    }

                    int renglonesAfectados = comando.ExecuteNonQuery();

                    if (renglonesAfectados == 1)
                    {
                        if (Editar == false)
                        {
                            MessageBox.Show("Ciudad registrada correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Ciudad actualizada correctamente.");
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCiudadEstado.SelectedRows.Count != 1 ||
                dgvCiudadEstado.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Selecciona una ciudad para editar.");
                return;
            }

            Editar = true;

            DataGridViewRow fila = dgvCiudadEstado.SelectedRows[0];

            txtIDCiudad.Text =
                fila.Cells["IDCiudad"].Value.ToString();

            txtNombreCiudad.Text =
                fila.Cells["NombreCiudad"].Value.ToString();

            txtClaveCiudad.Text =
                fila.Cells["ClaveCiudad"].Value.ToString();

            txtSiglasCiudad.Text =
                fila.Cells["SiglasCiudad"].Value.ToString();

            cBoxIDEstado.SelectedValue =
                Convert.ToInt32(fila.Cells["IDEstado"].Value);

            CambiarEstado(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCiudadEstado.SelectedRows.Count != 1 ||
                dgvCiudadEstado.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Selecciona una ciudad para eliminar.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Seguro deseas eliminar la ciudad?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                int idCiudad = Convert.ToInt32(
                    dgvCiudadEstado.SelectedRows[0]
                    .Cells["IDCiudad"].Value);

                try
                {
                    using (SqlConnection sqlConn = new SqlConnection(conexion))
                    {
                        sqlConn.Open();

                        String consulta =
                            "DELETE FROM dbo.Ciudad WHERE IDCiudad = @IDCiudad";

                        SqlCommand comando = new SqlCommand(consulta, sqlConn);

                        comando.Parameters.Add("@IDCiudad", SqlDbType.Int).Value =
                            idCiudad;

                        int renglonesAfectados = comando.ExecuteNonQuery();

                        if (renglonesAfectados >= 1)
                        {
                            MessageBox.Show("Ciudad eliminada correctamente.");
                            ObtenerDatosBD();
                        }
                        else
                        {
                            MessageBox.Show("No existe una ciudad con ese ID.");
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

        private void dgvCiudadEstado_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCiudadEstado.Enabled == false)
                return;

            if (dgvCiudadEstado.SelectedRows.Count >= 1 &&
                !dgvCiudadEstado.SelectedRows[0].IsNewRow)
            {
                DataGridViewRow fila =
                    dgvCiudadEstado.SelectedRows[0];

                txtIDCiudad.Text =
                    fila.Cells["IDCiudad"].Value.ToString();

                txtNombreCiudad.Text =
                    fila.Cells["NombreCiudad"].Value?.ToString() ?? "";

                txtClaveCiudad.Text =
                    fila.Cells["ClaveCiudad"].Value?.ToString() ?? "";

                txtSiglasCiudad.Text =
                    fila.Cells["SiglasCiudad"].Value?.ToString() ?? "";

                if (fila.Cells["IDEstado"].Value != DBNull.Value)
                {
                    cBoxIDEstado.SelectedValue =
                        Convert.ToInt32(fila.Cells["IDEstado"].Value);
                }
                else
                {
                    cBoxIDEstado.SelectedIndex = -1;
                }
            }
        }

        private void cBoxIDEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
