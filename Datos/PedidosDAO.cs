using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Datos
{

    public class PedidosDAO : ConexionSQL
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
                    command.CommandText = "select * from paginacion_Pedidos(" + pagina + ")";
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
         * Método para mostrar los proveedores en el combobox
         */
        public DataTable ListarProveedores()
        {
            //sql
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ListarProveedores";
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

        /*
  * Método para mostrar los empleados en el combobox
  */
        public DataTable ListarEmpleados()
        {
            //sql
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ListarEmpleados";
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

        public int obtenerPaginas()
        {
            //sql
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select ceiling(count(*)/10.0) from Pedidos where estatus ='A'";
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
