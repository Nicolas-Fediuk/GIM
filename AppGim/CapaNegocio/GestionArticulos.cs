using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
using CapaDao;
using System.Data;

namespace CapaNegocio
{
    public class GestionArticulos
    {
        DaoProductos dao = new DaoProductos();

        public DataTable getArticulos()
        {
            return dao.getTablaProductos();
        }

        public DataTable getProductosPorId(Productos p)
        {
            return dao.getTablaCodProducto(p);
        }

        public bool ExisteProducto(Productos p)
        {
            if (dao.ExisteProducto(p))
            {
                return true; 
            }
            else
            {
                return false;   
            }
        }

        public bool AgregarArticulo(Productos p)
        {
            int fila = 0;
            if (dao.ExisteProducto(p))
            {
                fila = dao.AgregarProducto(p);
            }

            if(fila == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ModificarArticulo(Productos p)
        {
            bool modificado = dao.ModificarProducto(p);
            if (modificado)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EliminarArticulo(Productos p)
        {
            int eliminado = dao.EliminarProducto(p);

            if (eliminado == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
