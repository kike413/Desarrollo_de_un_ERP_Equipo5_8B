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

        /*
         * Mostrar pedidos en combobox
        */
        private void PedidosGui_Load(object sender, EventArgs e)
        {
            dateRegistro.Format = DateTimePickerFormat.Custom;
            dateRegistro.CustomFormat = "dd/MM/yyyy";
            dateRecepcion.Format = DateTimePickerFormat.Custom;
            dateRecepcion.CustomFormat = "dd/MM/yyyy";
            ListarProveedores();
            ListarEmpleados();
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
                    //MostrarProductos();
                    //limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro. Error: " + ex);
                }
            }
            //si editar = true entonces editamos xd
           /* if (dateRegistro.Text == "" || dateRecepcion.Text == "" || txtTotalPagar.Text == "" || txtCantidadPagada.Text == "" || comboProveedor.Text == "" || comboEmpleado.Text == "")
            {
            }
            else if (editar == true)
            {
                try
                {
                    prodN.EditarProducto(txtNombre.Text, txtDescripcion.Text, txtPuntoReo.Text,
                        txtGenero.Text, txtPrecioCompra.Text, txtPrecioVenta.Text, txtMaterial.Text, txtMarca.Text,
                        txtEstilo.Text, txtCategoria.Text, idProducto);
                    MessageBox.Show("Se editó correctamente");
                    MostrarProductos();
                    editar = false;
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro. Error: " + ex);
                }*/
            }
        }
    }
//}
