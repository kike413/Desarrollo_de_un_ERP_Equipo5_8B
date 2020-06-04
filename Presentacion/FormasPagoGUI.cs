using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using Dominio;

namespace Presentacion
{
    public partial class FormasPagoGUI : Form
    {
        FormasPago ForPago = new FormasPago();
        private string idFormaPago = null;
        //variable para saber cuando se va a editar.
        private bool editar = false;
        private int pag = 1;
        private int numPags = 0;
        private int auxiliar = 0;
        public FormasPagoGUI()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormasPago_Load(object sender, EventArgs e)
        {
            MostrarFormasPago();
            numPags = ForPago.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
        }
        private void MostrarFormasPago()
        {
            FormasPago ForPago = new FormasPago();
            numPags = ForPago.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
            if (numPags < auxiliar && pag >= numPags)
            {
                pag--;
                dataGridView1.DataSource = ForPago.MostrarFormasPago(pag);
                dataGridView1.ClearSelection();
            }
            else
            {
                dataGridView1.DataSource = ForPago.MostrarFormasPago(pag);
                dataGridView1.ClearSelection();

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


        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtNombre.Text == "")
            {
                ok = false;
                error.SetError(txtNombre, "Introduce el nombre de la Forma de pago.");
            }
            return ok;
        }

        private void borrarError()
        {
            error.SetError(txtNombre, "");
        }

        /**
        * Método para limpiar los campos después de editar o insertar
        * 
        */

        private void limpiar()
        {
            txtNombre.Clear();
        }
        

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            //si hay mas de una columna entonces...
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                //entre corchetes el nombre del campo como está en la base de datos
                txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                idFormaPago = dataGridView1.CurrentRow.Cells["idFormaPago"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione la categoría que quiere editar.");
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idFormaPago = dataGridView1.CurrentRow.Cells["idFormaPago"].Value.ToString();
                ForPago.EliminarFormasPago(idFormaPago);
                MessageBox.Show("Eliminado correctamente.");
                MostrarFormasPago();
            }
            else
                MessageBox.Show("Seleccione el estilo que quiere editar.");
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
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
                    ForPago.InsertarFormasPago(txtNombre.Text);
                    MessageBox.Show("Se insertó correctamente");
                    MostrarFormasPago();
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
                    ForPago.EditarFormasPago(txtNombre.Text, idFormaPago);
                    MessageBox.Show("Se editó correctamente");
                    MostrarFormasPago();
                    editar = false;
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro. Error: " + ex);
                }
            }
        }

        private void txtNombre_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64 || (e.KeyChar >= 91 && e.KeyChar <= 96)))
            {
                MessageBox.Show("Solo se admiten letras", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void retroceder_Click_1(object sender, EventArgs e)
        {
            if (pag == 1)
            {
                retroceder.Enabled = false;
                MostrarFormasPago();
            }
            else
            {
                pag--;
                avanza.Enabled = true;
                MostrarFormasPago();
            }
            Console.WriteLine(pag);
        }

        private void avanza_Click_1(object sender, EventArgs e)
        {
            if (pag == numPags)
            {
                avanza.Enabled = false;
                MostrarFormasPago();
            }
            else
            {
                pag++;
                retroceder.Enabled = true;
                MostrarFormasPago();
            }
        }

        private void Regresar_Click_1(object sender, EventArgs e)
        {
            PagosComprasGUI PagosCompras = new PagosComprasGUI();
            PagosCompras.Show();
            this.Hide();
        }
    }
}
