using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Dominio
{
    class Categorias
    {
        private CategoriasDAO categoriasdao = new CategoriasDAO();
        public void seleccionNombre(string nombre)
        {
            //categoriasdao.SeleccionarNombre(nombre);
        }

        public void seleccionID(int id)
        {
            //categoriasdao.SeleccionarID(id);
        }
    }
}
