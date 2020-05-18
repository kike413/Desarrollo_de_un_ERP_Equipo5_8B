using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;
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

        public int obtenerPaginas()
        {
            int pags = categoriasdao.obtenerPaginas();
            return pags;
        }
    }
}
