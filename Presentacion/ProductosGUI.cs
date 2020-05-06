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
    public partial class ProductosGUI : Form
    {

        Productos prodN = new Productos();
        private string idProducto = null;
        //variable para saber cuando se va a editar.
        private bool editar = false;
        private int pag = 1;
        private int numPags = 0;
        private int auxiliar = 0;
        public ProductosGUI()
        {
            InitializeComponent();
        }

        private void ProductosGUI_Load(object sender, EventArgs e)
        {
            MostrarProductos();
            numPags = prodN.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
        }
        private void MostrarProductos()
        {
            Productos prodN = new Productos();
            numPags = prodN.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
            if (numPags < auxiliar && pag >= numPags)
            {
                pag--;
                dataGridView1.DataSource = prodN.MostrarProducto(pag);
                dataGridView1.ClearSelection();
            }
            else
            {
                dataGridView1.DataSource = prodN.MostrarProducto(pag);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
                prodN.EliminarProducto(idProducto);
                MessageBox.Show("Eliminado correctamente.");
                MostrarProductos();
            }
            else
                MessageBox.Show("Seleccione el producto que quiere editar.");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //si hay mas de una columna entonces...
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                //entre corchetes el nombre del campo como está en la base de datos
                txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                txtPuntoReo.Text = dataGridView1.CurrentRow.Cells["puntoReorden"].Value.ToString();
                txtGenero.Text = dataGridView1.CurrentRow.Cells["genero"].Value.ToString();
                txtPrecioCompra.Text = dataGridView1.CurrentRow.Cells["precioCompra"].Value.ToString();
                txtPrecioVenta.Text = dataGridView1.CurrentRow.Cells["precioVenta"].Value.ToString();
                txtMaterial.Text = dataGridView1.CurrentRow.Cells["materia"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["idMarca"].Value.ToString();
                txtEstilo.Text = dataGridView1.CurrentRow.Cells["idEstilo"].Value.ToString();
                txtCategoria.Text = dataGridView1.CurrentRow.Cells["idCategoria"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione la categoría que quiere editar.");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
                borrarError();
                ValidarCampos();
            //insertar registros si no se ha elegido editar
            if (txtNombre.Text == "" || txtDescripcion.Text == "" || txtPuntoReo.Text == "" || txtGenero.Text == "" || txtPrecioCompra.Text == "" || txtPrecioVenta.Text == "" || txtEstilo.Text=="" || txtMaterial.Text=="" || txtMarca.Text=="" ||txtCategoria.Text=="") 
                {
                }
                else if (editar == false)
                {
                    try
                    {
                        prodN.InsertarProducto(txtNombre.Text,txtDescripcion.Text,txtPuntoReo.Text,
                            txtGenero.Text,txtPrecioCompra.Text,txtPrecioVenta.Text,txtMaterial.Text,txtMarca.Text,
                            txtEstilo.Text,txtCategoria.Text
                            );
                        MessageBox.Show("Se insertó correctamente");
                        MostrarProductos();
                        limpiar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo guardar el registro. Error: " + ex);
                    }
                }
                //si editar = true entonces editamos xd
                if (txtNombre.Text == "" || txtDescripcion.Text == "" || txtPuntoReo.Text == "" || txtGenero.Text == "" || txtPrecioCompra.Text == "" || txtPrecioVenta.Text == "" || txtEstilo.Text == "" || txtMaterial.Text == "" || txtMarca.Text == "" || txtCategoria.Text == "")
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
                    }
                }
            }
        
        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtNombre.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtNombre, "Introduce el nombre del producto.");
            }
            else if (txtDescripcion.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtDescripcion, "Introduce la descripción del producto.");
            }
            else if (txtPuntoReo.Text  == "")
            {
                ok = false;
                errorProvider1.SetError(txtPuntoReo, "Introduce el punto de reorden del producto.");
            }
            else if (txtGenero.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtGenero, "Introduce el genero del producto.");
            }
            else if (txtPrecioCompra.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtPrecioCompra, "Introduce el precio compra del producto.");
            }
            else if (txtPrecioVenta.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtPrecioVenta, "Introduce el precio venta del producto.");
            }
            else if (txtMaterial.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtMaterial, "Introduce el material que esta hecho el producto.");
            }
            else if (txtEstilo.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtEstilo, "Introduce el estilo del producto.");
            }
            else if (txtMarca.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtMarca, "Introduce la marca del producto.");
            }
            else if (txtCategoria.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtCategoria, "Introduce la categoría del producto.");
            }
            return ok;
        }

        private void borrarError()
        {
            errorProvider1.SetError(txtNombre, "");
            errorProvider1.SetError(txtDescripcion, "");
            errorProvider1.SetError(txtPuntoReo, "");
            errorProvider1.SetError(txtPrecioCompra, "");
            errorProvider1.SetError(txtPrecioVenta, "");
            errorProvider1.SetError(txtGenero, "");
            errorProvider1.SetError(txtMaterial, "");
            errorProvider1.SetError(txtMarca, "");
            errorProvider1.SetError(txtEstilo, "");
            errorProvider1.SetError(txtCategoria, "");

        }

        /**
        * Método para limpiar los campos después de editar o insertar
        * 
        */

        private void limpiar()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPuntoReo.Clear();
            txtGenero.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
            txtMarca.Clear();
            txtMaterial.Clear();
            txtEstilo.Clear();
            txtCategoria.Clear();
        }

        private void retroceder_Click(object sender, EventArgs e)
        {

            if (pag == 1)
            {
                retroceder.Enabled = false;
                MostrarProductos();
            }
            else
            {
                pag--;
                avanza.Enabled = true;
                MostrarProductos();
            }
            Console.WriteLine(pag);
        }

        private void avanza_Click(object sender, EventArgs e)
        {
            if (pag == numPags)
            {
                avanza.Enabled = false;
                MostrarProductos();
            }
            else
            {
                pag++;
                retroceder.Enabled = true;
                MostrarProductos();
            }
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            PrincipalGUI principal = new PrincipalGUI();
            principal.Show();
            this.Hide();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64 || (e.KeyChar >= 91 && e.KeyChar <= 96)))
            {
                MessageBox.Show("Solo se admiten letras", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPuntoReo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47  || (e.KeyChar >=58 && e.KeyChar <=255)))
            {
                MessageBox.Show("Solo se admiten números enteros", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void txtGenero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 69 || (e.KeyChar >= 71 && e.KeyChar <= 76) ||
                (e.KeyChar >= 78 && e.KeyChar <= 101) || (e.KeyChar >= 103 && e.KeyChar <= 108)
                || (e.KeyChar >= 110 && e.KeyChar <= 255)))
            {
                MessageBox.Show("Solo se admiten las letras 'F' y 'M'", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45 || (e.KeyChar == 47) || (e.KeyChar >= 58 && e.KeyChar <= 255)))
            {
                MessageBox.Show("Solo se admiten números enteros o con decimal", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45 || (e.KeyChar == 47) || (e.KeyChar >= 58 && e.KeyChar <= 255)))
            {
                MessageBox.Show("Solo se admiten números enteros o con decimal", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64 || (e.KeyChar >= 91 && e.KeyChar <= 96)))
            {
                MessageBox.Show("Solo se admiten letras", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47 || (e.KeyChar >= 58 && e.KeyChar <= 255)))
            {
                MessageBox.Show("Solo se admiten números enteros", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtEstilo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47 || (e.KeyChar >= 58 && e.KeyChar <= 255)))
            {
                MessageBox.Show("Solo se admiten números enteros", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47 || (e.KeyChar >= 58 && e.KeyChar <= 255)))
            {
                MessageBox.Show("Solo se admiten números enteros", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
    }

