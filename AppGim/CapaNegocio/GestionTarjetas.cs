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
    public class GestionTarjetas
    {
        DaoTarjetas dao = new DaoTarjetas();

        public DataTable getTarjetas()
        {
            return dao.getTablaTarjetas();
        }

        public DataTable getTarjetaId(Tarjetas t)
        {
            return dao.getTablaTarjetaId(t);
        }

        public bool ExisteTarjeta(Tarjetas t)
        {
            if (dao.ExisteTarjeta(t))
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
