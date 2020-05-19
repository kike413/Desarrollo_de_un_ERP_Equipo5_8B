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
    public partial class ProveedoresGUI : Form
    {
        Provedores proveedoresN = new Provedores();
        //variable para recuperar el id del estilo seleccionado
        private string idProveedor = null;
        //variable para saber cuando se va a editar.
        private bool editar = false;
        private int pag = 1;
        private int numPags = 0;
        private int auxiliar = 0;

        public ProveedoresGUI()
        {
            InitializeComponent();
        }


        private void MostrarProveedores()
        {
            Provedores proveedoresN = new Provedores();
            numPags = proveedoresN.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
            if (numPags < auxiliar && pag >= numPags)
            {
                pag--;
                dataGridView1.DataSource = proveedoresN.MostrarProveedores(pag);
                dataGridView1.ClearSelection();
            }
            else
            {
                dataGridView1.DataSource = proveedoresN.MostrarProveedores(pag);
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

        private void limpiar()
        {
            txtNombre.Clear();
            txtCodigop.Clear();
            txtColonia.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtCiudad.Clear();
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtNombre.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtNombre, "Introduce el nombre del Proveedor.");
            }
            else if (txtTelefono.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtTelefono, "Introduce el Telefono");
            }
            else if (txtEmail.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtEmail, "Introduce el email");
            }
            else if (txtDireccion.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtDireccion, "Introduce la Direccion");
            }
            else if (txtColonia.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtColonia, "Introduce el nombre la colonia.");
            }
            else if (txtCodigop.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtCodigop, "Introduce el codigo postal");
            }
            else if (txtCiudad.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtCiudad, "Introduce la ciudad postal");
            }
            return ok;
        }
        private void borrarError()
        {
            errorProvider1.SetError(txtNombre, "");
            errorProvider1.SetError(txtTelefono, "");
            errorProvider1.SetError(txtEmail, "");
            errorProvider1.SetError(txtDireccion, "");
            errorProvider1.SetError(txtColonia, "");
            errorProvider1.SetError(txtCodigop, "");
            errorProvider1.SetError(txtCiudad, "");
        }

  


        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            borrarError();
            ValidarCampos();
            //insertar registros si no se ha elegido editar
            if (txtNombre.Text == "" || txtTelefono.Text == "" || txtEmail.Text == "" || txtDireccion.Text == "" || txtColonia.Text == "" || txtCodigop.Text == "")
            {
            }
            else if (editar == false)
            {
                try
                {
                    proveedoresN.InsertarProveedores(txtNombre.Text, txtTelefono.Text, txtEmail.Text, txtDireccion.Text, txtColonia.Text, txtCodigop.Text,txtCiudad.Text);
                    MessageBox.Show("Se insertó correctamente");
                    MostrarProveedores();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro. Error: " + ex);
                }
            }

            if (txtNombre.Text == "" || txtTelefono.Text == "" || txtEmail.Text == "" || txtDireccion.Text == "" || txtColonia.Text == "" || txtCodigop.Text == "")
            {
            }
            else if (editar == true)
            {
                try
                {
                    proveedoresN.EditarProveedores(txtNombre.Text, txtTelefono.Text, txtEmail.Text, txtDireccion.Text, txtColonia.Text, txtCodigop.Text,txtCiudad.Text, idProveedor);
                    MessageBox.Show("Se editó correctamente");
                    MostrarProveedores();
                    editar = false;
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro. Error: " + ex);
                }
            }
        }

        private void ProveedoresGUI_Load(object sender, EventArgs e)
        {
            MostrarProveedores();
            numPags = proveedoresN.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
        }

        private void retroceder_Click_1(object sender, EventArgs e)
        {
            if (pag == 1)
            {
                retroceder.Enabled = false;
                MostrarProveedores();
            }
            else
            {
                pag--;
                avanza.Enabled = true;
                MostrarProveedores();
            }
        }

        private void avanza_Click_1(object sender, EventArgs e)
        {
            if (pag == numPags)
            {
                avanza.Enabled = false;
                MostrarProveedores();
            }
            else
            {
                pag++;
                retroceder.Enabled = true;
                MostrarProveedores();
            }
        }

        private void Regresar_Click_1(object sender, EventArgs e)
        {
            PrincipalGUI principal = new PrincipalGUI();
            principal.Show();
            this.Hide();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 32 && e.KeyChar <= 64 || (e.KeyChar >= 91 && e.KeyChar <= 96)))
            {
                MessageBox.Show("Solo se admiten letras", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 44 || (e.KeyChar == 46) || (e.KeyChar >= 58 && e.KeyChar <= 255)))
            {
                MessageBox.Show("Solo se admiten números enteros o guión", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtColonia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64 || (e.KeyChar >= 91 && e.KeyChar <= 96)))
            {
                MessageBox.Show("Solo se admiten letras", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCodigop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47 || (e.KeyChar >= 58 && e.KeyChar <= 255)))
            {
                MessageBox.Show("Solo se admiten números enteros", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47 || (e.KeyChar >= 58 && e.KeyChar <= 255)))
            {
                MessageBox.Show("Solo se admiten números enteros", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //si hay mas de una columna entonces...
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                //entre corchetes el nombre del campo como está en la base de datos
                txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells["telefono"].Value.ToString();
               txtEmail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells["direccion"].Value.ToString();
                txtColonia.Text = dataGridView1.CurrentRow.Cells["colonia"].Value.ToString();
                txtCodigop.Text = dataGridView1.CurrentRow.Cells["codigopostal"].Value.ToString();
                txtCiudad.Text = Convert.ToString(proveedoresN.obtenerIdCiudad(dataGridView1.CurrentRow.Cells["ciudad"].Value.ToString()));
                idProveedor = dataGridView1.CurrentRow.Cells["idProveedor"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione la categoría que quiere editar.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProveedor = dataGridView1.CurrentRow.Cells["idProveedor"].Value.ToString();
                proveedoresN.EliminarProveedores(idProveedor);
                MessageBox.Show("Eliminado correctamente.");
                MostrarProveedores();
            }
            else
                MessageBox.Show("Seleccione el provedor que quiere editar.");
        }

        private void buscador_TextChanged(object sender, EventArgs e)
        {
            if (buscador.Text == "")
            {
                MostrarProveedores();
            }
            else
            {
                dataGridView1.DataSource = proveedoresN.MostrarProveedoresFiltro(buscador.Text);
                dataGridView1.ClearSelection();
            }
        }

        private void btnProductosProveedor_Click(object sender, EventArgs e)
        {
            ProductosProveedorGUI ProPro = new ProductosProveedorGUI();
            ProPro.Show();
            this.Hide();
        }
    }
}
