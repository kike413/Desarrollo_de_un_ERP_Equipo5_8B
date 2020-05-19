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
                    command.CommandText = "select * from paginacion_pedidos(" + pagina + ")";
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
         * Editar
         */
        public void Editar(string fechaRegistro, string fechaREcepcion, float totalPagar, float cantidadPagada,
            int idProveedor, int idEmpleado, int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EditarPedidos";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fechaRegistro", fechaRegistro);
                    command.Parameters.AddWithValue("@fechaRecepcion", fechaREcepcion);
                    command.Parameters.AddWithValue("@totalPagar", totalPagar);
                    command.Parameters.AddWithValue("@cantidadPagada", cantidadPagada);
                    command.Parameters.AddWithValue("@idProveedor", idProveedor);
                    command.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
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

        /*
        * insertar
        */
        public void Insertar(string fechaRegistro,string fechaREcepcion,float totalPagar,float cantidadPagada,
            int idProveedor,int idEmpleado)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into Pedidos values('"+fechaRegistro+"','"+fechaREcepcion+"',"+totalPagar+","+
                        cantidadPagada+",default,"+idProveedor+","+idEmpleado+")";
                    command.CommandType = CommandType.Text;
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
