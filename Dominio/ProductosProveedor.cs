﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Dominio
{
    public class ProductosProveedor
    {
        private ProductosProveedorDAO PPDAO = new ProductosProveedorDAO();
        
        public DataTable MostrarProductosProveedorDAO(int pagina)
        {
            DataTable tabla = new DataTable();
            tabla = PPDAO.Mostrar(pagina);
            return tabla;
        }

        public void InsertarProductosProveedor(string idProducto, string idProveedor, string diasRetardo, string precioEstandar, string precioUltimaCompra, string cantMinPedir, string cantMaxPedir)
        {//Convert.ToString()
            PPDAO.Insertar(Convert.ToInt32(idProducto), Convert.ToInt32(idProveedor), Convert.ToInt32(diasRetardo), Convert.ToSingle(precioEstandar), Convert.ToSingle(precioUltimaCompra), Convert.ToInt32(cantMinPedir), Convert.ToInt32(cantMaxPedir));
        }

        public void EditarProductosProveedor (string idProducto, string idProveedor, string diasRetardo, string precioEstandar, string precioUltimaCompra, string cantMinPedir, string cantMaxPedir)
        {
            PPDAO.Editar(Convert.ToInt32(idProducto), Convert.ToInt32(idProveedor), Convert.ToInt32(diasRetardo), Convert.ToSingle(precioEstandar), Convert.ToSingle(precioUltimaCompra), Convert.ToInt32(cantMinPedir), cantMaxPedir);
        }

        public void EliminarProductosProveedor(string idProducto,string idProveedor)
        {
            PPDAO.Eliminar(Convert.ToInt32(idProducto),Convert.ToInt32(idProveedor));
        }

        public int obtenerPaginas()
        {
            int pags = PPDAO.obtenerPaginas();
            return pags;
        }
    }
}
