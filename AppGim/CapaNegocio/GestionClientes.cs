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
    public class GestionClientes
    {
        DaoClientes dao = new DaoClientes();

        public DataTable getClientes()
        {
            return dao.getTablaClientes();
        }

        public DataTable getClientesId(Clientes cli)
        {
            return dao.getTablaClienteId(cli);  
        }

        public bool ExisteCliente(Clientes cli)
        {
            if (dao.ExisteCliente(cli))
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
