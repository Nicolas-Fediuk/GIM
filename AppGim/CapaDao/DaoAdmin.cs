using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace CapaDao
{
    public class DaoAdmin
    {
        AccesoDatos ad = new AccesoDatos();

        public bool ExisteAdmin(Admin a)
        {
            string consulta = "select * from Admin where Nombre_ad = '" + a.Nombre1 + "' and Contraseña_ad= '" + a.Contraseña1 + "'";
            return ad.existe(consulta);
        }
    }
}
