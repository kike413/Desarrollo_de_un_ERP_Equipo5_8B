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
    public partial class ColoresGUI : Form
    {

        Colores ColoresN = new Colores();
        private string idColor = null;
        private bool editar = false;
        public ColoresGUI()
        {
            InitializeComponent();
        }

        private void Colores_Load(object sender, EventArgs e)
        {
            MostrarColores();
        }

        private void MostrarColores()
        {
            Colores ColoresN = new Colores();
            dataGridView1.DataSource = ColoresN.MostrarColores();
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            NuevoColor ncolor = new NuevoColor();
            ncolor.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //si hay mas de una columna entonces...
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                Nombretxt.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                idColor = dataGridView1.CurrentRow.Cells["idColor"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione el color a editar.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idColor = dataGridView1.CurrentRow.Cells["idColor"].Value.ToString();
                ColoresN.EliminarColor(idColor);
                MessageBox.Show("Eliminado correctamente.");
                MostrarColores();
            }
            else
                MessageBox.Show("Seleccione el color a editar.");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ColoresGUI_Load(object sender, EventArgs e)
        {
            MostrarColores();
        }
    }
}
