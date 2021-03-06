﻿using System;
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
        private int pag = 1;
        private int numPags = 0;
        private int auxiliar = 0;
        public MarcasGUI()
        {
            InitializeComponent();
        }

        private void MostrarMarcas() {
            Marcas marcasN = new Marcas();
            numPags = marcasN.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
            if (numPags < auxiliar && pag >= numPags)
            {
                pag--;
                dataGridView1.DataSource = marcasN.MostrarMarcas(pag);
                dataGridView1.ClearSelection();
            }
            else
            {
                dataGridView1.DataSource = marcasN.MostrarMarcas(pag);
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
            numPags = marcasN.obtenerPaginas();
            Console.WriteLine("numero de paginas " + numPags);
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
                MostrarMarcas();
            }
            else
            {
                pag--;
                avanza.Enabled = true;
                MostrarMarcas();
            }
        }

        private void avanza_Click(object sender, EventArgs e)
        {
            if (pag == numPags)
            {
                avanza.Enabled = false;
                MostrarMarcas();
            }
            else
            {
                pag++;
                retroceder.Enabled = true;
                MostrarMarcas();
            }
        }
    }
}
