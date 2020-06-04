using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Dominio
{
    public class FormasPago
    {
        private FormasPagoDAO formaspagodao = new FormasPagoDAO();

        public DataTable MostrarFormasPago(int pagina)
        {
            DataTable tabla = new DataTable();
            tabla = formaspagodao.Mostrar(pagina);
            return tabla;
        }

        public void InsertarFormasPago(string nombre)
        {
            formaspagodao.Insertar(nombre);
        }

        public void EditarFormasPago(string nombre, string id)
        {
            formaspagodao.Editar(nombre, Convert.ToInt32(id));
        }

        public void EliminarFormasPago(string id)
        {
            formaspagodao.Eliminar(Convert.ToInt32(id));
        }

        public int obtenerPaginas()
        {
            int pags = formaspagodao.obtenerPaginas();
            return pags;
        }
    }
}
