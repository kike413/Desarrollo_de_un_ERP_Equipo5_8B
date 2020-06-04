using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;
using System.Windows.Forms;
namespace Dominio
{
    public class PagosCompras
    {
        private PagosComprasDAO Pagos = new PagosComprasDAO();
        public DataTable MostrarPagosCompras(int pagina)
        {
            DataTable tabla = new DataTable();
            tabla = Pagos.Mostrar(pagina);
            return tabla;
        }

        public void InsertarPagosCompras(string fecha, string importe, int idPedido, int idFormaPago)
        {
            Pagos.Insertar(fecha, Convert.ToSingle(importe), Convert.ToInt32(idPedido), Convert.ToInt32(idFormaPago));
        }

        public void EditarPagosCompras(string fecha, string importe, int idPedido, int idFormaPago, string id)
        {
            Pagos.Editar(fecha, Convert.ToSingle(importe), Convert.ToInt32(idPedido), Convert.ToInt32(idFormaPago), 
                Convert.ToInt32(id));
        }


        public void EliminarPagosCompras(string id)
        {
            Pagos.Eliminar(Convert.ToInt32(id));
        }


        public int obtenerPaginas()
        {
            int pags = Pagos.obtenerPaginas();
            return pags;
        }

        public void ListarPedido(ComboBox combo)
        {
            PagosComprasDAO Pagos = new PagosComprasDAO();
            combo.DataSource = Pagos.ListarPedido();
            combo.DisplayMember = "idPedido";
            combo.ValueMember = "idPedido";
        }

        public void ListarFormaPago(ComboBox combo)
        {
            PagosComprasDAO Pagos = new PagosComprasDAO();
            combo.DataSource = Pagos.ListarFormaPago();
            combo.DisplayMember = "idFormaPago";
            combo.ValueMember = "idFormaPago";
        }


    }
}
