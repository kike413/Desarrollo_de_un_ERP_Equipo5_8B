using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Datos;

namespace Dominio
{
    public class ContactosProveedor
    {
        private ContactosProveedorDAO ContacProveedor = new ContactosProveedorDAO();
        public DataTable MostrarContactosProveedor(int pagina)
        {
            DataTable tabla = new DataTable();
            tabla = ContacProveedor.Mostrar(pagina);
            return tabla;
        }

        public void InsertarContactosProveedor(string nombre, string Telefono, string email, string idProveedor)
        {
            ContacProveedor.Insertar(nombre, Telefono, email, Convert.ToInt32(idProveedor));
        }

        public void EditarContactosProveedor(string nombre, string Telefono, string email, string idProveedor, string id)
        {
            ContacProveedor.Editar(nombre, Telefono, email, Convert.ToInt32(idProveedor), Convert.ToInt32(id));
        }

        public void EliminarContactosProveedor(string id, string idProveedor)
        {
            ContacProveedor.Eliminar(Convert.ToInt32(id), Convert.ToInt32(idProveedor));
        }
        public int obtenerPaginas()
        {
            int pags = ContacProveedor.obtenerPaginas();
            return pags;
        }

        public void ListarProveedor(ComboBox combo)
        {
            ContactosProveedorDAO contactos = new ContactosProveedorDAO();
            combo.DataSource = contactos.ListarProveedor();
            combo.DisplayMember = "idProveedor";
            combo.ValueMember = "idProveedor";
        }
    }
}
