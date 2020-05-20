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
        PedidoDetalleGUI PD = new PedidoDetalleGUI();
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

    }
}

