using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Dominio
{
    
    public class Marcas
    {
        private MarcasDAO mdao = new MarcasDAO();
        public DataTable MostrarMarcas()
        {
            DataTable tabla = new DataTable();
            tabla = mdao.Mostrar();
            return tabla;
        }

        public void InsertarEstilo(string nombre)
        {
            mdao.Insertar(nombre);
        }

        public void EditarEstilo(string nombre, string id)
        {
            mdao.Editar(nombre, Convert.ToInt32(id));
        }

        public void EliminarEstilo(string id)
        {
            mdao.Eliminar(Convert.ToInt32(id));
        }
    }
}
