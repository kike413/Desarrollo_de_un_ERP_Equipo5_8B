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

        public DataTable MostrarDetalleProductos()
        {
            DataTable tabla = new DataTable();
            tabla = DPDAO.Mostrar();
            return tabla;
        }

        public void InsertarDetalleProductos(string talla, string existencia)
        {//Convert.ToString()
            DPDAO.Insertar(Convert.ToSingle(talla), Convert.ToInt32(existencia));
        }

        public void EditarDetalleProductos(string talla, string existencia, string id)
        {
            DPDAO.Editar(Convert.ToSingle(talla), Convert.ToInt32(existencia), Convert.ToInt32(id));
        }

        public void EliminarDetalleProductos(string id)
        {
            DPDAO.Eliminar(Convert.ToInt32(id));
        }

    }
}
