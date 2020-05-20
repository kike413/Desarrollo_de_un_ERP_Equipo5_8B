using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class CuentasProveedorDAO : ConexionSQL
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
                    command.CommandText = "select * from paginacion_cuentasProveedor(" + pagina + ")";
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
       * insertar
       */
        public void Insertar(int idProveedor,string noCuenta,string banco)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into CuentasProveedor values ("+idProveedor +",'"+noCuenta +"','"+banco+"', default)";
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
        public void Editar(int idProveedor, string noCuenta, string banco)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EditarCuentasProveedor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", idProveedor);
                    command.Parameters.AddWithValue("@noCuenta", noCuenta);
                    command.Parameters.AddWithValue("@banco", banco);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }

        public void Eliminar(int id,string noCuenta,string banco)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EliminarCuentaProveedor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idProveedor", id);
                    command.Parameters.AddWithValue("@noCuenta", noCuenta);
                    command.Parameters.AddWithValue("@banco", banco);
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
