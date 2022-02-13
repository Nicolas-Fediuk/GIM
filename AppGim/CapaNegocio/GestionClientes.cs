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

        public DataTable ObtenerListaClientes()
        {
            return dao.getTablaListaCliente();
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

        public bool AgregarCliente(Clientes cli)
        {
            int fila = 0;
 
            fila = dao.AgregarCliente(cli);
            
            if(fila == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ModificarCliente(Clientes cli)
        {
            bool modificado = dao.ModificarCliente(cli);
            if (modificado)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool EliminarCliente(Clientes cli)
        {
            int eliminado = dao.EliminarCLiente(cli);
            if (eliminado==1)
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
