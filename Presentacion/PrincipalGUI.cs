using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;



namespace Presentacion
{
    public partial class PrincipalGUI : Form
    {
        Principal principalD = new Principal();
        public PrincipalGUI()
        {
            InitializeComponent();
        }

        private void Estilos_Click(object sender, EventArgs e)
        {
            EstilosGui estilos = new EstilosGui();
            estilos.Show();
            //this.Hide();
        }

        private void MostraNombre_Click(object sender, EventArgs e)
        {
            
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void Colores_Click(object sender, EventArgs e)
        {
            ColoresGUI colores = new ColoresGUI();
            colores.Show();
            //this.Hide();
        }

        private void Categorias_Click(object sender, EventArgs e)
        {
            CategoriasGUI categorias = new CategoriasGUI();
            categorias.Show();
            //this.Hide();
        }

        private void Marcas_Click(object sender, EventArgs e)
        {
            MarcasGUI marcas = new MarcasGUI();
            marcas.Show();
           // this.Hide();
        }
    }
}
