using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Dominio;

namespace Presentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if(txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true; //para que salga como asteriscos
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text != "Usuario")
            {
                if (txtPass.Text != "Contraseña") {
                    Usuario user = new Usuario();
                    var loginValido = user.login(txtUsuario.Text, txtPass.Text);
                    if(loginValido == true)
                    {
                        /*aqui debe hacer referencia a la principal
                        creando un objeto del tipo del form principal como
                        principal ventanaP =  new principal()
                        ventanaP.show();
                        this.hide para ocultar el login
                     */
                        msgError("Bien alli crack");
                    }
                    else
                    {
                        msgError("Usuario o contraseña incorrectos. \n Intente de nuevo.");
                        txtPass.Clear();
                        txtUsuario.Focus();
                    }
                }
                else msgError("Debe ingresar su contraseña");
            }
            else msgError("Debe ingresar un usuario");
        }
        //mostrar mensaje de error si el login esta mal
        private void msgError(string msg)
        {
            lblError.Text = "   " + msg;
            lblError.Visible = true; 
        }
    }
}
