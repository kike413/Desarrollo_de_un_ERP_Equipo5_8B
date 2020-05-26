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
    public partial class CuentasProveedorGUI : Form
    {

        CuentasProveedor cN = new CuentasProveedor();
        private string idProveedor = null;
        private string noCuenta = null;
        private string banco = null;
        //variable para saber cuando se va a editar.
        private bool editar = false;
        private int pag = 1;
        private int numPags = 0;
        private int auxiliar = 0;
        private string campo = "";

        public CuentasProveedorGUI()
        {
            InitializeComponent();
        }

        private void CuentasProveedorGUI_Load(object sender, EventArgs e)
        {
            MostrarCuentas();
            numPags = cN.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
            ListarProveedores();
            comboProveedor.ResetText();
            txtnoCuenta.MaxLength=10;
        }
        public void MostrarCuentas()
        {
            CuentasProveedor cN = new CuentasProveedor();
            numPags = cN.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
            if (numPags < auxiliar && pag >= numPags)
            {
                pag--;
                dataGridView1.DataSource = cN.MostrarCuentas(pag);
                dataGridView1.ClearSelection();
            }
            else
            {
                dataGridView1.DataSource = cN.MostrarCuentas(pag);
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
            CuentasProveedor cN = new CuentasProveedor();
            cN.ListarProveedores(comboProveedor);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //si hay mas de una columna entonces...
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                //entre corchetes el nombre del campo como está en la base de datos
                comboProveedor.Text = dataGridView1.CurrentRow.Cells["Proveedor"].Value.ToString();
                txtnoCuenta.Text = dataGridView1.CurrentRow.Cells["noCuenta"].Value.ToString();
                txtBanco.Text = dataGridView1.CurrentRow.Cells["banco"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione el pedido que quiere editar.");
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            PrincipalGUI principal = new PrincipalGUI();
            principal.Show();
            this.Hide();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProveedor = dataGridView1.CurrentRow.Cells["Proveedor"].Value.ToString();
                noCuenta = dataGridView1.CurrentRow.Cells["noCuenta"].Value.ToString();
                banco = dataGridView1.CurrentRow.Cells["banco"].Value.ToString();
                cN.EliminarCuenta(Convert.ToInt32(comboProveedor.SelectedValue), noCuenta, banco);
                MessageBox.Show("Eliminado correctamente.");
                MostrarCuentas();
            }
            else
                MessageBox.Show("Seleccione el registro que quiere eliminar.");
        }

        private void retroceder_Click(object sender, EventArgs e)
        {
            if (pag == 1)
            {
                retroceder.Enabled = false;
                MostrarCuentas();
            }
            else
            {
                pag--;
                avanza.Enabled = true;
                MostrarCuentas();
            }
        }

        private void avanza_Click(object sender, EventArgs e)
        {
            if (pag == numPags)
            {
                avanza.Enabled = false;
                MostrarCuentas();
            }
            else
            {
                pag++;
                retroceder.Enabled = true;
                MostrarCuentas();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            {
                borrarError();
                ValidarCampos();
                //insertar registros si no se ha elegido editar
                if (comboProveedor.Text == "" || txtnoCuenta.Text == "" || txtBanco.Text == "")
                {
                }
                else if (editar == false)
                {
                    try
                    {
                        cN.insertarCuenta(Convert.ToInt32(comboProveedor.SelectedValue), txtnoCuenta.Text, txtBanco.Text);
                        MessageBox.Show("Se insertó correctamente");
                        MostrarCuentas();
                        limpiar();
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo guardar el registro. Error: " + ex);
                    }
                }
                //si editar = true entonces editamos xd
                if (comboProveedor.Text == "" || txtnoCuenta.Text == "" || txtBanco.Text == "")
                {
                }
                else if (editar == true)
                {
                    try
                    {
                        cN.EditarCuenta(Convert.ToInt32(comboProveedor.SelectedValue), txtnoCuenta.Text, txtBanco.Text);

                        MessageBox.Show("Se editó correctamente");
                        MostrarCuentas();
                        editar = false;
                        limpiar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo editar el registro. Error: " + ex);
                    }
                }
            }
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtnoCuenta.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtnoCuenta, "Debe escribir número de cuenta");
            }
            else if (txtBanco.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtBanco, "Debe escribir el nombre de un banco");
            }
            else if (comboProveedor.Text == "")
            {
                ok = false;
                errorProvider1.SetError(comboProveedor, "Debe elegir un proveedor.");
            }
            return ok;
        }

        private void borrarError()
        {
            errorProvider1.SetError(comboProveedor, "");
            errorProvider1.SetError(txtnoCuenta, "");
            errorProvider1.SetError(txtBanco, "");

        }

        /**
        * Método para limpiar los campos después de editar o insertar
        * 
        */

        private void limpiar()
        {
            txtnoCuenta.Clear();
            txtBanco.Clear();
            comboProveedor.ResetText();
        }

        private void txtnoCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47 || (e.KeyChar >= 58 && e.KeyChar <= 255)))
            {
                MessageBox.Show("Solo se admiten números enteros", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64 || (e.KeyChar >= 91 && e.KeyChar <= 96)))
            {
                MessageBox.Show("Solo se admiten letras", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
