﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Datos
{
        public class ConexionSQL
    {
        private readonly string connectionString;
        public ConexionSQL()
        {
            connectionString = "Server=EDUARDO;DataBase=ERP2020; integrated security = true";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
