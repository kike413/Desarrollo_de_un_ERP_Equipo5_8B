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
    public partial class PagosComprasGUI : Form
    {
        PagosCompras Pagos = new PagosCompras();
        //variable para recuperar el id del estilo seleccionado
        private string idPago = null;
        //variable para saber cuando se va a editar.
        private bool editar = false;
        private int pag = 1;
        private int numPags = 0;
        private int auxiliar = 0;

        public PagosComprasGUI()
        {
            InitializeComponent();
        }


        private void MostrarPagosCompras()
        {
            PagosCompras Pagos = new PagosCompras();
            numPags = Pagos.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
            if (numPags < auxiliar && pag >= numPags)
            {
                pag--;
                dataGridView1.DataSource = Pagos.MostrarPagosCompras(pag);
                dataGridView1.ClearSelection();
            }
            else
            {
                dataGridView1.DataSource = Pagos.MostrarPagosCompras(pag);
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

        private void PagosComprasGui_Load(object sender, EventArgs e)
        {
            MostrarPagosCompras();
            numPags = Pagos.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
            dateFecha.Format = DateTimePickerFormat.Custom;
            dateFecha.CustomFormat = "dd/MM/yyyy";
            ListarPedidos();
            ListarFormaPago();
            comboidFormaPago.ResetText();
            comboidPedido.ResetText();
        }

        /*
        * Mostrar Pedidos en combobox
        */
        public void ListarPedidos()
        {
            PagosCompras Pagos = new PagosCompras();
            Pagos.ListarPedido(comboidPedido);
        }

        /*
        * Mostrar Pedidos en combobox
        */
        public void ListarFormaPago()
        {
            PagosCompras Pagos = new PagosCompras();
            Pagos.ListarFormaPago(comboidFormaPago);
        }

        private void borrarError()
        {
            error.SetError(dateFecha, "");
            error.SetError(txtImporte, "");
            error.SetError(comboidPedido, "");
            error.SetError(comboidFormaPago, "");
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            if (dateFecha.Text == "")
            {
                ok = false;
                error.SetError(dateFecha, "Introduce la Fecha.");
            }
            else if (txtImporte.Text == "")
            {
                ok = false;
                error.SetError(txtImporte, "Introduce el Importe");
            }
            else if (comboidPedido.Text == "")
            {
                ok = false;
                error.SetError(comboidPedido, "Introduce el id del pedido");
            }
            else if (comboidFormaPago.Text == "")
            {
                ok = false;
                error.SetError(comboidFormaPago, "Introduce el id de la forma de pago");
            }
            return ok;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            borrarError();
            ValidarCampos();
            //insertar registros si no se ha elegido editar
            if (dateFecha.Text == "" || txtImporte.Text == "" || comboidPedido.Text == "" || comboidFormaPago.Text == "")
            {
            }
            else if (editar == false)
            {
                try
                {
                    Pagos.InsertarPagosCompras(Convert.ToString(dateFecha.Value), txtImporte.Text, Convert.ToInt32(comboidPedido.SelectedValue), Convert.ToInt32(comboidFormaPago.SelectedValue));
                    MessageBox.Show("Se insertó correctamente");
                    MostrarPagosCompras();
                    //limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro. Error: " + ex);
                }
            }
            //si editar = true entonces editamos xd
            if (dateFecha.Text == "" || txtImporte.Text == "" || comboidPedido.Text == "" || comboidFormaPago.Text == "")
            {
            }
            else if (editar == true)
            {
                try
                {
                    Pagos.EditarPagosCompras(Convert.ToString(dateFecha.Value), txtImporte.Text, Convert.ToInt32(comboidPedido.SelectedValue), Convert.ToInt32(comboidFormaPago.SelectedValue), idPago);

                    MessageBox.Show("Se editó correctamente");
                    MostrarPagosCompras();
                    editar = false;
                    //limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro. Error: " + ex);
                }
            }
        }


        private void Regresar_Click(object sender, EventArgs e)
        {
            PrincipalGUI principal = new PrincipalGUI();
            principal.Show();
            this.Hide();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //si hay mas de una columna entonces...
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                //entre corchetes el nombre del campo como está en la base de datos
                dateFecha.Text = dataGridView1.CurrentRow.Cells["fecha"].Value.ToString();
                txtImporte.Text = dataGridView1.CurrentRow.Cells["importe"].Value.ToString();
                comboidPedido.Text = dataGridView1.CurrentRow.Cells["idPedido"].Value.ToString();
                comboidFormaPago.Text = dataGridView1.CurrentRow.Cells["idFormaPago"].Value.ToString();
                idPago = dataGridView1.CurrentRow.Cells["idPago"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione la forma de pago que quiere editar.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idPago = dataGridView1.CurrentRow.Cells["idPago"].Value.ToString();
                Pagos.EliminarPagosCompras(idPago);
                MessageBox.Show("Eliminado correctamente.");
                MostrarPagosCompras();
            }
            else
                MessageBox.Show("Seleccione el pedido que quiere eliminar.");
        }

        private void btnFormasPago_Click(object sender, EventArgs e)
        {
            FormasPagoGUI ForPago = new FormasPagoGUI();
            ForPago.Show();
            this.Hide();
        }
    }
}
