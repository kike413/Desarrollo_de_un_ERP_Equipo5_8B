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
        private string idDetalleProducto = null;
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
            numPags = PD.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
        }

        private void MostrarPedidoDetalle()
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


        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            borrarError();
            ValidarCampos();
            //insertar registros si no se ha elegido editar
            if (txtCantAceptada.Text == "" || txtCantPedida.Text == "" || txtCantRechazada.Text == "" || txtCantResibida.Text == "" || txtPrecioU.Text == "" || txtSubtotal.Text == "")
            {
            }
            else if (editar == false)
            {
                try
                {

                    PD.InsertarPedidoDetalle(txtCantPedida.Text, txtPrecioU.Text, txtSubtotal.Text, txtCantResibida.Text, txtCantRechazada.Text, txtCantAceptada.Text);
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
            if (txtCantAceptada.Text == "" || txtCantPedida.Text == "" || txtCantRechazada.Text == "" || txtCantResibida.Text == "" || txtPrecioU.Text == "" || txtSubtotal.Text == "")
            {
            }
            else if (editar == true) //Falta el editar :C
            {
                try
                {
                    PD.EditarPedidoDetalle(txtCantPedida.Text, txtPrecioU.Text, txtSubtotal.Text, txtCantResibida.Text, txtCantRechazada.Text, txtCantAceptada.Text, idDetalleProducto);
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
                idDetalleProducto = dataGridView1.CurrentRow.Cells["idPedido"].Value.ToString();
                PD.EliminarPedidoDetalle(idDetalleProducto);
                MessageBox.Show("Eliminado correctamente.");
                MostrarPedidoDetalle();
            }
            else
                MessageBox.Show("Seleccione el detalle del pedido que quiere editar.");
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
                MessageBox.Show("Seleccione el detalle del pedido que quiere editar.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
