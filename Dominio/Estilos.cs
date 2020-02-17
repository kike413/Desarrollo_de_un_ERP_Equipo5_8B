using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Datos;

namespace Dominio
{
    public class Estilos
    {
        private EstilosDAO estilosDao = new EstilosDAO();

        public DataTable MostrarEstilos()
        {
            DataTable tabla = new DataTable();
            tabla = estilosDao.Mostrar();
            return tabla;
        }

        public void InsertarEstilo(string nombre)
        {
            estilosDao.Insertar(nombre);
        }

        public void EditarEstilo(string nombre,string id)
        {
            estilosDao.Editar(nombre, Convert.ToInt32(id));
        }

        public void EliminarEstilo(string id)
        {
            estilosDao.Eliminar(Convert.ToInt32(id));
        }

    }
}
