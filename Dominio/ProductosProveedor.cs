using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Dominio
{
    public class ProductosProveedor
    {
        private ProductosProveedorDAO PPDAO = new ProductosProveedorDAO();
        
        public DataTable MostrarProductosProveedorDAO(int pagina)
        {
            DataTable tabla = new DataTable();
            tabla = PPDAO.Mostrar(pagina);
            return tabla;
        }

        public void InsertarProductosProveedor(string diasRetardo, string precioEstandar, string precioUltimaCompra, string cantMinPedir, string cantMaxPedir)
        {//Convert.ToString()
            PPDAO.Insertar(Convert.ToInt32(diasRetardo), Convert.ToSingle(precioEstandar), Convert.ToSingle(precioUltimaCompra), Convert.ToInt32(cantMinPedir), Convert.ToInt32(cantMaxPedir));
        }

        public void EditarProductosProveedor (string diasRetardo, string precioEstandar, string precioUltimaCompra, string cantMinPedir, string cantMaxPedir, string id)
        {
            PPDAO.Editar(Convert.ToInt32(diasRetardo), Convert.ToSingle(precioEstandar), Convert.ToSingle(precioUltimaCompra), Convert.ToInt32(cantMinPedir), cantMaxPedir, Convert.ToInt32(id));
        }

        public void EliminarProductosProveedor(string id)
        {
            PPDAO.Eliminar(Convert.ToInt32(id));
        }

        public int obtenerPaginas()
        {
            int pags = PPDAO.obtenerPaginas();
            return pags;
        }
        /**public int obtenerIdColor(string campo)
        {
            int ids = DPDAO.obtenerIdColor(campo);
            return ids;
        }**/

        public int obtenerIdProducto(string campo)
        {
            int ids = PPDAO.obtenerIdProducto(campo);
            return ids;
        }
    }
}
