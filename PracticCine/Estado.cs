
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace PracticCine
{
    public partial class Estado : Form
    {
        private bool Editar = false;
        private String conexion = "";
        private SqlConnection sqlConnection = null;

        public Estado()
        {
            InitializeComponent();

            conexion = @"Server=DESKTOP-1FP15IR;Database=Cine;Integrated Security=True;TrustServerCertificate=True;";
            sqlConnection = new SqlConnection(conexion);

            dgvEstado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEstado.MultiSelect = false;
            dgvEstado.AllowUserToAddRows = false;

            ObtenerDatosBD();
            CambiarEstado(false);

            dgvEstado.SelectionChanged += dgvEstado_SelectionChanged;
        }

        private void ObtenerDatosBD()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta = "SELECT * FROM dbo.Estado";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable dtEstado = new DataTable();

                    adapter.Fill(dtEstado);
                    dgvEstado.DataSource = dtEstado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void CambiarEstado(bool habilitar)
        {
            txtIDEstado.Enabled = false;

            txtClaveEstado.Enabled = habilitar;
            txtNombreEstado.Enabled = habilitar;
            txtSiglasEstado.Enabled = habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
            btnObtenerDatos.Enabled = !habilitar;
            btnSalir.Enabled = !habilitar;

            dgvEstado.Enabled = !habilitar;
        }

        private void LimpiarCampos()
        {
            txtIDEstado.Text = "0";
            txtClaveEstado.Text = "";
            txtNombreEstado.Text = "";
            txtSiglasEstado.Text = "";
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
                            IDENT_CURRENT('dbo.Estado') +
                            IDENT_INCR('dbo.Estado'))";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);

                    int siguienteID =
                        Convert.ToInt32(comando.ExecuteScalar());

                    txtIDEstado.Text = siguienteID.ToString();
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
            if (dgvEstado.SelectedRows.Count != 1 ||
                dgvEstado.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Selecciona un estado para editar.");
                return;
            }

            Editar = true;

            DataGridViewRow fila = dgvEstado.SelectedRows[0];

            txtIDEstado.Text =
                fila.Cells["IDEstado"].Value.ToString();

            txtClaveEstado.Text =
                fila.Cells["ClaveEstado"].Value?.ToString() ?? "";

            txtNombreEstado.Text =
                fila.Cells["NombreEstado"].Value?.ToString() ?? "";

            txtSiglasEstado.Text =
                fila.Cells["SiglasEstado"].Value?.ToString() ?? "";

            CambiarEstado(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClaveEstado.Text) ||
                string.IsNullOrWhiteSpace(txtNombreEstado.Text) ||
                string.IsNullOrWhiteSpace(txtSiglasEstado.Text))
            {
                MessageBox.Show("Completa todos los campos.");
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
                            "INSERT INTO dbo.Estado " +
                            "(ClaveEstado, NombreEstado, SiglaEstado) " +
                            "VALUES (@ClaveEstado, @NombreEstado, @SiglaEstado)";
                    }
                    else
                    {
                        consulta =
                            "UPDATE dbo.Estado SET " +
                            "ClaveEstado = @ClaveEstado, " +
                            "NombreEstado = @NombreEstado, " +
                            "SiglaEstado = @SiglaEstado " +
                            "WHERE IDEstado = @IDEstado";
                    }

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);

                    comando.Parameters.Add("@ClaveEstado", SqlDbType.VarChar).Value =
                        txtClaveEstado.Text.Trim();

                    comando.Parameters.Add("@NombreEstado", SqlDbType.VarChar).Value =
                        txtNombreEstado.Text.Trim();

                    comando.Parameters.Add("@SiglaEstado", SqlDbType.VarChar).Value =
                        txtSiglasEstado.Text.Trim();

                    if (Editar == true)
                    {
                        comando.Parameters.Add("@IDEstado", SqlDbType.Int).Value =
                            Convert.ToInt32(txtIDEstado.Text);
                    }

                    int renglonesAfectados = comando.ExecuteNonQuery();

                    if (renglonesAfectados == 1)
                    {
                        if (Editar == false)
                        {
                            MessageBox.Show("Estado registrado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Estado actualizado correctamente.");
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
            if (dgvEstado.SelectedRows.Count != 1 ||
                dgvEstado.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Selecciona un estado para eliminar.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Seguro deseas eliminar el estado?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                int idEstado = Convert.ToInt32(
                    dgvEstado.SelectedRows[0]
                    .Cells["IDEstado"].Value);

                try
                {
                    using (SqlConnection sqlConn = new SqlConnection(conexion))
                    {
                        sqlConn.Open();

                        String consulta =
                            "DELETE FROM dbo.Estado WHERE IDEstado = @IDEstado";

                        SqlCommand comando = new SqlCommand(consulta, sqlConn);

                        comando.Parameters.Add("@IDEstado", SqlDbType.Int).Value =
                            idEstado;

                        int renglonesAfectados = comando.ExecuteNonQuery();

                        if (renglonesAfectados >= 1)
                        {
                            MessageBox.Show("Estado eliminado correctamente.");
                            ObtenerDatosBD();
                        }
                        else
                        {
                            MessageBox.Show("No existe un estado con ese ID.");
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

        private void dgvEstado_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEstado.Enabled == false)
                return;

            if (dgvEstado.SelectedRows.Count >= 1 &&
                !dgvEstado.SelectedRows[0].IsNewRow)
            {
                DataGridViewRow fila = dgvEstado.SelectedRows[0];

                txtIDEstado.Text =
                    fila.Cells["IDEstado"].Value.ToString();

                txtClaveEstado.Text =
                    fila.Cells["ClaveEstado"].Value?.ToString() ?? "";

                txtNombreEstado.Text =
                    fila.Cells["NombreEstado"].Value?.ToString() ?? "";

                txtSiglasEstado.Text =
                    fila.Cells["SiglaEstado"].Value?.ToString() ?? "";
            }
        }
    }
}
