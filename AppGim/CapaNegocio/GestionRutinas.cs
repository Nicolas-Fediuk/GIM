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
    public class GestionRutinas
    {
        DaoRutinas dao = new DaoRutinas();

        public DataTable getRutinas()
        {
            return dao.getTablaRutinas();
        }

        public DataTable getRutinasId(Rutinas r)
        {
            return dao.getTablaRutinaId(r);
        }

        public bool ExiteRutina(Rutinas r)
        {
            if (dao.ExisteRutina(r))
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
