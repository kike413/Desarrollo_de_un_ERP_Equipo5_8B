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

        public void InsertarProveedores(String nombre, CharEnumerator Telefono, CharEnumerator direcion, CharEnumerator colonia, CharEnumerator codigoP, int idCiudad)
        {
            provedores.Insertar(nombre, Telefono, direcion, colonia, codigoP, idCiudad);
        }

        public void EditarProveedores(String nombre, CharEnumerator Telefono, CharEnumerator direcion, CharEnumerator colonia, CharEnumerator codigoP, int idCiudad, int id)
        {
            provedores.Editar(nombre, Telefono, direcion, colonia, codigoP, idCiudad, Convert.ToInt32(id));
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
