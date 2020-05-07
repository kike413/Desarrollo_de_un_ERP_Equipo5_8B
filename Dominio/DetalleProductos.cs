using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Dominio
{
    public class DetalleProductos
    {
        private DetalleProductosDAO DPDAO = new DetalleProductosDAO();

        public DataTable MostrarDetalleProductos(int pagina)
        {
            DataTable tabla = new DataTable();
            tabla = DPDAO.Mostrar(pagina);
            return tabla;
        }

        public void InsertarDetalleProductos(string talla, string existencia,string idcolor,string idproducto)
        {//Convert.ToString()
            DPDAO.Insertar(Convert.ToSingle(talla), Convert.ToInt32(existencia),Convert.ToInt32(idcolor),Convert.ToInt32(idproducto));
        }

        public void EditarDetalleProductos(string talla, string existencia, string idcolor, string idproducto,
            string id)
        {
            DPDAO.Editar(Convert.ToSingle(talla), Convert.ToInt32(existencia), Convert.ToInt32(idcolor), Convert.ToInt32(idproducto), 
                Convert.ToInt32(id));
        }

        public void EliminarDetalleProductos(string id)
        {
            DPDAO.Eliminar(Convert.ToInt32(id));
        }

        public int obtenerPaginas()
        {
            int pags = DPDAO.obtenerPaginas();
            return pags;
        }
        public int obtenerIdColor(string campo)
        {
            int ids = DPDAO.obtenerIdColor(campo);
            return ids;
        }

        public int obtenerIdProducto(string campo)
        {
            int ids = DPDAO.obtenerIdProducto(campo);
            return ids;
        }

    }
}
