using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Datos
{
        public abstract class ConexionSQL
    {
        private readonly string connectionString;
        public ConexionSQL()
        {
            connectionString = "Server=DESKTOP-F7OUO59;DataBase=ERP2020; integrated security = true";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
