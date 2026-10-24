
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace PracticCine
{
    public partial class Sala : Form
    {
        private bool Editar = false;
        private String conexion = "";

        public Sala()
        {
            InitializeComponent();

            conexion = @"Server=DESKTOP-1FP15IR;Database=Cine;Integrated Security=True;TrustServerCertificate=True;";

            dgvSala.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSala.MultiSelect = false;
            dgvSala.AllowUserToAddRows = false;

            llenaComboIDSucursal();
            ObtenerDatosBD();
            CambiarEstado(false);

            dgvSala.SelectionChanged += dgvSala_SelectionChanged;

            CargarFilaSeleccionada();
        }

        private void ObtenerDatosBD()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta = "SELECT * FROM dbo.Sala";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable dtSala = new DataTable();

                    adapter.Fill(dtSala);
                    dgvSala.DataSource = dtSala;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void llenaComboIDSucursal()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta =
                        "SELECT IDSucursal, Nombre FROM dbo.Sucursal";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable datos = new DataTable();

                    adapter.Fill(datos);

                    cBoxIDSucursal.DisplayMember = "Nombre";
                    cBoxIDSucursal.ValueMember = "IDSucursal";
                    cBoxIDSucursal.DataSource = datos;
                    cBoxIDSucursal.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void CambiarEstado(bool habilitar)
        {
            txtIDSala.Enabled = false;

            txtNumeroSala.Enabled = habilitar;
            txtCantidadAsientos.Enabled = habilitar;
            txtTipoSala.Enabled = habilitar;
            cBoxIDSucursal.Enabled = habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
            btnObtenerDatos.Enabled = !habilitar;
            btnSalir.Enabled = !habilitar;

            dgvSala.Enabled = !habilitar;
        }

        private void LimpiarCampos()
        {
            txtIDSala.Text = "0";
            txtNumeroSala.Text = "";
            txtCantidadAsientos.Text = "";
            txtTipoSala.Text = "";
            cBoxIDSucursal.SelectedIndex = -1;
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
                                    SELECT 1 FROM dbo.Sala
                                )
                                THEN CONVERT(INT,
                                    IDENT_CURRENT('dbo.Sala') +
                                    IDENT_INCR('dbo.Sala'))
                                ELSE CONVERT(INT,
                                    IDENT_SEED('dbo.Sala'))
                            END";

                    SqlCommand comando = new SqlCommand(consulta, sqlConn);

                    int siguienteID =
                        Convert.ToInt32(comando.ExecuteScalar());

                    txtIDSala.Text = siguienteID.ToString();
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
            if (dgvSala.SelectedRows.Count != 1 ||
                dgvSala.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Selecciona una sala para editar.");
                return;
            }

            Editar = true;

            CargarFilaSeleccionada();
            CambiarEstado(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int numeroSala;
            int cantidadAsientos;

            if (!int.TryParse(txtNumeroSala.Text, out numeroSala))
            {
                MessageBox.Show("El número de sala debe ser numérico.");
                return;
            }

            if (numeroSala <= 0)
            {
                MessageBox.Show("El número de sala debe ser mayor a cero.");
                return;
            }

            if (!int.TryParse(txtCantidadAsientos.Text, out cantidadAsientos))
            {
                MessageBox.Show("La cantidad de asientos debe ser numérica.");
                return;
            }

            if (cantidadAsientos <= 0)
            {
                MessageBox.Show("La cantidad de asientos debe ser mayor a cero.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTipoSala.Text))
            {
                MessageBox.Show("Ingresa el tipo de sala.");
                return;
            }

            if (cBoxIDSucursal.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona una sucursal.");
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
                            "INSERT INTO dbo.Sala " +
                            "(NumeroSala, CantidadAsientos, TipoSala, IDSucursal) " +
                            "VALUES (@NumeroSala, @CantidadAsientos, @TipoSala, @IDSucursal)";
                    }
                    else
                    {
                        consulta =
                            "UPDATE dbo.Sala SET " +
                            "NumeroSala = @NumeroSala, " +
                            "CantidadAsientos = @CantidadAsientos, " +
                            "TipoSala = @TipoSala, " +
                            "IDSucursal = @IDSucursal " +
                            "WHERE IDSala = @IDSala";
                    }

                    SqlCommand comando =
                        new SqlCommand(consulta, sqlConn);

                    comando.Parameters.Add(
                        "@NumeroSala", SqlDbType.Int).Value =
                        numeroSala;

                    comando.Parameters.Add(
                        "@CantidadAsientos", SqlDbType.Int).Value =
                        cantidadAsientos;

                    comando.Parameters.Add(
                        "@TipoSala", SqlDbType.VarChar).Value =
                        txtTipoSala.Text.Trim();

                    comando.Parameters.Add(
                        "@IDSucursal", SqlDbType.Int).Value =
                        Convert.ToInt32(cBoxIDSucursal.SelectedValue);

                    if (Editar == true)
                    {
                        comando.Parameters.Add(
                            "@IDSala", SqlDbType.Int).Value =
                            Convert.ToInt32(txtIDSala.Text);
                    }

                    int renglonesAfectados =
                        comando.ExecuteNonQuery();

                    if (renglonesAfectados == 1)
                    {
                        if (Editar == false)
                        {
                            MessageBox.Show(
                                "Sala registrada correctamente.");
                        }
                        else
                        {
                            MessageBox.Show(
                                "Sala actualizada correctamente.");
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
            if (dgvSala.SelectedRows.Count != 1 ||
                dgvSala.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Selecciona una sala para eliminar.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Seguro deseas eliminar la sala?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                int idSala = Convert.ToInt32(
                    dgvSala.SelectedRows[0]
                    .Cells["IDSala"].Value);

                try
                {
                    using (SqlConnection sqlConn = new SqlConnection(conexion))
                    {
                        sqlConn.Open();

                        String consulta =
                            "DELETE FROM dbo.Sala " +
                            "WHERE IDSala = @IDSala";

                        SqlCommand comando =
                            new SqlCommand(consulta, sqlConn);

                        comando.Parameters.Add(
                            "@IDSala", SqlDbType.Int).Value =
                            idSala;

                        int renglonesAfectados =
                            comando.ExecuteNonQuery();

                        if (renglonesAfectados >= 1)
                        {
                            MessageBox.Show(
                                "Sala eliminada correctamente.");

                            ObtenerDatosBD();
                            CargarFilaSeleccionada();
                        }
                        else
                        {
                            MessageBox.Show(
                                "No existe una sala con ese ID.");
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
            llenaComboIDSucursal();
            ObtenerDatosBD();
            CargarFilaSeleccionada();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSala_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSala.Enabled == false)
                return;

            CargarFilaSeleccionada();
        }

        private void CargarFilaSeleccionada()
        {
            if (dgvSala.SelectedRows.Count == 0 ||
                dgvSala.SelectedRows[0].IsNewRow)
            {
                LimpiarCampos();
                return;
            }

            DataGridViewRow fila = dgvSala.SelectedRows[0];

            txtIDSala.Text =
                fila.Cells["IDSala"].Value?.ToString() ?? "";

            txtNumeroSala.Text =
                fila.Cells["NumeroSala"].Value?.ToString() ?? "";

            txtCantidadAsientos.Text =
                fila.Cells["CantidadAsientos"].Value?.ToString() ?? "";

            txtTipoSala.Text =
                fila.Cells["TipoSala"].Value?.ToString() ?? "";

            if (fila.Cells["IDSucursal"].Value != null &&
                fila.Cells["IDSucursal"].Value != DBNull.Value)
            {
                cBoxIDSucursal.SelectedValue =
                    Convert.ToInt32(fila.Cells["IDSucursal"].Value);
            }
            else
            {
                cBoxIDSucursal.SelectedIndex = -1;
            }
        }
    }
}
