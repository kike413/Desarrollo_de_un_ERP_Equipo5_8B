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
    public partial class ContactosProveedorGUI : Form
    {
        ContactosProveedor ContacProve = new ContactosProveedor();
        //variable para recuperar el id del estilo seleccionado
        private string idContacto = null;
        private string idProveedor = null;
        //variable para saber cuando se va a editar.
        private bool editar = false;
        private int pag = 1;
        private int numPags = 0;
        private int auxiliar = 0;

        public ContactosProveedorGUI()
        {
            InitializeComponent();
        }


        private void MostrarContactosProveedor()
        {
            ContactosProveedor ContacProve = new ContactosProveedor();
            numPags = ContacProve.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
            if (numPags < auxiliar && pag >= numPags)
            {
                pag--;
                dataGridView1.DataSource = ContacProve.MostrarContactosProveedor(pag);
                dataGridView1.ClearSelection();
            }
            else
            {
                dataGridView1.DataSource = ContacProve.MostrarContactosProveedor(pag);
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
            txtTelefono.Clear();
            txtEmail.Clear();
            //comboidProveedor.Clear();
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtNombre.Text == "")
            {
                ok = false;
                error.SetError(txtNombre, "Introduce el nombre del Proveedor.");
            }
            else if (txtTelefono.Text == "")
            {
                ok = false;
                error.SetError(txtTelefono, "Introduce el Telefono");
            }
            else if (txtEmail.Text == "")
            {
                ok = false;
                error.SetError(txtEmail, "Introduce el email");
            }
            else if (comboidProveedor.Text == "")
            {
                ok = false;
                error.SetError(comboidProveedor, "Introduce el id del proveedor");
            }
            return ok;
        }
        private void borrarError()
        {
            error.SetError(txtNombre, "");
            error.SetError(txtTelefono, "");
            error.SetError(txtEmail, "");
            error.SetError(comboidProveedor, "");
        }


        private void ContactosProveedor_Load(object sender, EventArgs e)
        {
            MostrarContactosProveedor();
            numPags = ContacProve.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
            ListarProveedor();
            comboidProveedor.ResetText();
        }

        /*
        * Mostrar Proveedor en combobox
        */
        public void ListarProveedor()
        {
            ContactosProveedor contactos = new ContactosProveedor();
            contactos.ListarProveedor(comboidProveedor);
        }

        private void btnProductosProveedor_Click(object sender, EventArgs e)
        {
            ProductosProveedorGUI ProPro = new ProductosProveedorGUI();
            ProPro.Show();
            this.Hide();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            borrarError();
            ValidarCampos();
            //insertar registros si no se ha elegido editar
            if (txtNombre.Text == "" || txtTelefono.Text == "" || txtEmail.Text == "" || comboidProveedor.Text == "")
            {
            }
            else if (editar == false)
            {
                try
                {
                    ContacProve.InsertarContactosProveedor(txtNombre.Text, txtTelefono.Text, txtEmail.Text, comboidProveedor.Text);
                    MessageBox.Show("Se insertó correctamente");
                    MostrarContactosProveedor();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro. Error: " + ex);
                }
            }

            if (txtNombre.Text == "" || txtTelefono.Text == "" || txtEmail.Text == "" || comboidProveedor.Text == "")
            {
            }
            else if (editar == true)
            {
                try
                {
                    ContacProve.EditarContactosProveedor(txtNombre.Text, txtTelefono.Text, txtEmail.Text, comboidProveedor.Text, idContacto);
                    MessageBox.Show("Se editó correctamente");
                    MostrarContactosProveedor();
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

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            //si hay mas de una columna entonces...
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                //entre corchetes el nombre del campo como está en la base de datos
                txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells["telefono"].Value.ToString();
                txtEmail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
                comboidProveedor.Text = dataGridView1.CurrentRow.Cells["idProveedor"].Value.ToString();
                idContacto = dataGridView1.CurrentRow.Cells["idContacto"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione la categoría que quiere editar.");
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idContacto = dataGridView1.CurrentRow.Cells["idContacto"].Value.ToString();
                idProveedor = dataGridView1.CurrentRow.Cells["idProveedor"].Value.ToString();
                ContacProve.EliminarContactosProveedor(idContacto, idProveedor);
                MessageBox.Show("Eliminado correctamente.");
                MostrarContactosProveedor();
            }
            else
                MessageBox.Show("Seleccione el provedor que quiere editar.");
        }

        private void retroceder_Click(object sender, EventArgs e)
        {
            if (pag == 1)
            {
                retroceder.Enabled = false;
                MostrarContactosProveedor();
            }
            else
            {
                pag--;
                avanza.Enabled = true;
                MostrarContactosProveedor();
            }
        }

        private void avanza_Click(object sender, EventArgs e)
        {
            if (pag == numPags)
            {
                avanza.Enabled = false;
                MostrarContactosProveedor();
            }
            else
            {
                pag++;
                retroceder.Enabled = true;
                MostrarContactosProveedor();
            }
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
    }
}
