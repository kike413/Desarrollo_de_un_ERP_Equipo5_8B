using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Dominio
{
    public class Categorias
    {
        private CategoriasDAO categoriasdao = new CategoriasDAO();

        public DataTable MostrarCategorias(int pagina)
        {
            DataTable tabla = new DataTable();
            tabla = categoriasdao.Mostrar(pagina);
            return tabla;
        }

        public void InsertarCategorias(string nombre)
        {
            categoriasdao.Insertar(nombre);
        }

        public void EditarCategoria(string nombre, string id)
        {
            categoriasdao.Editar(nombre, Convert.ToInt32(id));
        }

        public void EliminarCategoria(string id)
        {
           categoriasdao.Eliminar(Convert.ToInt32(id));
        }

        public int obtenerPaginas()
        {
            int pags = categoriasdao.obtenerPaginas();
            return pags;
        }
    }
}
