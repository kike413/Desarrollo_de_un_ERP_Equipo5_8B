using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Dominio
{
    
    public class Marcas
    {
        private MarcasDAO mdao = new MarcasDAO();
        public DataTable MostrarMarcas(int pagina)
        {
            DataTable tabla = new DataTable();
            tabla = mdao.Mostrar(pagina);
            return tabla;
        }

        public void InsertarMarca(string nombre,string origen)
        {
            mdao.Insertar(nombre,origen);
        }

        public void EditarMarca(string nombre, string origen,string id)
        {
            mdao.Editar(nombre,origen, Convert.ToInt32(id));
        }

        public void EliminarMarca(string id)
        {
            mdao.Eliminar(Convert.ToInt32(id));
        }
        public int obtenerPaginas()
        {
            int pags = mdao.obtenerPaginas();
            return pags;
        }
    }
}
