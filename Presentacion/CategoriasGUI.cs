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
    public partial class CategoriasGUI : Form
    {
        Categorias catN = new Categorias();
        private string idCategoria = null;
        //variable para saber cuando se va a editar.
        private bool editar = false;
        public CategoriasGUI()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            MostrarCategorias();   
        }
        private void MostrarCategorias()
        {
            Categorias catN = new Categorias();
            dataGridView1.DataSource = catN.MostrarCategorias();
            dataGridView1.ClearSelection();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //si hay mas de una columna entonces...
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                //entre corchetes el nombre del campo como está en la base de datos
                txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                idCategoria = dataGridView1.CurrentRow.Cells["idCategoria"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione la categoría que quiere editar.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idCategoria = dataGridView1.CurrentRow.Cells["idCategoria"].Value.ToString();
                catN.EliminarCategoria(idCategoria);
                MessageBox.Show("Eliminado correctamente.");
                MostrarCategorias();
            }
            else
                MessageBox.Show("Seleccione el estilo que quiere editar.");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            borrarError();
            ValidarCampos();
            //insertar registros si no se ha elegido editar
            if (txtNombre.Text == "")
            {
            }
            else if (editar == false)
            {
                try
                {
                    catN.InsertarCategorias(txtNombre.Text);
                    MessageBox.Show("Se insertó correctamente");
                    MostrarCategorias();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro. Error: " + ex);
                }
            }
            //si editar = true entonces editamos xd
            if (txtNombre.Text == "")
            {
            }
            else if (editar == true)
            {
                try
                {
                    catN.EditarCategoria(txtNombre.Text, idCategoria);
                    MessageBox.Show("Se editó correctamente");
                    MostrarCategorias();
                    editar = false;
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro. Error: " + ex);
                }
            }
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

        private bool ValidarCampos()
        {
            bool ok = true;
            if (txtNombre.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtNombre, "Introduce el nombre de la categoría.");
            }
            return ok;
        }

        private void borrarError()
        {
            errorProvider1.SetError(txtNombre, "");
        }

        /**
        * Método para limpiar los campos después de editar o insertar
        * 
        */

        private void limpiar()
        {
            txtNombre.Clear();
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            PrincipalGUI principal = new PrincipalGUI();
            principal.Show();
            this.Hide();
        }
    }
}
