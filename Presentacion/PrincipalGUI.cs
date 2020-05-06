using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;


namespace Presentacion
{
    public partial class PrincipalGUI : Form
    {

        public PrincipalGUI()
        {
            InitializeComponent();
        }


        
        private void Principal_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
            hora.Text = DateTime.Now.ToString("hh:mm:ss");
            fecha.Text = DateTime.Now.ToShortDateString();
        }


        private void Estilos_Click_1(object sender, EventArgs e)
        {
            EstilosGui estilos = new EstilosGui();
            estilos.Show();
            this.Hide();
        }

        private void Colores_Click_1(object sender, EventArgs e)
        {
            ColoresGUI colores = new ColoresGUI();
            colores.Show();
            this.Hide();
        }

        private void Categorias_Click_1(object sender, EventArgs e)
        {
            CategoriasGUI categorias = new CategoriasGUI();
            categorias.Show();
            this.Hide();
        }


        private void brnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
        
        private void CargarDatosUsuario()
        {
            //ID.Text = InicioSesionDAO.CID;
            Cargo.Text = InicioSesionDAO.Cargo;
            Nombre.Text = InicioSesionDAO.Nombre + " " + InicioSesionDAO.ApellidoPaterno + " " + InicioSesionDAO.ApellidoMaterno;
            EstadoCivil.Text = InicioSesionDAO.EstadoCivil;
        }

        private void Productos_Click(object sender, EventArgs e)
        {
            ProductosGUI prGui = new ProductosGUI();
            prGui.Show();
            this.Hide();
        }

        private void Marcas_Click(object sender, EventArgs e)
        {
            MarcasGUI marcas = new MarcasGUI();
            marcas.Show();
            this.Hide();
        }

        private void Pedidos_Click(object sender, EventArgs e)
        {
            ProveedoresGUI proV = new ProveedoresGUI();
            proV.Show();
            this.Hide();
        }
    }
}
