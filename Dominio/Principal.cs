using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Datos;

namespace Dominio
{
    public class Principal
    {
        private PrincipalDAO principaldao = new PrincipalDAO();
        public void seleccionNombre(string nombre)
        {
            principaldao.SeleccionarNombre(nombre);
        }
    }
}
