using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class PagosComprasDAO : ConexionSQL
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
                    command.CommandText = "select * from paginacion_PagosCompras(" + pagina + ")";
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
        public void Insertar(string fecha, float importe, int idPedido, int idFormaPago)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into PagosCompras values ('" + fecha + "','" + importe + "','" + 
                        idPedido + "','" + idFormaPago + "',default)";
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
        public void Editar(string fecha, float importe, int idPedido, int idFormaPago, int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EditarPagosCompras";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fecha", fecha);
                    command.Parameters.AddWithValue("@importe", importe);
                    command.Parameters.AddWithValue("@idPedido", idPedido);
                    command.Parameters.AddWithValue("@idFormaPago", idFormaPago);
                    command.Parameters.AddWithValue("@idPago", id);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }

        /*
         * Eliminar
         */

        public void Eliminar(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EliminarPagosCompras";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idPago", id);
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
                    command.CommandText = "select ceiling(count(*)/10.0) from proveedores where estatus ='A'";

                    command.CommandType = CommandType.Text;
                    pagina = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("paginas " + pagina);
                    connection.Close();
                    return pagina;
                }
            }

        }

        /*
         * Método para mostrar los proveedores en el combobox
         */
        public DataTable ListarPedido()
        {
            //sql
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ListarPedido";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    tabla.Load(reader);
                    reader.Close();
                    connection.Close();
                    return tabla;
                }
            }
            //procedimiento
        }

        public DataTable ListarFormaPago()
        {
            //sql
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ListarFormaPago";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    tabla.Load(reader);
                    reader.Close();
                    connection.Close();
                    return tabla;
                }
            }
            //procedimiento
        }

    }
}
