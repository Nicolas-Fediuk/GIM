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
    public class GestionVentas
    {
        DaoVentas dao = new DaoVentas();  

        public DataTable getVentas()
        {
            return dao.getTablaVentas();
        }

        public DataTable getVentasId(Ventas v)
        {
            return dao.getTablaVentaId(v);
        }

        public bool ExisteVenta(Ventas v)
        {
            if (dao.ExisteVenta(v))
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
