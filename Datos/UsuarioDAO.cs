using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Datos
{
    public class UsuarioDAO:ConexionSQL //herencia de conexionsql
    {
        /**
         * Método para verificar el login
         */
        public bool Login(string usuario,string password)
        {
            using (var connection = GetConnection()){
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from usuarios where nombre=@usuario and" +
                        " contraseña=@password";
                    command.Parameters.AddWithValue("@usuario",usuario);
                    command.Parameters.AddWithValue("@password", password);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
    }
}
