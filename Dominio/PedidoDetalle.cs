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

        public void InsertarPedidoDetalle(string cantPedida, string precioUnitario,string suntotal,string cantResivida, string cantRechesada, string cantAceptada)
        {//Convert.ToString()
            PedidoD.Insertar(Convert.ToInt32(cantPedida), Convert.ToSingle(precioUnitario), Convert.ToSingle(suntotal), Convert.ToInt32(cantResivida),Convert.ToInt32(cantRechesada), Convert.ToSingle(cantAceptada));
        }

        public void EditarPedidoDetalle(string cantPedida, string precioUnitario, string suntotal, string cantResivida, string cantRechesada, string cantAceptada,
            string id)
        {
            PedidoD.Editar(Convert.ToInt32(cantPedida), Convert.ToSingle(precioUnitario), Convert.ToSingle(suntotal), Convert.ToInt32(cantResivida), Convert.ToInt32(cantRechesada), Convert.ToSingle(cantAceptada), 
                Convert.ToInt32(id));
        }

        public void EliminarPedidoDetalle(string id)
        {
            PedidoD.Eliminar(Convert.ToInt32(id));
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
