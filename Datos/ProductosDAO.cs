using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class ProductosDAO:ConexionSQL
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
                    command.CommandText = "select * from paginacion_productos(" + pagina + ")";
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
        public void Insertar(string nombre,string descripcion,int puntoReorden,string genero,
            float precioCompra,float precioVenta,string materia,int idMarca,int idEstilo,int idCategoria)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into productos values ('" + nombre + "','"+descripcion+ "',"+puntoReorden +
                        ",'"+genero+ "','" + precioCompra+ "','" + precioVenta+"',default"+ ",'"+materia+
                        "',"+idMarca+ ","+idEstilo+','+idCategoria+")";
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
        public void Editar(string nombre, string descripcion, int puntoReorden, string genero,
            float precioCompra, float precioVenta, string idMateria, int idMarca, int idEstilo, 
            int idCategoria, int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EditarProducto";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@descripcion", descripcion);
                    command.Parameters.AddWithValue("@puntoReorden",puntoReorden);
                    command.Parameters.AddWithValue("@genero",genero);
                    command.Parameters.AddWithValue("@precioCompra",precioCompra);
                    command.Parameters.AddWithValue("@precioVenta",precioVenta);
                    command.Parameters.AddWithValue("@material",idMateria);
                    command.Parameters.AddWithValue("@idMarca",idMarca);
                    command.Parameters.AddWithValue("@idEstilo", idEstilo);
                    command.Parameters.AddWithValue("@idCategoria",idCategoria);
                    command.Parameters.AddWithValue("@id", id);
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
                    command.CommandText = "EliminarProducto";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
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
                    command.CommandText = "select ceiling(count(*)/10.0) from productos where estatus ='A'";
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
