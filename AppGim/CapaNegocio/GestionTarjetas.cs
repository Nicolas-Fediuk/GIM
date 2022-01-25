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

        public bool AgregarTarjeta(Tarjetas t)
        {
            int fila = 0;
            if (dao.ExisteTarjeta(t) == false)
            {
                fila = dao.AgregarTarjeta(t);
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

        public bool ModificarTarjeta(Tarjetas t)
        {
            bool modificado = dao.ModificarTarjeta(t);

            if (modificado)
            {
                return true;
            }
            else{
                return false;
            }
        }

        public bool EliminarTarjeta(Tarjetas t)
        {
            int eliminado = dao.EliminarTarjeta(t);

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
