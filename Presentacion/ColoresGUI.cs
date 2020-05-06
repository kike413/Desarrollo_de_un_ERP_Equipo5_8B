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
        //variable para recuperar el id del estilo seleccionado
        private string idColor = null;
        //variable para saber cuando se va a editar.
        private bool editar = false;
        private int pag = 1;
        private int numPags = 0;
        private int auxiliar = 0;
        public ColoresGUI()
        {
            InitializeComponent();
        }





        private void ColoresGUI_Load(object sender, EventArgs e)
        {
            MostrarColores();
            numPags = ColoresN.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
        }

        private void MostrarColores()
        {
            Colores coloresN = new Colores();
            numPags = ColoresN.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
            if (numPags < auxiliar && pag >= numPags)
            {
                pag--;
                dataGridView2.DataSource = coloresN.MostrarColores(pag);
                dataGridView2.ClearSelection();
            }
            else
            {
                dataGridView2.DataSource = coloresN.MostrarColores(pag);
                dataGridView2.ClearSelection();

                if (pag == 1)
                {
                    retroceder.Enabled = false;
                }
                if (pag == numPags)
                {
                    avanza.Enabled = false;
                }
                else
                {
                    avanza.Enabled = true;
                }
            }
            auxiliar = numPags;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            borrarError();
            ValidarCampos();
            //insertar registros si no se ha elegido editar
            if (txtNombre.Text == "")
            {
            }
            else if (editar == false)
            {
                try
                {
                    ColoresN.InsertarColor(txtNombre.Text);
                    MessageBox.Show("Se insertó correctamente");
                    MostrarColores();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro. Error: " + ex);
                }
            }
            //si editar = true entonces editamos xd
            if (txtNombre.Text == "")
            {
            }
            else if (editar == true)
            {
                try
                {
                    ColoresN.EditarColor(txtNombre.Text, idColor);
                    MessageBox.Show("Se editó correctamente");
                    MostrarColores();
                    editar = false;
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro. Error: " + ex);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //si hay mas de una columna entonces...
            if (dataGridView2.SelectedRows.Count > 0)
            {
                editar = true;
                //entre corchetes el nombre del campo como está en la base de datos
                txtNombre.Text = dataGridView2.CurrentRow.Cells["nombre"].Value.ToString();
                idColor = dataGridView2.CurrentRow.Cells["idColor"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione el color que quiere editar.");
        }


        /**
         * Método para limpiar los campos después de editar o insertar
         * 
         */

        private void limpiar()
        {
            txtNombre.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                idColor = dataGridView2.CurrentRow.Cells["idColor"].Value.ToString();
                ColoresN.EliminarColor(idColor);
                MessageBox.Show("Eliminado correctamente.");
                MostrarColores();
            }
            else
                MessageBox.Show("Seleccione el color que quiere editar.");
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtNombre.Text == "")
            {
                ok = false;
                error.SetError(txtNombre, "Introduce el nombre del color.");
            }
            return ok;
        }

        private void borrarError()
        {
            error.SetError(txtNombre, "");
        }

        //validacion para que solo ingrese letras
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64 || (e.KeyChar >= 91 && e.KeyChar <= 96)))
            {
                MessageBox.Show("Solo se admiten letras", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }



        private void Regresa_Click(object sender, EventArgs e)
        {
                PrincipalGUI principal = new PrincipalGUI();
                principal.Show();
                this.Hide();
        }

        private void retroceder_Click(object sender, EventArgs e)
        {
            if (pag == 1)
            {
                retroceder.Enabled = false;
                MostrarColores();
            }
            else
            {
                pag--;
                avanza.Enabled = true;
                MostrarColores();
            }
            Console.WriteLine(pag);
        }

        private void avanza_Click_1(object sender, EventArgs e)
        {
            if (pag == numPags)
            {
                avanza.Enabled = false;
                MostrarColores();
            }
            else
            {
                pag++;
                retroceder.Enabled = true;
                MostrarColores();
            }
        }
    }
}
