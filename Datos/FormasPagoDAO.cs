using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class FormasPagoDAO : ConexionSQL
    {

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        int pagina = 0;
        public DataTable Mostrar(int pagina)
        {
            //sql
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from paginacion_FormasPago(" + pagina + ")";
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
        public void Insertar(string nombre)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into FormasPago values ('" + nombre + "',default)";
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
        public void Editar(string nombre, int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EditarFormasPago";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@idFormaPago", id);
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
                    command.CommandText = "EliminarFormasPago";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idFormaPago", id);
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
                    command.CommandText = "select ceiling(count(*)/10.0) from FormasPago where estatus ='A'";
                    command.CommandType = CommandType.Text;
                    pagina = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("paginas " + pagina);
                    connection.Close();
                    return pagina;
                }
            }

        }
    }
}
