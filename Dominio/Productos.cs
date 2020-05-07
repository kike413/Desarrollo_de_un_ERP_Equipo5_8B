using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Dominio
{
    public class Productos
    {
         
        private ProductosDAO pdao = new Datos.ProductosDAO();

        public DataTable MostrarProducto(int pagina)
        {
            DataTable tabla = new DataTable();
            tabla = pdao.Mostrar(pagina);
            return tabla;
        }

        public void InsertarProducto(string nombre, string descripcion, string puntoReorden, string genero,
            string precioCompra, string precioVenta, string materia, string idMarca, string idEstilo,string idCategoria)
        {
            pdao.Insertar(nombre,descripcion,Convert.ToInt32(puntoReorden),genero,Convert.ToSingle(precioCompra),Convert.ToSingle(precioVenta),materia,
                Convert.ToInt32(idMarca),Convert.ToInt32(idEstilo),Convert.ToInt32(idCategoria));
        }

        public void EditarProducto(string nombre, string descripcion, string puntoReorden, string genero,
            string precioCompra, string precioVenta, string materia, string idMarca, string idEstilo, string idProductos, string id)
        {
            pdao.Editar(nombre, descripcion, Convert.ToInt32(puntoReorden), genero, Convert.ToSingle(precioCompra), Convert.ToSingle(precioVenta), materia,
                Convert.ToInt32(idMarca), Convert.ToInt32(idEstilo), Convert.ToInt32(idProductos),
                Convert.ToInt32(id));
        }

        public void EliminarProducto(string id)
        {
            pdao.Eliminar(Convert.ToInt32(id));
        }

        public int obtenerPaginas()
        {
            int pags = pdao.obtenerPaginas();
            return pags;
        }

        public int obtenerIdCat(string campo)
        {
            int ids = pdao.obtenerIdCat(campo);
            return ids;
        }

        public int obtenerIdMar(string campo)
        {
            int ids = pdao.obtenerIdMarca(campo);
            return ids;
        }

        public int obtenerIdEst(string campo)
        {
            int ids = pdao.obtenerIdEstilo(campo);
            return ids;
        }

        public DataTable MostrarProductoFiltro(string filtro)
        {
            DataTable tabla = new DataTable();
            tabla = pdao.MostrarTodo(filtro);
            return tabla;
        }
    }
}
