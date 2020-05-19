using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class ProductosProveedorDAO:ConexionSQL
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
                    command.CommandText = "select * from paginacion_productosProveedor(" + pagina + ")";
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
        public void Insertar(int idProducto, int idProveedor, int diasRetardo, float precioEstandar, float precioUltimaCompra, int cantMinPedir, int cantMaxPedir)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into ProductosProveedor values (" + idProducto + "," + idProveedor + "," + diasRetardo + "," + precioEstandar + "," + precioUltimaCompra + "," + cantMinPedir + "," + cantMaxPedir + ", default)";
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
        public void Editar(int idProducto, int idProveedor, int diasRetardo, float precioEstandar, float precioUltimaCompra, int cantMinPedir, string cantMaxPedir, int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EditarProductosProveedor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idProducto", idProducto);
                    command.Parameters.AddWithValue("@idProveedor", idProveedor);
                    command.Parameters.AddWithValue("@diasRetardo", diasRetardo);
                    command.Parameters.AddWithValue("@precioEstandar", precioEstandar);
                    command.Parameters.AddWithValue("@precioUltimaCompra", precioUltimaCompra);
                    command.Parameters.AddWithValue("@cantMinPedir", cantMinPedir);
                    command.Parameters.AddWithValue("@cantMaxPedir", cantMaxPedir);
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
                    command.CommandText = "EliminarProductosProveedor";
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
                    command.CommandText = "select ceiling(count(*)/10.0) from ProductosProveedor where estatus ='A'";
                    command.CommandType = CommandType.Text;
                    pagina = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("paginas " + pagina);
                    connection.Close();
                    return pagina;
                }
            }

        }


        public int obtenerIdProducto(string campo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select pp.idProducto from ProductosProveedor pp " +
                        "join productos pd " +
                        "on pp.idProducto = pd.idproducto " +
                        "where pd.nombre = '" + campo + "'";
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
