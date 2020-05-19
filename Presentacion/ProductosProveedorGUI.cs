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
    public partial class ProductosProveedorGUI : Form
    {
        ProductosProveedor PP = new ProductosProveedor();
        //variable para recuperar el id del estilo seleccionado
        private string idProducto = null;
        //variable para saber cuando se va a editar.
        private bool editar = false;
        private int pag = 1;
        private int numPags = 0;
        private int auxiliar = 0;

        public ProductosProveedorGUI()
        {
            InitializeComponent();
        }

        private void ProductosProveedor_Load(object sender, EventArgs e)
        {
            MostrarProductosProveedor();
            numPags = PP.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
        }

        private void MostrarProductosProveedor()
        {
            ProductosProveedor PP = new ProductosProveedor();
            numPags = PP.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
            if (numPags < auxiliar && pag >= numPags)
            {
                pag--;
                dataGridView1.DataSource = PP.MostrarProductosProveedorDAO(pag);
                dataGridView1.ClearSelection();
            }
            else
            {
                dataGridView1.DataSource = PP.MostrarProductosProveedorDAO(pag);
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
            txtidProducto.Clear();
            txtidProveedor.Clear();
            txtDiasRetardo.Clear();
            txtPrecioEstandar.Clear();
            txtPrecioUCompra.Clear();
            txtCantMinima.Clear();
            txtCantMaxima.Clear();
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtDiasRetardo.Text == "")
            {
                ok = false;
                error.SetError(txtDiasRetardo, "Introduce la talla del producto.");
            }
            else if (txtPrecioEstandar.Text == "")
            {
                ok = false;
                error.SetError(txtPrecioEstandar, "Introduce la existencia del producto.");
            }
            else if (txtPrecioUCompra.Text == "")
            {
                ok = false;
                error.SetError(txtPrecioUCompra, "Introduce el color del producto.");
            }
            else if (txtCantMinima.Text == "")
            {
                ok = false;
                error.SetError(txtCantMinima, "Introduce el nombre del producto.");
            }
            else if (txtCantMaxima.Text == "")
            {
                ok = false;
                error.SetError(txtCantMaxima, "Introduce el nombre del producto.");
            }
            return ok;
        }

        private void borrarError()
        {
            error.SetError(txtDiasRetardo, "");
            error.SetError(txtPrecioEstandar, "");
            error.SetError(txtPrecioUCompra, "");
            error.SetError(txtCantMinima, "");
            error.SetError(txtCantMaxima, "");
        }

        private void ProductosProveedorGUI_Load(object sender, EventArgs e)
        {
            MostrarProductosProveedor();
            numPags = PP.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
        }


        //validacion para que solo inserte numeros o el punto
        private void txtDiasRetardo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPrecioEstandar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45 || (e.KeyChar == 47) || (e.KeyChar >= 58 && e.KeyChar <= 255)))
            {
                MessageBox.Show("Solo se admiten números enteros o con decimal", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPrecioUCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45 || (e.KeyChar == 47) || (e.KeyChar >= 58 && e.KeyChar <= 255)))
            {
                MessageBox.Show("Solo se admiten números enteros o con decimal", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCantMinima_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCantMaxima_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            borrarError();
            ValidarCampos();
            //insertar registros si no se ha elegido editar
            if (txtidProducto.Text == "" || txtidProveedor.Text == "" || txtDiasRetardo.Text == "" || txtPrecioEstandar.Text == "" || txtPrecioUCompra.Text == "" || txtCantMinima.Text == "" || txtCantMaxima.Text == "")
            {
            }
            else if (editar == false)
            {
                try
                {

                    PP.InsertarProductosProveedor(txtidProducto.Text, txtidProveedor.Text, txtDiasRetardo.Text, txtPrecioEstandar.Text, txtPrecioUCompra.Text, txtCantMinima.Text, txtCantMaxima.Text);
                    MessageBox.Show("Se insertó correctamente");
                    MostrarProductosProveedor();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro. Error: " + ex);
                }
            }
            //si editar = true entonces editamos xd
            if (txtidProducto.Text == "" || txtidProveedor.Text == "" || txtDiasRetardo.Text == "" || txtPrecioEstandar.Text == "" || txtPrecioUCompra.Text == "" || txtCantMinima.Text == "" || txtCantMaxima.Text == "")
            {
            }
            else if (editar == true)
            {
                try
                {
                    PP.EditarProductosProveedor(txtidProducto.Text, txtidProveedor.Text, txtDiasRetardo.Text, txtPrecioEstandar.Text, txtPrecioUCompra.Text, txtCantMinima.Text, txtCantMaxima.Text, idProducto);
                    MessageBox.Show("Se insertó correctamente");
                    MostrarProductosProveedor();
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
            ProveedoresGUI proveedores = new ProveedoresGUI();
            proveedores.Show();
            this.Hide();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
                PP.EliminarProductosProveedor(idProducto);
                MessageBox.Show("Eliminado correctamente.");
                MostrarProductosProveedor();
            }
            else
                MessageBox.Show("Seleccione el producto del proveedor que quiere eliminar.");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //si hay mas de una columna entonces...
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                //entre corchetes el nombre del campo como está en la base de datos
                /**txtidProducto.Text = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
                txtidProveedor.Text = dataGridView1.CurrentRow.Cells["idProveedor"].Value.ToString();**/
                txtDiasRetardo.Text = dataGridView1.CurrentRow.Cells["diasRetardo"].Value.ToString();
                txtPrecioEstandar.Text = dataGridView1.CurrentRow.Cells["precioEstandar"].Value.ToString();
                txtPrecioUCompra.Text = dataGridView1.CurrentRow.Cells["precioUltimaCompra"].Value.ToString();
                txtCantMinima.Text = dataGridView1.CurrentRow.Cells["cantMinPedir"].Value.ToString();
                txtCantMaxima.Text = dataGridView1.CurrentRow.Cells["cantMaxPedir"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione el producto del proveedor que quiere editar.");
        }

        private void retroceder_Click(object sender, EventArgs e)
        {
            if (pag == 1)
            {
                retroceder.Enabled = false;
                MostrarProductosProveedor();
            }
            else
            {
                pag--;
                avanza.Enabled = true;
                MostrarProductosProveedor();
            }
            Console.WriteLine(pag);
        }

        private void avanza_Click(object sender, EventArgs e)
        {
            if (pag == numPags)
            {
                avanza.Enabled = false;
                MostrarProductosProveedor();
            }
            else
            {
                pag++;
                retroceder.Enabled = true;
                MostrarProductosProveedor();
            }
        }
    }
}
