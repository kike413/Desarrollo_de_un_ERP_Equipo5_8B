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
    public partial class EstilosGui : Form
    {
        Estilos estilosN = new Estilos();
        //variable para recuperar el id del estilo seleccionado
        private string idEstilo = null;
        //variable para saber cuando se va a editar.
        private bool editar = false;
        public EstilosGui()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EstilosGui_Load(object sender, EventArgs e)
        {
            MostrarEstilos();
        }

        private void MostrarEstilos()
        {
            Estilos estilosN = new Estilos();
            dataGridView1.DataSource = estilosN.MostrarEstilos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            borrarError();
            ValidarCampos();
            //insertar registros si no se ha elegido editar
            if (txtNombre.Text == "")
            {
            }
            else if(editar==false){
                try
                {
                    estilosN.InsertarEstilo(txtNombre.Text);
                    MessageBox.Show("Se insertó correctamente");
                    MostrarEstilos();
                    limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro. Error: " + ex);
                }
            }
            //si editar = true entonces editamos xd
            if (txtNombre.Text=="")
            {
            }
            else if (editar == true)
            {
                try
                {
                    estilosN.EditarEstilo(txtNombre.Text,idEstilo);
                    MessageBox.Show("Se editó correctamente");
                    MostrarEstilos();
                    editar = false;
                    limpiar();
                }
                catch(Exception ex)
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
                idEstilo = dataGridView1.CurrentRow.Cells["idEstilo"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione el estilo que quiere editar.");
        }

        /**
         * Método para limpiar los campos después de editar o insertar
         * 
         */

        private void limpiar()
        {
            txtNombre.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idEstilo = dataGridView1.CurrentRow.Cells["idEstilo"].Value.ToString();
                estilosN.EliminarEstilo(idEstilo);
                MessageBox.Show("Eliminado correctamente.");
                MostrarEstilos();
            }
            else
                MessageBox.Show("Seleccione el estilo que quiere editar.");
        }


        private bool ValidarCampos()
        {
            bool ok = true;
            if(txtNombre.Text == "")
            {
                ok = false;
               error.SetError(txtNombre, "Introduce el nombre del estilo.");
            }
            return ok;
        }

        private void borrarError()
        {
            error.SetError(txtNombre, "");
        }

        //validacion para que solo ingrese letras
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar >= 32 && e.KeyChar <=64 || (e.KeyChar >= 91 && e.KeyChar <= 96)))
            {
                MessageBox.Show("Solo se admiten letras", "Advertencia", MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
