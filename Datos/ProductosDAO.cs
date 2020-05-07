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

        public int obtenerIdCat(string campo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select p.idCategoria from Productos p " +
                        "join Categorias c " +
                        "on p.idCategoria = c.idCategoria " +
                        "where c.nombre = '"+campo+"'";
                    command.CommandType = CommandType.Text;
                    id = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("paginas " + pagina);
                    connection.Close();
                    return id;
                }
            }
        }

        public int obtenerIdMarca(string campo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select p.idMarca from Productos p " +
                        "join Marcas m " +
                        "on p.idMarca = m.idMarca " +
                        "where m.nombre = '" + campo + "'";
                    command.CommandType = CommandType.Text;
                    id = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("paginas " + pagina);
                    connection.Close();
                    return id;
                }
            }
        }

        public int obtenerIdEstilo(string campo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select p.idEstilo from Productos p " +
                        "join estilos e " +
                        "on p.idEstilo = e.idEstilo " +
                        "where e.nombre = '" + campo + "'";
                    command.CommandType = CommandType.Text;
                    id = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("paginas " + pagina);
                    connection.Close();
                    return id;
                }
            }
        }

        public DataTable MostrarTodo(string filtro)
        {
            //sql
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select p.idProducto,p.nombre,p.descripcion,p.puntoReorden,p.genero, p.precioCompra,p.precioVenta,p.estatus,p.materia,m.nombre as marca,e.nombre as estilo,c.nombre as categoria from Productos p join Categorias c on p.idCategoria = c.idCategoria join Estilos e on p.idEstilo = e.idEstilo join Marcas m on m.idMarca = p.idMarca where p.idProducto like('%" + filtro + "%') or p.nombre like ('" + filtro + "') " +
                        "or p.materia like('%" + filtro + "%') or m.nombre like('%" + filtro + "%') or e.nombre like('%" + filtro + "%')" +
                        " or c.nombre like('%" + filtro + "%') and p.estatus='A'";
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    tabla.Load(reader);
                    connection.Close();
                    return tabla;
                }
            }
            //procedimiento
        }
    }
}
