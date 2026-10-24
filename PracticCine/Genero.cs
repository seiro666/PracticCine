
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace PracticCine
{
    public partial class Genero : Form
    {
        private bool Editar = false;
        private String conexion = "";

        public Genero()
        {
            InitializeComponent();

            conexion = @"Server=DESKTOP-1FP15IR;Database=Cine;Integrated Security=True;TrustServerCertificate=True;";

            dgvGenero.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGenero.MultiSelect = false;
            dgvGenero.AllowUserToAddRows = false;

            ObtenerDatosBD();
            CambiarEstado(false);

            dgvGenero.SelectionChanged += dgvGenero_SelectionChanged;
        }

        private void ObtenerDatosBD()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta = "SELECT * FROM dbo.Genero";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable dtGenero = new DataTable();

                    adapter.Fill(dtGenero);
                    dgvGenero.DataSource = dtGenero;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void CambiarEstado(bool habilitar)
        {
            txtIDGenero.Enabled = false;

            txtNombreGenero.Enabled = habilitar;
            txtDescripcionGenero.Enabled = habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
            btnObtenerDatos.Enabled = !habilitar;
            btnSalir.Enabled = !habilitar;

            dgvGenero.Enabled = !habilitar;
        }

        private void LimpiarCampos()
        {
            txtIDGenero.Text = "0";
            txtNombreGenero.Text = "";
            txtDescripcionGenero.Text = "";
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
                            IDENT_CURRENT('dbo.Genero') +
                            IDENT_INCR('dbo.Genero'))";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);

                    int siguienteID =
                        Convert.ToInt32(comando.ExecuteScalar());

                    txtIDGenero.Text = siguienteID.ToString();
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
            if (dgvGenero.SelectedRows.Count != 1 ||
                dgvGenero.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Selecciona un género para editar.");
                return;
            }

            Editar = true;

            DataGridViewRow fila = dgvGenero.SelectedRows[0];

            txtIDGenero.Text =
                fila.Cells["IDGenero"].Value.ToString();

            txtNombreGenero.Text =
                fila.Cells["NombreGenero"].Value?.ToString() ?? "";

            txtDescripcionGenero.Text =
                fila.Cells["DescripcionGenero"].Value?.ToString() ?? "";

            CambiarEstado(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreGenero.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcionGenero.Text))
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
                            "INSERT INTO dbo.Genero " +
                            "(NombreGenero, DescripcionGenero) " +
                            "VALUES (@NombreGenero, @DescripcionGenero)";
                    }
                    else
                    {
                        consulta =
                            "UPDATE dbo.Genero SET " +
                            "NombreGenero = @NombreGenero, " +
                            "DescripcionGenero = @DescripcionGenero " +
                            "WHERE IDGenero = @IDGenero";
                    }

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);

                    comando.Parameters.Add("@NombreGenero", SqlDbType.VarChar).Value =
                        txtNombreGenero.Text.Trim();

                    comando.Parameters.Add("@DescripcionGenero", SqlDbType.VarChar).Value =
                        txtDescripcionGenero.Text.Trim();

                    if (Editar == true)
                    {
                        comando.Parameters.Add("@IDGenero", SqlDbType.Int).Value =
                            Convert.ToInt32(txtIDGenero.Text);
                    }

                    int renglonesAfectados = comando.ExecuteNonQuery();

                    if (renglonesAfectados == 1)
                    {
                        if (Editar == false)
                        {
                            MessageBox.Show("Género registrado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Género actualizado correctamente.");
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
            if (dgvGenero.SelectedRows.Count != 1 ||
                dgvGenero.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Selecciona un género para eliminar.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Seguro deseas eliminar el género?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                int idGenero = Convert.ToInt32(
                    dgvGenero.SelectedRows[0]
                    .Cells["IDGenero"].Value);

                try
                {
                    using (SqlConnection sqlConn = new SqlConnection(conexion))
                    {
                        sqlConn.Open();

                        String consulta =
                            "DELETE FROM dbo.Genero WHERE IDGenero = @IDGenero";

                        SqlCommand comando = new SqlCommand(consulta, sqlConn);

                        comando.Parameters.Add("@IDGenero", SqlDbType.Int).Value =
                            idGenero;

                        int renglonesAfectados = comando.ExecuteNonQuery();

                        if (renglonesAfectados >= 1)
                        {
                            MessageBox.Show("Género eliminado correctamente.");
                            ObtenerDatosBD();
                        }
                        else
                        {
                            MessageBox.Show("No existe un género con ese ID.");
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

        private void dgvGenero_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGenero.Enabled == false)
                return;

            if (dgvGenero.SelectedRows.Count >= 1 &&
                !dgvGenero.SelectedRows[0].IsNewRow)
            {
                DataGridViewRow fila = dgvGenero.SelectedRows[0];

                txtIDGenero.Text =
                    fila.Cells["IDGenero"].Value.ToString();

                txtNombreGenero.Text =
                    fila.Cells["NombreGenero"].Value?.ToString() ?? "";

                txtDescripcionGenero.Text =
                    fila.Cells["DescripcionGenero"].Value?.ToString() ?? "";
            }
        }
    }
}
