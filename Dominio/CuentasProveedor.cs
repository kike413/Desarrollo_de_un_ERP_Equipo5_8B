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
   public class CuentasProveedor
    {
        private CuentasProveedorDAO cdao = new CuentasProveedorDAO();

        public DataTable MostrarCuentas(int pagina)
        {
            DataTable tabla = new DataTable();
            tabla = cdao.Mostrar(pagina);
            return tabla;
        }
        public void EditarCuenta(int idProveedor, string noCuenta, string banco)
        {
            cdao.Editar(idProveedor, noCuenta, banco);
        }


        public void EliminarCuenta(int idProveedor,string noCuenta,string banco)
        {
            cdao.Eliminar(idProveedor,noCuenta,banco);
        }

        public void ListarProveedores(ComboBox combo)
        {
            PedidosDAO oPed = new PedidosDAO();
            combo.DataSource = oPed.ListarProveedores();
            combo.DisplayMember = "nombre";
            combo.ValueMember = "idProveedor";
        }

        public void insertarCuenta(int idProveedor, string noCuenta,string banco)
        {
            cdao.Insertar(idProveedor,noCuenta,banco);
        }

        public int obtenerPaginas()
        {
            int pags = cdao.obtenerPaginas();
            return pags;
        }

    }
}
