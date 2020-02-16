using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Datos;

namespace Dominio
{
    public class Usuario
    {
        UsuarioDAO usuariodao = new UsuarioDAO();

        public bool login(string usuario,string password)
        {
            return usuariodao.Login(usuario,password);
        }
    }
}
