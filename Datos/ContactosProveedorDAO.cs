using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class ContactosProveedorDAO : ConexionSQL
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
                    command.CommandText = "select * from paginacion_ContactosProveedor(" + pagina + ")";
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
        public void Insertar(string nombre, string Telefono, string email, int idProveedor)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into ContactosProveedor values ('" + nombre + "','" + Telefono +  "','" + email + "','" + idProveedor + "',default)";
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
        public void Editar(string nombre, string Telefono, string email, int idProveedor, int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EditarContactosProveedor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@telefono", Telefono);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@idProveedor", idProveedor);
                    command.Parameters.AddWithValue("@idContacto", id);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    connection.Close();
                }
            }
        }

        /*
         * Eliminar
         */

        public void Eliminar(int id, int idProveedor)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EliminarContactosProveedor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idContacto", id);
                    command.Parameters.AddWithValue("@idProveedor", idProveedor);
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
                    command.CommandText = "select ceiling(count(*)/10.0) from ContactosProveedor where estatus ='A'";

                    command.CommandType = CommandType.Text;
                    pagina = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("paginas " + pagina);
                    connection.Close();
                    return pagina;
                }
            }

        }

        public DataTable ListarProveedor()
        {
            //sql
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ListarProveedor";
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
