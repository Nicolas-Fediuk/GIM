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
    public class GestionDetalleVentaCuota
    {
        DaoDetalleVentaCuota dao = new DaoDetalleVentaCuota();  

        public DataTable getDetalleVentaCuota()
        {
            return dao.getTablaDetalleVenta();
        }

        public DataTable getDetalleVentaCuotaId(DetalleVentasCuota dvc)
        {
            return dao.getTablaDetalleVentaId(dvc);
        }

        public bool ExisteVenta(DetalleVentasCuota dvc)
        {
            if (dao.ExisteDetalleVentaCuota(dvc))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool AgregarDetalleVentaCuota(DetalleVentasCuota dvc)
        {
            int fila = 0;
            if (dao.ExisteDetalleVentaCuota(dvc) == false)
            {
                fila = dao.AgregarDetalleVentaCuota(dvc);
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
