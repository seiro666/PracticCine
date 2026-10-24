
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace PracticCine
{
    public partial class Clasificacion : Form
    {
        private bool Editar = false;
        private String conexion = "";
        private SqlConnection sqlConnection = null;

        public Clasificacion()
        {
            InitializeComponent();

            conexion = @"Server=DESKTOP-1FP15IR;Database=Cine;Integrated Security=True;TrustServerCertificate=True;";
            sqlConnection = new SqlConnection(conexion);

            dgvClasificacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClasificacion.MultiSelect = false;
            dgvClasificacion.AllowUserToAddRows = false;

            ObtenerDatosBD();
            CambiarEstado(false);

            dgvClasificacion.SelectionChanged += dgvClasificacion_SelectionChanged;
        }

        private void ObtenerDatosBD()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta =
                        "SELECT * FROM dbo.Clasificacion";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable dtClasificacion = new DataTable();

                    adapter.Fill(dtClasificacion);
                    dgvClasificacion.DataSource = dtClasificacion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void CambiarEstado(bool habilitar)
        {
            txtIDClasificacion.Enabled = false;

            txtClave.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
            btnObtenerDatos.Enabled = !habilitar;
            btnSalir.Enabled = !habilitar;

            dgvClasificacion.Enabled = !habilitar;
        }

        private void LimpiarCampos()
        {
            txtIDClasificacion.Text = "0";
            txtClave.Text = "";
            txtDescripcion.Text = "";
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
                            IDENT_CURRENT('dbo.Clasificacion') +
                            IDENT_INCR('dbo.Clasificacion'))";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);

                    int siguienteID =
                        Convert.ToInt32(comando.ExecuteScalar());

                    txtIDClasificacion.Text = siguienteID.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al obtener el siguiente ID: " + ex.Message);
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            Editar = false;

            LimpiarCampos();
            ObtenerSiguienteID();

            CambiarEstado(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClasificacion.SelectedRows.Count != 1 ||
                dgvClasificacion.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Selecciona una clasificación para editar.");
                return;
            }

            Editar = true;

            DataGridViewRow fila =
                dgvClasificacion.SelectedRows[0];

            txtIDClasificacion.Text =
                fila.Cells["IDClasificacion"].Value.ToString();

            txtClave.Text =
                fila.Cells["Clave"].Value?.ToString() ?? "";

            txtDescripcion.Text =
                fila.Cells["Descripcion"].Value?.ToString() ?? "";

            CambiarEstado(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClave.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text))
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
                            "INSERT INTO dbo.Clasificacion " +
                            "(Clave, Descripcion) " +
                            "VALUES (@Clave, @Descripcion)";
                    }
                    else
                    {
                        consulta =
                            "UPDATE dbo.Clasificacion SET " +
                            "Clave = @Clave, " +
                            "Descripcion = @Descripcion " +
                            "WHERE IDClasificacion = @IDClasificacion";
                    }

                    SqlCommand comando =
                        new SqlCommand(consulta, sqlConn);

                    comando.Parameters.Add("@Clave", SqlDbType.VarChar).Value =
                        txtClave.Text.Trim();

                    comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value =
                        txtDescripcion.Text.Trim();

                    if (Editar == true)
                    {
                        comando.Parameters.Add(
                            "@IDClasificacion", SqlDbType.Int).Value =
                            Convert.ToInt32(txtIDClasificacion.Text);
                    }

                    int renglonesAfectados =
                        comando.ExecuteNonQuery();

                    if (renglonesAfectados == 1)
                    {
                        if (Editar == false)
                        {
                            MessageBox.Show(
                                "Clasificación registrada correctamente.");
                        }
                        else
                        {
                            MessageBox.Show(
                                "Clasificación actualizada correctamente.");
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
            if (dgvClasificacion.SelectedRows.Count != 1 ||
                dgvClasificacion.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show(
                    "Selecciona una clasificación para eliminar.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Seguro deseas eliminar la clasificación?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                int idClasificacion = Convert.ToInt32(
                    dgvClasificacion.SelectedRows[0]
                    .Cells["IDClasificacion"].Value);

                try
                {
                    using (SqlConnection sqlConn =
                        new SqlConnection(conexion))
                    {
                        sqlConn.Open();

                        String consulta =
                            "DELETE FROM dbo.Clasificacion " +
                            "WHERE IDClasificacion = @IDClasificacion";

                        SqlCommand comando =
                            new SqlCommand(consulta, sqlConn);

                        comando.Parameters.Add(
                            "@IDClasificacion", SqlDbType.Int).Value =
                            idClasificacion;

                        int renglonesAfectados =
                            comando.ExecuteNonQuery();

                        if (renglonesAfectados >= 1)
                        {
                            MessageBox.Show(
                                "Clasificación eliminada correctamente.");

                            ObtenerDatosBD();
                        }
                        else
                        {
                            MessageBox.Show(
                                "No existe una clasificación con ese ID.");
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

        private void dgvClasificacion_SelectionChanged(
            object sender, EventArgs e)
        {
            if (dgvClasificacion.Enabled == false)
                return;

            if (dgvClasificacion.SelectedRows.Count >= 1 &&
                !dgvClasificacion.SelectedRows[0].IsNewRow)
            {
                DataGridViewRow fila =
                    dgvClasificacion.SelectedRows[0];

                txtIDClasificacion.Text =
                    fila.Cells["IDClasificacion"].Value.ToString();

                txtClave.Text =
                    fila.Cells["Clave"].Value?.ToString() ?? "";

                txtDescripcion.Text =
                    fila.Cells["Descripcion"].Value?.ToString() ?? "";
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnNuevo_Click_1(sender, e);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            ObtenerDatosBD();
        }

        private void dataGridView1_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(
            object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
