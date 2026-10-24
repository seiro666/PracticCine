
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace PracticCine
{
    public partial class Venta : Form
    {
        private bool Editar = false;
        private String conexion = "";

        public Venta()
        {
            InitializeComponent();

            conexion = @"Server=DESKTOP-1FP15IR;Database=Cine;Integrated Security=True;TrustServerCertificate=True;";

            dgvVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVenta.MultiSelect = false;
            dgvVenta.AllowUserToAddRows = false;

            cBoxIDCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxIDFuncion.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxIDTipoBoleto.DropDownStyle = ComboBoxStyle.DropDownList;

            dgvVenta.SelectionChanged += dgvVenta_SelectionChanged;

            CambiarEstado(false);

            llenaComboIDCliente();
            llenaComboIDFuncion();
            llenaComboIDTipoBoleto();

            ObtenerDatosBD();
            CargarFilaSeleccionada();
        }

        private void ObtenerDatosBD()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta = "SELECT * FROM dbo.Venta";

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(consulta, sqlConn))
                    {
                        DataTable dtVenta = new DataTable();
                        adapter.Fill(dtVenta);
                        dgvVenta.DataSource = dtVenta;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void llenaComboIDCliente()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta =
                        "SELECT IDCliente, Nombre FROM dbo.Cliente";

                    SqlDataAdapter adapter =
                        new SqlDataAdapter(consulta, sqlConn);

                    DataTable datos = new DataTable();
                    adapter.Fill(datos);

                    cBoxIDCliente.DisplayMember = "Nombre";
                    cBoxIDCliente.ValueMember = "IDCliente";
                    cBoxIDCliente.DataSource = datos;
                    cBoxIDCliente.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void llenaComboIDFuncion()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta = @"
                        SELECT
                            F.IDFuncion,
                            CONCAT(
                                'Función ', F.IDFuncion,
                                ' - ', P.NombrePelicula
                            ) AS DescripcionFuncion
                        FROM dbo.Funcion AS F
                        INNER JOIN dbo.Pelicula AS P
                            ON F.IDPelicula = P.IDPelicula
                        ORDER BY F.IDFuncion";

                    SqlDataAdapter adapter =
                        new SqlDataAdapter(consulta, sqlConn);

                    DataTable datos = new DataTable();
                    adapter.Fill(datos);

                    cBoxIDFuncion.DisplayMember = "DescripcionFuncion";
                    cBoxIDFuncion.ValueMember = "IDFuncion";
                    cBoxIDFuncion.DataSource = datos;
                    cBoxIDFuncion.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void llenaComboIDTipoBoleto()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(conexion))
                {
                    String consulta =
                        "SELECT IDTipoBoleto, Clave FROM dbo.TipoBoleto";

                    SqlDataAdapter adapter =
                        new SqlDataAdapter(consulta, sqlConn);

                    DataTable datos = new DataTable();
                    adapter.Fill(datos);

                    cBoxIDTipoBoleto.DisplayMember = "Clave";
                    cBoxIDTipoBoleto.ValueMember = "IDTipoBoleto";
                    cBoxIDTipoBoleto.DataSource = datos;
                    cBoxIDTipoBoleto.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void CambiarEstado(bool habilitar)
        {
            txtIDVenta.Enabled = false;

            txtPrecio.Enabled = habilitar;
            cBoxIDCliente.Enabled = habilitar;
            cBoxIDFuncion.Enabled = habilitar;
            cBoxIDTipoBoleto.Enabled = habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
            btnObtenerDatos.Enabled = !habilitar;
            btnSalir.Enabled = !habilitar;

            dgvVenta.Enabled = !habilitar;
        }

        private void LimpiarCampos()
        {
            txtIDVenta.Text = "0";
            txtPrecio.Text = "";

            cBoxIDCliente.SelectedIndex = -1;
            cBoxIDFuncion.SelectedIndex = -1;
            cBoxIDTipoBoleto.SelectedIndex = -1;
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
                                    SELECT 1 FROM dbo.Venta
                                )
                                THEN CONVERT(INT,
                                    IDENT_CURRENT('dbo.Venta') +
                                    IDENT_INCR('dbo.Venta'))
                                ELSE CONVERT(INT,
                                    IDENT_SEED('dbo.Venta'))
                            END";

                    using (SqlCommand comando =
                        new SqlCommand(consulta, sqlConn))
                    {
                        int siguienteID =
                            Convert.ToInt32(comando.ExecuteScalar());

                        txtIDVenta.Text = siguienteID.ToString();
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
            txtPrecio.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvVenta.SelectedRows.Count != 1 ||
                dgvVenta.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Selecciona una venta para editar.");
                return;
            }

            Editar = true;

            CargarFilaSeleccionada();
            CambiarEstado(true);

            txtPrecio.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            decimal precio;

            bool precioValido = decimal.TryParse(
                txtPrecio.Text.Trim(),
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out precio);

            if (!precioValido)
            {
                precioValido = decimal.TryParse(
                    txtPrecio.Text.Trim(),
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out precio);
            }

            if (!precioValido)
            {
                MessageBox.Show("Ingresa un precio válido.");
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

            if (cBoxIDCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un cliente.");
                return;
            }

            if (cBoxIDFuncion.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona una función.");
                return;
            }

            if (cBoxIDTipoBoleto.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un tipo de boleto.");
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
                            "INSERT INTO dbo.Venta " +
                            "(Precio, IDCliente, IDFuncion, IDTipoBoleto) " +
                            "VALUES (@Precio, @IDCliente, @IDFuncion, @IDTipoBoleto)";
                    }
                    else
                    {
                        consulta =
                            "UPDATE dbo.Venta SET " +
                            "Precio = @Precio, " +
                            "IDCliente = @IDCliente, " +
                            "IDFuncion = @IDFuncion, " +
                            "IDTipoBoleto = @IDTipoBoleto " +
                            "WHERE IDVenta = @IDVenta";
                    }

                    using (SqlCommand comando =
                        new SqlCommand(consulta, sqlConn))
                    {
                        SqlParameter parametroPrecio =
                            comando.Parameters.Add(
                                "@Precio", SqlDbType.Decimal);

                        parametroPrecio.Precision = 10;
                        parametroPrecio.Scale = 2;
                        parametroPrecio.Value = precio;

                        comando.Parameters.Add(
                            "@IDCliente", SqlDbType.Int).Value =
                            Convert.ToInt32(cBoxIDCliente.SelectedValue);

                        comando.Parameters.Add(
                            "@IDFuncion", SqlDbType.Int).Value =
                            Convert.ToInt32(cBoxIDFuncion.SelectedValue);

                        comando.Parameters.Add(
                            "@IDTipoBoleto", SqlDbType.Int).Value =
                            Convert.ToInt32(cBoxIDTipoBoleto.SelectedValue);

                        if (Editar == true)
                        {
                            comando.Parameters.Add(
                                "@IDVenta", SqlDbType.Int).Value =
                                Convert.ToInt32(txtIDVenta.Text);
                        }

                        int renglonesAfectados =
                            comando.ExecuteNonQuery();

                        if (renglonesAfectados == 1)
                        {
                            if (Editar == false)
                            {
                                MessageBox.Show(
                                    "Venta registrada correctamente.");
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Venta actualizada correctamente.");
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
            if (dgvVenta.SelectedRows.Count != 1 ||
                dgvVenta.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Selecciona una venta para eliminar.");
                return;
            }

            int idVenta = Convert.ToInt32(
                dgvVenta.SelectedRows[0]
                .Cells["IDVenta"].Value);

            DialogResult resultado = MessageBox.Show(
                "¿Seguro deseas eliminar la venta?",
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
                        "DELETE FROM dbo.Venta WHERE IDVenta = @IDVenta";

                    using (SqlCommand comando =
                        new SqlCommand(consulta, sqlConn))
                    {
                        comando.Parameters.Add(
                            "@IDVenta", SqlDbType.Int).Value =
                            idVenta;

                        int renglonesAfectados =
                            comando.ExecuteNonQuery();

                        if (renglonesAfectados >= 1)
                        {
                            MessageBox.Show(
                                "Venta eliminada correctamente.");

                            ObtenerDatosBD();
                            CargarFilaSeleccionada();
                        }
                        else
                        {
                            MessageBox.Show(
                                "No existe una venta con ese ID.");
                        }
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show(
                    "No se puede eliminar esta venta " +
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
            llenaComboIDCliente();
            llenaComboIDFuncion();
            llenaComboIDTipoBoleto();

            ObtenerDatosBD();
            CargarFilaSeleccionada();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvVenta_SelectionChanged(object sender, EventArgs e)
        {
            if (!dgvVenta.Enabled)
                return;

            CargarFilaSeleccionada();
        }

        private void CargarFilaSeleccionada()
        {
            if (dgvVenta.SelectedRows.Count == 0 ||
                dgvVenta.SelectedRows[0].IsNewRow)
            {
                LimpiarCampos();
                return;
            }

            DataGridViewRow fila = dgvVenta.SelectedRows[0];

            txtIDVenta.Text =
                fila.Cells["IDVenta"].Value?.ToString() ?? "";

            txtPrecio.Text =
                fila.Cells["Precio"].Value?.ToString() ?? "";

            if (fila.Cells["IDCliente"].Value != null &&
                fila.Cells["IDCliente"].Value != DBNull.Value)
            {
                cBoxIDCliente.SelectedValue =
                    Convert.ToInt32(fila.Cells["IDCliente"].Value);
            }
            else
            {
                cBoxIDCliente.SelectedIndex = -1;
            }

            if (fila.Cells["IDFuncion"].Value != null &&
                fila.Cells["IDFuncion"].Value != DBNull.Value)
            {
                cBoxIDFuncion.SelectedValue =
                    Convert.ToInt32(fila.Cells["IDFuncion"].Value);
            }
            else
            {
                cBoxIDFuncion.SelectedIndex = -1;
            }

            if (fila.Cells["IDTipoBoleto"].Value != null &&
                fila.Cells["IDTipoBoleto"].Value != DBNull.Value)
            {
                cBoxIDTipoBoleto.SelectedValue =
                    Convert.ToInt32(fila.Cells["IDTipoBoleto"].Value);
            }
            else
            {
                cBoxIDTipoBoleto.SelectedIndex = -1;
            }
        }
    }
}
