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
    public partial class PedidoDetalleGUI : Form
    {
        PedidoDetalle PD = new PedidoDetalle();
        //variable para recuperar el id del estilo seleccionado
        private string idPedido = null;
        private string idProductoDetalle = null;
        //variable para saber cuando se va a editar.
        private bool editar = false;
        private string CExistencia;
        private int pag = 1;
        private int numPags = 0;
        private int auxiliar = 0;
        private string campo = "";

        public PedidoDetalleGUI()
        {
            InitializeComponent();
        }

        private void DetalleProductos_Load(object sender, EventArgs e)
        {
            MostrarPedidoDetalle();
            //numPags = PD.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
        }

        private void MostrarPedidoDetalle()
        {
            PedidoDetalle pd = new PedidoDetalle();
            numPags = pd.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
            if (numPags < auxiliar && pag >= numPags)
            {
                pag--;
                dataGridView1.DataSource = pd.MostrarPedidoDetalle(pag);
                dataGridView1.ClearSelection();
            }
            else
            {
                dataGridView1.DataSource = pd.MostrarPedidoDetalle(pag);
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
            txtCantAceptada.Clear();
            txtCantPedida.Clear();
            txtCantRechazada.Clear();
            txtCantResibida.Clear();
            txtPrecioU.Clear();
            txtSubtotal.Clear();
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtCantAceptada.Text == "" || txtCantPedida.Text == "" || txtCantRechazada.Text == "" || txtCantResibida.Text=="")
            {
                ok = false;
                error.SetError(txtCantAceptada, "Introduce una cantidad.");
            }
            else if (txtPrecioU.Text == "" || txtSubtotal.Text == "")
            {
                ok = false;
                error.SetError(txtPrecioU, "Introduce el nombre del producto.");
            }
            return ok;
        }


        private void borrarError()
        {
            error.SetError(txtCantAceptada, "");
            error.SetError(txtCantPedida, "");
            error.SetError(txtCantRechazada, "");
            error.SetError(txtCantResibida, "");
            error.SetError(txtPrecioU, "");
            error.SetError(txtSubtotal, "");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            borrarError();
            ValidarCampos();
            //insertar registros si no se ha elegido editar
            if (txtidPedido.Text == "" || txtidProductoDetalle.Text == "" || txtCantPedida.Text == "" || txtPrecioU.Text == "" || txtSubtotal.Text == "" || txtCantResibida.Text == "" || txtCantRechazada.Text == "" || txtCantAceptada.Text == "")
            {
            }
            else if (editar == false)
            {
                try
                {

                    PD.InsertarPedidoDetalle(txtidPedido.Text, txtidProductoDetalle.Text, txtCantPedida.Text, txtPrecioU.Text, txtSubtotal.Text, txtCantResibida.Text, txtCantRechazada.Text, txtCantAceptada.Text);
                    MessageBox.Show("Se insertó correctamente");
                    MostrarPedidoDetalle();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro. Error: " + ex);
                }
            }
            //si editar = true 
            if (txtidPedido.Text == "" || txtidProductoDetalle.Text == "" || txtCantPedida.Text == "" || txtPrecioU.Text == "" || txtSubtotal.Text == "" || txtCantResibida.Text == "" || txtCantRechazada.Text == "" || txtCantAceptada.Text == "")
            {
            }
            else if (editar == true) //Falta el editar :C
            {
                try
                {
                    PD.EditarPedidoDetalle(txtidPedido.Text, txtidProductoDetalle.Text, txtCantPedida.Text, txtPrecioU.Text, txtSubtotal.Text, txtCantResibida.Text, txtCantRechazada.Text, txtCantAceptada.Text);
                    MessageBox.Show("Se editó correctamente");
                    MostrarPedidoDetalle();
                    editar = false;
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro. Error: " + ex);
                }
            }
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            PedidosGui Pedidoss = new PedidosGui();
            Pedidoss.Show();
            this.Hide();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idPedido = dataGridView1.CurrentRow.Cells["Pedido"].Value.ToString();
                idProductoDetalle = dataGridView1.CurrentRow.Cells["DetalleProductos"].Value.ToString();
                PD.EliminarPedidoDetalle(idPedido, idProductoDetalle);
                MessageBox.Show("Eliminado correctamente.");
                MostrarPedidoDetalle();
            }
            else
                MessageBox.Show("Seleccione el detalle del pedido que quiere editar.");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //si hay mas de una columna entonces...
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtidPedido.Enabled = false;
                txtidProductoDetalle.Enabled = false;
                editar = true;
                //entre corchetes el nombre del campo como está en la base de datos
                txtidPedido.Text = dataGridView1.CurrentRow.Cells["Pedido"].Value.ToString();
                txtidProductoDetalle.Text = dataGridView1.CurrentRow.Cells["DetalleProductos"].Value.ToString();
                txtCantPedida.Text = dataGridView1.CurrentRow.Cells["cantPedida"].Value.ToString();
                txtPrecioU.Text = dataGridView1.CurrentRow.Cells["precioUnitario"].Value.ToString();
                txtSubtotal.Text = dataGridView1.CurrentRow.Cells["subtotal"].Value.ToString();
                txtCantResibida.Text = dataGridView1.CurrentRow.Cells["cantRecibida"].Value.ToString();
                txtCantRechazada.Text = dataGridView1.CurrentRow.Cells["cantRechazada"].Value.ToString();
                txtCantAceptada.Text = dataGridView1.CurrentRow.Cells["cantAceptada"].Value.ToString();
                //idProducto = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione el producto del proveedor que quiere editar.");
        }

        private void retroceder_Click(object sender, EventArgs e)
        {
            if (pag == 1)
            {
                retroceder.Enabled = false;
                MostrarPedidoDetalle();
            }
            else
            {
                pag--;
                avanza.Enabled = true;
                MostrarPedidoDetalle();
            }
            Console.WriteLine(pag);
        }

        private void avanza_Click(object sender, EventArgs e)
        {
            if (pag == numPags)
            {
                avanza.Enabled = false;
                MostrarPedidoDetalle();
            }
            else
            {
                pag++;
                retroceder.Enabled = true;
                MostrarPedidoDetalle();
            }
        }


    }
}
