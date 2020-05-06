using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Datos
{
    public class UsuarioDAO : ConexionSQL //herencia de conexionsql
    {
        /**
         * Método para verificar el login
         */
        public bool Login(string usuario, string password)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT Usuarios.idUsuario, Usuarios.nombre, Empleados.nombre, Empleados.apaterno, Empleados.amaterno, Empleados.estadoCivil " +
                        "FROM Usuarios INNER JOIN Empleados ON Usuarios.idUsuario = Empleados.idEmpleado where Usuarios.nombre=@usuario and " +
                        "Usuarios.contraseña=@password ";
                    //command.CommandText = "select * from usuarios where nombre=@usuario and" +
                    //    " contraseña=@password";
                    command.Parameters.AddWithValue("@usuario", usuario);
                    command.Parameters.AddWithValue("@password", password);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            InicioSesionDAO.ID = reader.GetInt32(0);
                            InicioSesionDAO.Cargo = reader.GetString(1);
                            InicioSesionDAO.Nombre = reader.GetString(2);
                            InicioSesionDAO.ApellidoPaterno = reader.GetString(3);
                            InicioSesionDAO.ApellidoMaterno = reader.GetString(4);
                            InicioSesionDAO.EstadoCivil = reader.GetString(5);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
    }
}