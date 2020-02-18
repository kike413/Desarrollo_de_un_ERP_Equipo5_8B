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
            this.Hide();
        }

        private void MostraNombre_Click(object sender, EventArgs e)
        {
            
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }
    }
}
