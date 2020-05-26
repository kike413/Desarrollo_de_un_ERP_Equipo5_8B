using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class PedidoDetalleDAO:ConexionSQL
    {
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        int pagina = 0;
        int id = 0;
        public DataTable Mostrar(int pagina)
        {
            //sql
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from paginacion_pedidodetalle(" + pagina + ")";
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
            //procedimiento
        }

        /*
        * insertar
        */
        public void Insertar(int idPedido, int idProductoDetalle, int cantPedida, float precioUnitario, float subtotal,int cantResibida, int cantRechazada, float cantAceptada)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into PedidoDetalle values (" + idPedido + "," + idProductoDetalle + "," + cantPedida + "," + precioUnitario + "," + subtotal +","+cantResibida+","+cantRechazada+","+cantAceptada+ ", default)";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }

        /*
         * Editar
         */
        public void Editar(int idPedido, int idProductoDetalle, int cantPedida, float precioUnitario, float subtotal, int cantRecibida, int cantRechazada, float cantAceptada)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EditarPedidoDetalle";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idPedido", idPedido);
                    command.Parameters.AddWithValue("@idProductoDetalle", idProductoDetalle);
                    command.Parameters.AddWithValue("@cantPedida", cantPedida);
                    command.Parameters.AddWithValue("@precioUnitario", precioUnitario);
                    command.Parameters.AddWithValue("@subtotal", subtotal);
                    command.Parameters.AddWithValue("@cantRecibida", cantRecibida);
                    command.Parameters.AddWithValue("@cantRechazada", cantRechazada);
                    command.Parameters.AddWithValue("@cantAceptada", cantAceptada);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }

        /*
         * Eliminar
         */

        public void Eliminar(int idPedido, int idProductoDetalle)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EliminarPedidoDetalle";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idPedido", idPedido);
                    command.Parameters.AddWithValue("@idProductoDetalle", idProductoDetalle);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }
        public int obtenerPaginas()
        {
            //sql
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select ceiling(count(*)/10.0) from pedidodetalle where estatus ='A'";
                    command.CommandType = CommandType.Text;
                    pagina = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("paginas " + pagina);
                    connection.Close();
                    return pagina;
                }
            }

        }

        public int obtenerIdPedido(string campo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select d.idPedido from pedidodetalle d " +
                        "join Pedidos c " +
                        "on c.idPedido=d.idPedido " +
                        "where c.nombre = '" + campo + "'";
                    command.CommandType = CommandType.Text;
                    id = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("paginas " + pagina);
                    connection.Close();
                    return id;
                }
            }
        }

        public int obtenerIdProductoDetalle(string campo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select d.idProductoDetalle from pedidoDetalle d " +
                        "join detalleproducto p " +
                        "on p.idProductoDetalle = d.idProductoDetalle " +
                        "where p.nombre = '" + campo + "'";
                    command.CommandType = CommandType.Text;
                    id = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("paginas " + pagina);
                    connection.Close();
                    return id;
                }
            }
        }
    }
}
