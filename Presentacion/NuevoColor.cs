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
    public partial class NuevoColor : Form
    {
        Colores ColoresN = new Colores();
        ColoresGUI gui = new ColoresGUI();
        public NuevoColor()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Colortxt != null)
            {
                ColoresN.InsertarColor(Colortxt.Text);
                MessageBox.Show("Se insertó correctamente");
                this.Close();
                gui.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
