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
    public partial class DetalleProductoGUI : Form
    {
        DetalleProductos dpN = new DetalleProductos();
        //variable para recuperar el id del estilo seleccionado
        private string idDetalleProducto = null;
        //variable para saber cuando se va a editar.
        private bool editar = false;
        private string CExistencia;
        private int pag = 1;
        private int numPags = 0;
        private int auxiliar = 0;
        private string campo = "";

        public DetalleProductoGUI()
        {
            InitializeComponent();
        }

        private void DetalleProductos_Load(object sender, EventArgs e)
        {
            MostrarDetallesProductos();
            numPags = dpN.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
        }

        private void MostrarDetallesProductos()
        {
            DetalleProductos dpN = new DetalleProductos();
            numPags = dpN.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
            if (numPags < auxiliar && pag >= numPags)
            {
                pag--;
                dataGridView1.DataSource = dpN.MostrarDetalleProductos(pag);
                dataGridView1.ClearSelection();
            }
            else
            {
                dataGridView1.DataSource = dpN.MostrarDetalleProductos(pag);
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

        /**
         * Método para limpiar los campos después de editar o insertar
         * 
         */

        private void limpiar()
        {
            txtTalla.Clear();
            txtExistencia.Clear();
            txtColor.Clear();
            txtProducto.Clear();
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtTalla.Text == "")
            {
                ok = false;
                error.SetError(txtTalla, "Introduce la talla del producto.");
            }
            else if (txtExistencia.Text == "")
            {
                ok = false;
                error.SetError(txtExistencia, "Introduce la existencia del producto.");
            }
            else if (txtColor.Text == "")
            {
                ok = false;
                error.SetError(txtColor, "Introduce el color del producto.");
            }
            else if (txtProducto.Text == "")
            {
                ok = false;
                error.SetError(txtProducto, "Introduce el nombre del producto.");
            }
            return ok;
        }

        private void borrarError()
        {
            error.SetError(txtTalla, "");
            error.SetError(txtExistencia, "");
            error.SetError(txtColor, "");
            error.SetError(txtProducto, "");
        }


        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            borrarError();
            ValidarCampos();
            //insertar registros si no se ha elegido editar
            if (txtTalla.Text == "" || txtExistencia.Text == "" || txtColor.Text=="" || txtProducto.Text=="")
            {
            }
            else if (editar == false)
            {
                try
                {

                    dpN.InsertarDetalleProductos(txtTalla.Text, txtExistencia.Text,txtColor.Text,txtProducto.Text);
                    MessageBox.Show("Se insertó correctamente");
                    MostrarDetallesProductos();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro. Error: " + ex);
                }
            }
            //si editar = true entonces editamos xd
            if (txtTalla.Text == "" || txtExistencia.Text == "" || txtColor.Text == "" || txtProducto.Text == "")
            {
            }
            else if (editar == true)
            {
                try
                {
                    dpN.EditarDetalleProductos(txtTalla.Text, txtExistencia.Text,txtColor.Text,txtProducto.Text, idDetalleProducto);
                    MessageBox.Show("Se editó correctamente");
                    MostrarDetallesProductos();
                    editar = false;
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro. Error: " + ex);
                }
            }

        }

        private void Regresar_Click_1(object sender, EventArgs e)
        {
            PrincipalGUI principal = new PrincipalGUI();
            principal.Show();
            this.Hide();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idDetalleProducto = dataGridView1.CurrentRow.Cells["idProductoDetalle"].Value.ToString();
                dpN.EliminarDetalleProductos(idDetalleProducto);
                MessageBox.Show("Eliminado correctamente.");
                MostrarDetallesProductos();
            }
            else
                MessageBox.Show("Seleccione el detalle del producto que quiere editar.");
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            //si hay mas de una columna entonces...
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                //entre corchetes el nombre del campo como está en la base de datos
                txtTalla.Text = dataGridView1.CurrentRow.Cells["talla"].Value.ToString();
                txtExistencia.Text = dataGridView1.CurrentRow.Cells["existencia"].Value.ToString();
                txtColor.Text = Convert.ToString(dpN.obtenerIdColor(dataGridView1.CurrentRow.Cells["color"].Value.ToString()));
                txtProducto.Text = Convert.ToString(dpN.obtenerIdProducto(dataGridView1.CurrentRow.Cells["producto"].Value.ToString()));
                idDetalleProducto = dataGridView1.CurrentRow.Cells["idProductoDetalle"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione el detalle del producto que quiere editar.");
        }

        //validacion para que solo inserte numeros o el punto
        

        private void txtExistencia_KeyPress_1(object sender, KeyPressEventArgs e)
        {
           if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTalla_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            /**if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
    **/
            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                MessageBox.Show("Solo se permiten numeros o un punto", "Advertencia", MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void retroceder_Click(object sender, EventArgs e)
        {
            if (pag == 1)
            {
                retroceder.Enabled = false;
                MostrarDetallesProductos();
            }
            else
            {
                pag--;
                avanza.Enabled = true;
                MostrarDetallesProductos();
            }
            Console.WriteLine(pag);
        }

        private void avanza_Click(object sender, EventArgs e)
        {
            if (pag == numPags)
            {
                avanza.Enabled = false;
                MostrarDetallesProductos();
            }
            else
            {
                pag++;
                retroceder.Enabled = true;
                MostrarDetallesProductos();
            }
        }

        private void txtColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
