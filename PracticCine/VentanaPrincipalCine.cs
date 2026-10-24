namespace PracticCine
{
    public partial class VP : Form
    {
        public VP()
        {
            InitializeComponent();
        }

        private void clasificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clasificacion ventanaClasificacion = new Clasificacion();
            ventanaClasificacion.ShowDialog();
        }

        private void generoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Genero ventanaGenero = new Genero();
            ventanaGenero.ShowDialog();
        }

        private void peliculaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pelicula ventanaPelicula = new Pelicula();
            ventanaPelicula.ShowDialog();
        }

        private void sucursalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sucursal ventanaSucursal = new Sucursal();
            ventanaSucursal.ShowDialog();
        }

        private void salaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sala ventanaSala = new Sala();
            ventanaSala.ShowDialog();
        }

        private void tipoBoletoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TipoBoleto ventanaTipoBoleto = new TipoBoleto();
            ventanaTipoBoleto.ShowDialog();
        }

        private void ciudadYEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CiudadEstado ventanaCiudadEstado = new CiudadEstado();
            ventanaCiudadEstado.ShowDialog();
        }

        private void funcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcion ventanaFuncion = new Funcion();
            ventanaFuncion.ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cliente ventanaCliente = new Cliente();
            ventanaCliente.ShowDialog();
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Venta ventanaVenta = new Venta();
            ventanaVenta.ShowDialog();
        }

        private void estadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Estado ventanaEstado = new Estado();
            ventanaEstado.ShowDialog();
        }
    }
}
