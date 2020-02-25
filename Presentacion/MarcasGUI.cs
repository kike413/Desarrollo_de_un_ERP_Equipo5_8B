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
    public partial class MarcasGUI : Form
    {
        Marcas marcasN = new Marcas();
        //variable para recuperar el id del estilo seleccionado
        private string idMarca = null;
        //variable para saber cuando se va a editar.
        private bool editar = false;
        public MarcasGUI()
        {
            InitializeComponent();
        }

        private void MostrarMarcas() {
            Marcas marcasN = new Marcas();
            dataGridView1.DataSource = marcasN.MostrarMarcas();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            borrarError();
            ValidarCampos();
            //insertar registros si no se ha elegido editar
            if (txtNombre.Text == "" || txtOrigen.Text =="")
            {
            }
            else if (editar == false)
            {
                try
                {
                    marcasN.InsertarMarca(txtNombre.Text,txtOrigen.Text);
                    MessageBox.Show("Se insertó correctamente");
                    MostrarMarcas();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro. Error: " + ex);
                }
            }
            //si editar = true entonces editamos xd
            if (txtNombre.Text == "" || txtOrigen.Text=="")
            {
            }
            else if (editar == true)
            {
                try
                {
                    marcasN.EditarMarca(txtNombre.Text,txtOrigen.Text, idMarca);
                    MessageBox.Show("Se editó correctamente");
                    MostrarMarcas();
                    editar = false;
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro. Error: " + ex);
                }
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
                txtOrigen.Text = dataGridView1.CurrentRow.Cells["origen"].Value.ToString();
                idMarca = dataGridView1.CurrentRow.Cells["idMarca"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione la marca que quiere editar.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idMarca = dataGridView1.CurrentRow.Cells["idMarca"].Value.ToString();
                marcasN.EliminarMarca(idMarca);
                MessageBox.Show("Eliminado correctamente.");
                MostrarMarcas();
            }
            else
                MessageBox.Show("Seleccione la fila que quiere editar.");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void limpiar()
        {
            txtNombre.Clear();
            txtOrigen.Clear();
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtNombre.Text == "")
            {
                ok = false;
                error.SetError(txtNombre, "Introduce el nombre de la marca.");
            }else if (txtOrigen.Text == "")
            {
                ok = false;
                error.SetError(txtOrigen, "Introduce el origen de la marca");
            }
            return ok;
        }
        private void borrarError()
        {
            error.SetError(txtNombre, "");
            error.SetError(txtOrigen, "");
        }

        //validacion para que solo ingrese letras

        private void txtOrigen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64 || (e.KeyChar >= 91 && e.KeyChar <= 96)))
            {
                MessageBox.Show("Solo se admiten letras", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void MarcasGUI_Load(object sender, EventArgs e)
        {
            MostrarMarcas();
        }

        private void txtNombre_KeyPress_1(object sender, KeyPressEventArgs e)
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
