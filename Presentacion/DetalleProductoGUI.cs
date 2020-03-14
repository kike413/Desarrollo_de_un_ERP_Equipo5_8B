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
        DetalleProductos DP = new DetalleProductos();
        //variable para recuperar el id del estilo seleccionado
        private string idDetalleProducto = null;
        //variable para saber cuando se va a editar.
        private bool editar = false;
        private string CExistencia;

        public DetalleProductoGUI()
        {
            InitializeComponent();
        }

        private void DetalleProductos_Load(object sender, EventArgs e)
        {
            MostrarDetallesProductos();
        }

        private void MostrarDetallesProductos()
        {
            DetalleProductos DP = new DetalleProductos();
            dataGridView1.DataSource = DP.MostrarDetalleProductos();
            dataGridView1.ClearSelection();
        }

        /**
         * Método para limpiar los campos después de editar o insertar
         * 
         */

        private void limpiar()
        {
            txtTalla.Clear();
            txtExistencia.Clear();
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
            return ok;
        }

        private void borrarError()
        {
            error.SetError(txtTalla, "");
            error.SetError(txtExistencia, "");
        }


        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            borrarError();
            ValidarCampos();
            //insertar registros si no se ha elegido editar
            if (txtTalla.Text == "" || txtExistencia.Text == "")
            {
            }
            else if (editar == false)
            {
                try
                {

                    DP.InsertarDetalleProductos(txtTalla.Text, txtExistencia.Text);
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
            if (txtTalla.Text == "" || txtExistencia.Text == "")
            {
            }
            else if (editar == true)
            {
                try
                {
                    DP.EditarDetalleProductos(txtTalla.Text, txtExistencia.Text, idDetalleProducto);
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
                DP.EliminarDetalleProductos(idDetalleProducto);
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
    }
}
