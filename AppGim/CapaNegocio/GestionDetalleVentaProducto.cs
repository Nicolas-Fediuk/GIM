using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using CapaDao;


namespace CapaNegocio
{
    public class GestionDetalleVentaProducto
    {
        DaoDetalleVentaProducto dao = new DaoDetalleVentaProducto();

        public DataTable getDetalleVentaProducto()
        {
            return dao.getTablaDetalleVentaProductos();
        }

        public DataTable getDetalleVentaProductoId(DetalleVentasProductos dvp)
        {
            return dao.getTablaDetalleProductoId(dvp);
        }

        public bool ExisteDetalleVentaProducto(DetalleVentasProductos dvp)
        {
            if (dao.ExisteDetalleVentaProducto(dvp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AgregarDetalleVentaProducto(DetalleVentasProductos dvp)
        {
            int fila = 0;

            if (dao.ExisteDetalleVentaProducto(dvp) == false)
            {
                fila = dao.AgregarDetalleVentaProducto(dvp);
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
    }
}
