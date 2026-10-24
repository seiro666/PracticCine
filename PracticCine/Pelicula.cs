
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace PracticCine
{
    public partial class Pelicula : Form
    {
        private bool Editar = false;
        private String conexion = "";

        public Pelicula()
        {
            InitializeComponent();

            conexion = @"Server=DESKTOP-1FP15IR;Database=Cine;Integrated Security=True;TrustServerCertificate=True;";

            dgvPelicula.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPelicula.MultiSelect = false;
            dgvPelicula.AllowUserToAddRows = false;

            llenaComboIDClasificacion();
            llenaComboIDGenero();
            ObtenerDatosBD();
            CambiarEstado(false);

            dgvPelicula.SelectionChanged += dgvPelicula_SelectionChanged;

            CargarFilaSeleccionada();
        }

        private void ObtenerDatosBD()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta = "SELECT * FROM dbo.Pelicula";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable dtPelicula = new DataTable();

                    adapter.Fill(dtPelicula);
                    dgvPelicula.DataSource = dtPelicula;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void llenaComboIDClasificacion()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta =
                        "SELECT IDClasificacion, Clave FROM dbo.Clasificacion";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable datos = new DataTable();

                    adapter.Fill(datos);

                    cBoxIDClasificacion.DisplayMember = "Clave";
                    cBoxIDClasificacion.ValueMember = "IDClasificacion";
                    cBoxIDClasificacion.DataSource = datos;
                    cBoxIDClasificacion.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void llenaComboIDGenero()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta =
                        "SELECT IDGenero, NombreGenero FROM dbo.Genero";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable datos = new DataTable();

                    adapter.Fill(datos);

                    cBoxIDGenero.DisplayMember = "NombreGenero";
                    cBoxIDGenero.ValueMember = "IDGenero";
                    cBoxIDGenero.DataSource = datos;
                    cBoxIDGenero.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void CambiarEstado(bool habilitar)
        {
            txtIDPelicula.Enabled = false;

            txtNombrePelicula.Enabled = habilitar;
            txtDuracion.Enabled = habilitar;
            cBoxIDClasificacion.Enabled = habilitar;
            cBoxIDGenero.Enabled = habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
            btnObtenerDatos.Enabled = !habilitar;
            btnSalir.Enabled = !habilitar;

            dgvPelicula.Enabled = !habilitar;
        }

        private void LimpiarCampos()
        {
            txtIDPelicula.Text = "0";
            txtNombrePelicula.Text = "";
            txtDuracion.Text = "";
            cBoxIDClasificacion.SelectedIndex = -1;
            cBoxIDGenero.SelectedIndex = -1;
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
                                    SELECT 1 FROM dbo.Pelicula
                                )
                                THEN CONVERT(INT,
                                    IDENT_CURRENT('dbo.Pelicula') +
                                    IDENT_INCR('dbo.Pelicula'))
                                ELSE CONVERT(INT,
                                    IDENT_SEED('dbo.Pelicula'))
                            END";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);

                    int siguienteID =
                        Convert.ToInt32(comando.ExecuteScalar());

                    txtIDPelicula.Text = siguienteID.ToString();
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
            if (dgvPelicula.SelectedRows.Count != 1 ||
                dgvPelicula.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Selecciona una película para editar.");
                return;
            }

            Editar = true;

            CargarFilaSeleccionada();
            CambiarEstado(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombrePelicula.Text))
            {
                MessageBox.Show("Ingresa el nombre de la película.");
                return;
            }

            int duracion;

            if (!int.TryParse(txtDuracion.Text, out duracion))
            {
                MessageBox.Show("La duración debe ser numérica.");
                return;
            }

            if (duracion <= 0)
            {
                MessageBox.Show("La duración debe ser mayor a cero.");
                return;
            }

            if (cBoxIDClasificacion.SelectedIndex == -1 ||
                cBoxIDGenero.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Selecciona una clasificación y un género.");
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
                            "INSERT INTO dbo.Pelicula " +
                            "(NombrePelicula, Duracion, IDClasificacion, IDGenero) " +
                            "VALUES (@NombrePelicula, @Duracion, @IDClasificacion, @IDGenero)";
                    }
                    else
                    {
                        consulta =
                            "UPDATE dbo.Pelicula SET " +
                            "NombrePelicula = @NombrePelicula, " +
                            "Duracion = @Duracion, " +
                            "IDClasificacion = @IDClasificacion, " +
                            "IDGenero = @IDGenero " +
                            "WHERE IDPelicula = @IDPelicula";
                    }

                    SqlCommand comando =
                        new SqlCommand(consulta, sqlConn);

                    comando.Parameters.Add(
                        "@NombrePelicula", SqlDbType.VarChar).Value =
                        txtNombrePelicula.Text.Trim();

                    comando.Parameters.Add(
                        "@Duracion", SqlDbType.Int).Value =
                        duracion;

                    comando.Parameters.Add(
                        "@IDClasificacion", SqlDbType.Int).Value =
                        Convert.ToInt32(cBoxIDClasificacion.SelectedValue);

                    comando.Parameters.Add(
                        "@IDGenero", SqlDbType.Int).Value =
                        Convert.ToInt32(cBoxIDGenero.SelectedValue);

                    if (Editar == true)
                    {
                        comando.Parameters.Add(
                            "@IDPelicula", SqlDbType.Int).Value =
                            Convert.ToInt32(txtIDPelicula.Text);
                    }

                    int renglonesAfectados =
                        comando.ExecuteNonQuery();

                    if (renglonesAfectados == 1)
                    {
                        if (Editar == false)
                        {
                            MessageBox.Show(
                                "Película registrada correctamente.");
                        }
                        else
                        {
                            MessageBox.Show(
                                "Película actualizada correctamente.");
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
            if (dgvPelicula.SelectedRows.Count != 1 ||
                dgvPelicula.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Selecciona una película para eliminar.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Seguro deseas eliminar la película?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                int idPelicula = Convert.ToInt32(
                    dgvPelicula.SelectedRows[0]
                    .Cells["IDPelicula"].Value);

                try
                {
                    using (SqlConnection sqlConn = new SqlConnection(conexion))
                    {
                        sqlConn.Open();

                        String consulta =
                            "DELETE FROM dbo.Pelicula " +
                            "WHERE IDPelicula = @IDPelicula";

                        SqlCommand comando =
                            new SqlCommand(consulta, sqlConn);

                        comando.Parameters.Add(
                            "@IDPelicula", SqlDbType.Int).Value =
                            idPelicula;

                        int renglonesAfectados =
                            comando.ExecuteNonQuery();

                        if (renglonesAfectados >= 1)
                        {
                            MessageBox.Show(
                                "Película eliminada correctamente.");

                            ObtenerDatosBD();
                            CargarFilaSeleccionada();
                        }
                        else
                        {
                            MessageBox.Show(
                                "No existe una película con ese ID.");
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
            ObtenerDatosBD();
            CargarFilaSeleccionada();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPelicula_SelectionChanged(
            object sender, EventArgs e)
        {
            if (dgvPelicula.Enabled == false)
                return;

            CargarFilaSeleccionada();
        }

        private void CargarFilaSeleccionada()
        {
            if (dgvPelicula.SelectedRows.Count == 0 ||
                dgvPelicula.SelectedRows[0].IsNewRow)
            {
                LimpiarCampos();
                return;
            }

            DataGridViewRow fila =
                dgvPelicula.SelectedRows[0];

            txtIDPelicula.Text =
                fila.Cells["IDPelicula"].Value?.ToString() ?? "";

            txtNombrePelicula.Text =
                fila.Cells["NombrePelicula"].Value?.ToString() ?? "";

            txtDuracion.Text =
                fila.Cells["Duracion"].Value?.ToString() ?? "";

            if (fila.Cells["IDClasificacion"].Value != null &&
                fila.Cells["IDClasificacion"].Value != DBNull.Value)
            {
                cBoxIDClasificacion.SelectedValue =
                    Convert.ToInt32(fila.Cells["IDClasificacion"].Value);
            }
            else
            {
                cBoxIDClasificacion.SelectedIndex = -1;
            }

            if (fila.Cells["IDGenero"].Value != null &&
                fila.Cells["IDGenero"].Value != DBNull.Value)
            {
                cBoxIDGenero.SelectedValue =
                    Convert.ToInt32(fila.Cells["IDGenero"].Value);
            }
            else
            {
                cBoxIDGenero.SelectedIndex = -1;
            }
        }
    }
}
