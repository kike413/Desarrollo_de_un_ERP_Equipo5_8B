using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Dominio
{
    public class PedidoDetalle
    {
        private PedidoDetalleDAO PedidoD = new PedidoDetalleDAO();

        public DataTable MostrarPedidoDetalle(int pagina)
        {
            DataTable tabla = new DataTable();
            tabla = PedidoD.Mostrar(pagina);
            return tabla;
        }

        public void InsertarPedidoDetalle(string idProducto, string idProductoDetalle, string cantPedida, string precioUnitario,string suntotal,string cantRecibida, string cantRechazada, string cantAceptada)
        {//Convert.ToString()
            PedidoD.Insertar(Convert.ToInt32(idProducto), Convert.ToInt32(idProductoDetalle), Convert.ToInt32(cantPedida), Convert.ToSingle(precioUnitario), Convert.ToSingle(suntotal), Convert.ToInt32(cantRecibida),Convert.ToInt32(cantRechazada), Convert.ToSingle(cantAceptada));
        }

        public void EditarPedidoDetalle(string idProducto, string idProductoDetalle, string cantPedida, string precioUnitario, string suntotal, string cantRecibida, string cantRechazada, string cantAceptada)
        {
            PedidoD.Editar(Convert.ToInt32(idProducto), Convert.ToInt32(idProductoDetalle), Convert.ToInt32(cantPedida), Convert.ToSingle(precioUnitario), Convert.ToSingle(suntotal), Convert.ToInt32(cantRecibida), Convert.ToInt32(cantRechazada), Convert.ToSingle(cantAceptada));
        }

        public void EliminarPedidoDetalle(string idProducto, string idProductoDetalle)
        {
            PedidoD.Eliminar(Convert.ToInt32(idProducto), Convert.ToInt32(idProductoDetalle));
        }

        public int obtenerPaginas()
        {
            int pags = PedidoD.obtenerPaginas();
            return pags;
        }
        public int obtenerIdPedido(string campo)
        {
            int ids = PedidoD.obtenerIdPedido(campo);
            return ids;
        }

        public int obtenerIdProductoDetalle(string campo)
        {
            int ids = PedidoD.obtenerIdProductoDetalle(campo);
            return ids;
        }

    }
}
