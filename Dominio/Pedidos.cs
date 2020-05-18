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
    public class Pedidos
    {

        private PedidosDAO pdao = new PedidosDAO();

        public DataTable MostrarPedidos(int pagina)
        {
            DataTable tabla = new DataTable();
            tabla = pdao.Mostrar(pagina);
            return tabla;
        }

        public void ListarProveedores(ComboBox combo)
        {
            PedidosDAO oPed = new PedidosDAO();
            combo.DataSource = oPed.ListarProveedores();
            combo.DisplayMember = "nombre";
            combo.ValueMember = "idProveedor";
        }

        public void ListarEmpleados(ComboBox combo)
        {
            PedidosDAO oPed = new PedidosDAO();
            combo.DataSource = oPed.ListarEmpleados();
            combo.DisplayMember = "nombre";
            combo.ValueMember = "idEmpleado";
        }

        public void insertarPedido(string fechaRegistro, string fechaREcepcion, string totalPagar, string cantidadPagada,
            int idProveedor, int idEmpleado)
        {
            pdao.Insertar(fechaRegistro,fechaREcepcion,Convert.ToSingle(totalPagar),Convert.ToSingle(cantidadPagada),
                idProveedor,idEmpleado);
        }

        public int obtenerPaginas()
        {
            int pags = pdao.obtenerPaginas();
            return pags;
        }
    }
}
