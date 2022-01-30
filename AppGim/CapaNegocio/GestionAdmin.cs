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
    public class GestionAdmin
    {
        DaoAdmin dao = new DaoAdmin();

        public bool ExisteAdmin(Admin a)
        {
            if (dao.ExisteAdmin(a))
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
