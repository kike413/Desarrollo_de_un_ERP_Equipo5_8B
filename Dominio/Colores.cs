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
    public class Colores
    {
        private ColoresDAO coloresDao = new ColoresDAO();

        public DataTable MostrarColores(int pagina)
        {
            DataTable tabla = new DataTable();
            tabla = coloresDao.Mostrar(pagina);
            return tabla;
        }

        public void InsertarColor(string nombre)
        {
            coloresDao.Insertar(nombre);
        }

        public void EditarColor(string nombre,string id)
        {
            coloresDao.Editar(nombre, Convert.ToInt32(id));
        }

        public void EliminarColor(string id)
        {
            coloresDao.Eliminar(Convert.ToInt32(id));
        }

        public int obtenerPaginas()
        {
            int pags = coloresDao.obtenerPaginas();
            return pags;
        }
    }
}
