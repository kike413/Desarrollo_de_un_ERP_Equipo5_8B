using Datos;
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
    public partial class PedidosGui : Form
    {


        Pedidos pedN = new Pedidos();
        private string idPedido = null;
        //variable para saber cuando se va a editar.
        private bool editar = false;
        private int pag = 1;
        private int numPags = 0;
        private int auxiliar = 0;
        private string campo = "";

        public PedidosGui()
        {
            InitializeComponent();
        }
        private void PedidosGui_Load(object sender, EventArgs e)
        {
            MostrarPedidos();
            numPags = pedN.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
            dateRegistro.Format = DateTimePickerFormat.Custom;
            dateRegistro.CustomFormat = "dd/MM/yyyy";
            dateRecepcion.Format = DateTimePickerFormat.Custom;
            dateRecepcion.CustomFormat = "dd/MM/yyyy";
            ListarProveedores();
            ListarEmpleados();
            comboEmpleado.ResetText();
            comboProveedor.ResetText();
        }

        public void MostrarPedidos()
        {
            Pedidos pedN = new Pedidos();
            numPags = pedN.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
            if (numPags < auxiliar && pag >= numPags)
            {
                pag--;
                dataGridView1.DataSource = pedN.MostrarPedidos(pag);
                dataGridView1.ClearSelection();
            }
            else
            {
                dataGridView1.DataSource = pedN.MostrarPedidos(pag);
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
        /*
        * Mostrar proveedores en combobox
        */
        public void ListarProveedores()
        {
            Pedidos pedN = new Pedidos();
            pedN.ListarProveedores(comboProveedor);
        }

        /*
        * Mostrar Empleados en combobox
        */


        public void ListarEmpleados()
        {
            Pedidos pedN = new Pedidos();
            pedN.ListarEmpleados(comboEmpleado);
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //borrarError();
            //ValidarCampos();
            //insertar registros si no se ha elegido editar
            if (dateRegistro.Text == "" || dateRecepcion.Text == "" || txtTotalPagar.Text == "" || txtCantidadPagada.Text == "" || comboProveedor.Text == "" || comboEmpleado.Text == "")
            {
            }
            else if (editar == false)
            {
                try
                {
                    pedN.insertarPedido(Convert.ToString(dateRegistro.Value), Convert.ToString(dateRecepcion.Value), txtTotalPagar.Text, txtCantidadPagada.Text, Convert.ToInt32(comboProveedor.SelectedValue), Convert.ToInt32(comboEmpleado.SelectedValue));
                    MessageBox.Show("Se insertó correctamente");
                    MostrarPedidos();
                    //limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro. Error: " + ex);
                }
            }
            //si editar = true entonces editamos xd
            if (dateRegistro.Text == "" || dateRecepcion.Text == "" || txtTotalPagar.Text == "" || txtCantidadPagada.Text == "" || comboProveedor.Text == "" || comboEmpleado.Text == "")
            {
            }
            else if (editar == true)
            {
                try
                {
                    pedN.EditarPedido(Convert.ToString(dateRegistro.Value), Convert.ToString(dateRecepcion.Value), txtTotalPagar.Text, txtCantidadPagada.Text, Convert.ToInt32(comboProveedor.SelectedValue), Convert.ToInt32(comboEmpleado.SelectedValue),idPedido);

                    MessageBox.Show("Se editó correctamente");
                    MostrarPedidos();
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
                dateRegistro.Text = dataGridView1.CurrentRow.Cells["fechaRegistro"].Value.ToString();
                dateRecepcion.Text = dataGridView1.CurrentRow.Cells["fechaRecepcion"].Value.ToString();
                txtTotalPagar.Text = dataGridView1.CurrentRow.Cells["totalPagar"].Value.ToString();
                txtCantidadPagada.Text = dataGridView1.CurrentRow.Cells["cantidadPagada"].Value.ToString();
                comboProveedor.Text = dataGridView1.CurrentRow.Cells["Proveedor"].Value.ToString();
                comboEmpleado.Text = dataGridView1.CurrentRow.Cells["Empleado"].Value.ToString();
                idPedido = dataGridView1.CurrentRow.Cells["idPedido"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione la categoría que quiere editar.");
        }
    }
    }

