using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Dominio
{
    
    public class Provedores
    {
        private ProveedoresDAO provedores = new ProveedoresDAO();
        public DataTable MostrarProveedores(int pagina)
        {
            DataTable tabla = new DataTable();
            tabla = provedores.Mostrar(pagina);
            return tabla;
        }

        public void InsertarProveedores(string nombre, string Telefono,string email, string direcion, string colonia, string codigoP, string idCiudad)
        {
            provedores.Insertar(nombre, Telefono,email, direcion, colonia, codigoP, Convert.ToInt32(idCiudad));
        }

        public void EditarProveedores(string nombre, string Telefono,string email, string direcion, string colonia, string codigoP, string idCiudad, string id)
        {
            provedores.Editar(nombre, Telefono,email, direcion, colonia, codigoP, Convert.ToInt32(idCiudad), Convert.ToInt32(id));
        }

        public void EliminarProveedores(string id)
        {
            provedores.Eliminar(Convert.ToInt32(id));
        }
        public int obtenerPaginas()
        {
            int pags = provedores.obtenerPaginas();
            return pags;
        }
    }
}
