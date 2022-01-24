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
    public class GestionCuota
    {
        DaoCuotas dao = new DaoCuotas();

        public DataTable getCuotas()
        {
            return dao.getTablaCuota();
        }

        public DataTable getTablaCuotaId(Cuotas cuo)
        {
            return dao.getTablaCuotaId(cuo);
        }

        public bool ExisteCuota(Cuotas cuo)
        {
            if (dao.ExisteCuota(cuo))
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
