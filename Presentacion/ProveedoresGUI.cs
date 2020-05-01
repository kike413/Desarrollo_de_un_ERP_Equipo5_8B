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
        private string idMarca = null;
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

        private void btnGuardar_Click(object sender, EventArgs e)
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
                    proveedoresN.InsertarProveedores(txtNombre.Text, txtTelefono.Text, txtEmail.Text, txtDireccion.Text, txtColonia.Text, txtCodigop.Text);
                    MessageBox.Show("Se insertó correctamente");
                    MostrarProveedores();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro. Error: " + ex);
                }
            }
            
            if (editar == true)
            {
                try
                {
                    proveedoresN.EditarProveedores(txtNombre.Text, txtTelefono.Text, txtEmail.Text, txtDireccion.Text, txtColonia.Text, txtCodigop.Text, idMarca);
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

        private void limpiar()
        {
            txtNombre.Clear();
            txtCodigop.Clear();
            txtColonia.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
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
            if (txtEmail.Text == "")
            {
                ok = false;
                error.SetError(txtEmail, "Introduce el email");
            }
            else if (txtDireccion.Text == "")
            {
                ok = false;
                error.SetError(txtDireccion, "Introduce la Direccion");
            }
            if (txtColonia.Text == "")
            {
                ok = false;
                error.SetError(txtColonia, "Introduce el nombre la colonia.");
            }
            else if (txtCodigop.Text == "")
            {
                ok = false;
                error.SetError(txtCodigop, "Introduce el codigo postal");
            }
            return ok;
        }
        private void borrarError()
        {
            error.SetError(txtNombre, "");
            error.SetError(txtTelefono, "");
            error.SetError(txtEmail, "");
            error.SetError(txtDireccion, "");
            error.SetError(txtColonia, "");
            error.SetError(txtCodigop, "");
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            PrincipalGUI principal = new PrincipalGUI();
            principal.Show();
            this.Hide();
        }

        private void retroceder_Click(object sender, EventArgs e)
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

        private void avanza_Click(object sender, EventArgs e)
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


    }
}
