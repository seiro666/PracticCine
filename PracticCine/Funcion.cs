
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace PracticCine
{
    public partial class Funcion : Form
    {
        private bool Editar = false;
        private String conexion = "";
        private SqlConnection sqlConnection = null;

        public Funcion()
        {
            InitializeComponent();

            conexion = @"Server=DESKTOP-1FP15IR;Database=Cine;Integrated Security=True;TrustServerCertificate=True;";
            sqlConnection = new SqlConnection(conexion);

            dgvFuncion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFuncion.MultiSelect = false;

            llenaComboIDPelicula();
            llenaComboIDSala();
            ObtenerDatosBD();
            CambiarEstado(false);
        }

        private void ObtenerDatosBD()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta = "SELECT IDFuncion, IDPelicula, IDSala, Fecha, Hora FROM dbo.Funcion";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable dtFuncion = new DataTable();

                    adapter.Fill(dtFuncion);
                    dgvFuncion.DataSource = dtFuncion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void llenaComboIDPelicula()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta = "SELECT IDPelicula, NombrePelicula FROM dbo.Pelicula";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable datos = new DataTable();

                    adapter.Fill(datos);

                    cBoxIDPelicula.DisplayMember = "NombrePelicula";
                    cBoxIDPelicula.ValueMember = "IDPelicula";
                    cBoxIDPelicula.DataSource = datos;
                    cBoxIDPelicula.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void llenaComboIDSala()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta = "SELECT IDSala, NumeroSala FROM dbo.Sala";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable datos = new DataTable();

                    adapter.Fill(datos);

                    cBoxIDSala.DisplayMember = "NumeroSala";
                    cBoxIDSala.ValueMember = "IDSala";
                    cBoxIDSala.DataSource = datos;
                    cBoxIDSala.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void CambiarEstado(bool habilitar)
        {
            txtIDFuncion.Enabled = false;

            txtHora.Enabled = habilitar;
            dtFecha.Enabled = habilitar;
            cBoxIDPelicula.Enabled = habilitar;
            cBoxIDSala.Enabled = habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
            btnObtenerDatos.Enabled = !habilitar;
            btnSalir.Enabled = !habilitar;

            dgvFuncion.Enabled = !habilitar;
        }

        private void LimpiarCampos()
        {
            txtIDFuncion.Text = "0";
            txtHora.Text = "";
            dtFecha.Value = DateTime.Today;
            cBoxIDPelicula.SelectedIndex = -1;
            cBoxIDSala.SelectedIndex = -1;
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
            if (cBoxIDPelicula.SelectedIndex == -1 ||
                cBoxIDSala.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona una película y una sala.");
                return;
            }

            int hora;

            if (!int.TryParse(txtHora.Text, out hora))
            {
                MessageBox.Show("Ingresa una hora numérica. Ejemplo: 1230");
                return;
            }

            if (hora < 0 || hora > 2359 || hora % 100 >= 60)
            {
                MessageBox.Show("La hora no es válida. Ejemplo: 1430");
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
                        consulta = "INSERT INTO dbo.Funcion " +
                                   "(IDPelicula, IDSala, Fecha, Hora) " +
                                   "VALUES (@IDPelicula, @IDSala, @Fecha, @Hora)";
                    }
                    else
                    {
                        consulta = "UPDATE dbo.Funcion SET " +
                                   "IDPelicula = @IDPelicula, " +
                                   "IDSala = @IDSala, " +
                                   "Fecha = @Fecha, " +
                                   "Hora = @Hora " +
                                   "WHERE IDFuncion = @IDFuncion";
                    }

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);

                    comando.Parameters.Add("@IDPelicula", SqlDbType.Int).Value =
                        Convert.ToInt32(cBoxIDPelicula.SelectedValue);

                    comando.Parameters.Add("@IDSala", SqlDbType.Int).Value =
                        Convert.ToInt32(cBoxIDSala.SelectedValue);

                    comando.Parameters.Add("@Fecha", SqlDbType.Date).Value =
                        dtFecha.Value.Date;

                    comando.Parameters.Add("@Hora", SqlDbType.Int).Value = hora;

                    if (Editar == true)
                    {
                        comando.Parameters.Add("@IDFuncion", SqlDbType.Int).Value =
                            Convert.ToInt32(txtIDFuncion.Text);
                    }

                    int renglonesAfectados = comando.ExecuteNonQuery();

                    if (renglonesAfectados == 1)
                    {
                        if (Editar == false)
                        {
                            MessageBox.Show("Éxito al registrar la función.");
                        }
                        else
                        {
                            MessageBox.Show("Éxito al actualizar la función.");
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
            if (dgvFuncion.SelectedRows.Count != 1)
            {
                MessageBox.Show("Selecciona una función para editar.");
                return;
            }

            Editar = true;

            DataGridViewRow fila = dgvFuncion.SelectedRows[0];

            txtIDFuncion.Text = fila.Cells["IDFuncion"].Value.ToString();

            cBoxIDPelicula.SelectedValue =
                Convert.ToInt32(fila.Cells["IDPelicula"].Value);

            cBoxIDSala.SelectedValue =
                Convert.ToInt32(fila.Cells["IDSala"].Value);

            dtFecha.Value =
                Convert.ToDateTime(fila.Cells["Fecha"].Value);

            txtHora.Text = fila.Cells["Hora"].Value.ToString();

            CambiarEstado(true);

            txtIDFuncion.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvFuncion.SelectedRows.Count != 1 ||
                dgvFuncion.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Selecciona una función para eliminar.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Seguro deseas eliminar la función?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                int idFuncion = Convert.ToInt32(
                    dgvFuncion.SelectedRows[0].Cells["IDFuncion"].Value);

                try
                {
                    using (SqlConnection sqlConn = new SqlConnection(conexion))
                    {
                        sqlConn.Open();

                        String consulta =
                            "DELETE FROM dbo.Funcion WHERE IDFuncion = @IDFuncion";

                        SqlCommand comando = new SqlCommand(consulta, sqlConn);

                        comando.Parameters.Add("@IDFuncion", SqlDbType.Int).Value =
                            idFuncion;

                        int renglonesAfectados = comando.ExecuteNonQuery();

                        if (renglonesAfectados >= 1)
                        {
                            MessageBox.Show("Función eliminada correctamente.");
                            ObtenerDatosBD();
                        }
                        else
                        {
                            MessageBox.Show("No existe una función con ese ID.");
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

        private void dgvFuncion_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFuncion.Enabled == false)
                return;

            if (dgvFuncion.SelectedRows.Count >= 1 &&
                !dgvFuncion.SelectedRows[0].IsNewRow)
            {
                DataGridViewRow fila = dgvFuncion.SelectedRows[0];

                txtIDFuncion.Text =
                    fila.Cells["IDFuncion"].Value.ToString();

                if (fila.Cells["IDPelicula"].Value != DBNull.Value)
                {
                    cBoxIDPelicula.SelectedValue =
                        Convert.ToInt32(fila.Cells["IDPelicula"].Value);
                }

                if (fila.Cells["IDSala"].Value != DBNull.Value)
                {
                    cBoxIDSala.SelectedValue =
                        Convert.ToInt32(fila.Cells["IDSala"].Value);
                }

                if (fila.Cells["Fecha"].Value != DBNull.Value)
                {
                    dtFecha.Value =
                        Convert.ToDateTime(fila.Cells["Fecha"].Value);
                }
                else
                {
                    dtFecha.Value = DateTime.Today;
                }

                if (fila.Cells["Hora"].Value != DBNull.Value)
                {
                    txtHora.Text = fila.Cells["Hora"].Value.ToString();
                }
                else
                {
                    txtHora.Text = "";
                }
            }
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
                    IDENT_CURRENT('dbo.Funcion') +
                    IDENT_INCR('dbo.Funcion'))";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);

                    int siguienteID = Convert.ToInt32(comando.ExecuteScalar());

                    txtIDFuncion.Text = siguienteID.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el siguiente ID: " + ex.Message);
            }
        }

        private void Funcion_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void txtIDCiudadS_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
