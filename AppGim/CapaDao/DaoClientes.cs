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
    public class DaoClientes
    {
        AccesoDatos ad = new AccesoDatos();
        string TodosClientes = "select * from Clientes";

        public Clientes ObtenerCliente(Clientes cli)
        {
            DataTable tabla = ad.ObtenerTabla("Clientes", "select IdCliente_cli,Nombre_cli,Apellido_cli,Edad_cli,Telefono_cli,Email_cli,Direccion_cli,ProblemasDeSalud_cli,IdRutina_cli from Clientes where IdCliente_cli= " + cli.IdCliente1);
            cli.IdCliente1 = Convert.ToInt32(tabla.Rows[0][0].ToString());
            cli.Nombre1 = tabla.Rows[0][1].ToString();
            cli.Apellido1 = tabla.Rows[0][2].ToString();
            cli.Edad1 = tabla.Rows[0][3].ToString();
            cli.Telefono1 = tabla.Rows[0][4].ToString();
            cli.Email1 = tabla.Rows[0][5].ToString();
            cli.Direccion1 = tabla.Rows[0][6].ToString();
            cli.ProblemasDeSalud1 = tabla.Rows[0][7].ToString();
            cli.IdRutina1.IdRutina1 = Convert.ToInt32(tabla.Rows[0][8].ToString());
            cli.Estado1 = Convert.ToBoolean(tabla.Rows[0][9].ToString());
            return cli;
        }

        public DataTable getTablaClienteId(Clientes cli)
        {
            string consulta = TodosClientes + " where IdCliente_cli= " + cli.IdCliente1;
            DataTable tabla = ad.ObtenerTabla("Cliente", consulta);
            return tabla;
        }

        public DataTable getTablaClientes()
        {
            DataTable tabla = ad.ObtenerTabla("Clientes", TodosClientes);
            return tabla;
        }

        public Boolean ExisteCliente(Clientes cli)
        {
            string consulta = TodosClientes + " where IdCliente_cli = " + cli.IdCliente1;
            return ad.existe(consulta);
        }

        public int AgregarCliente(Clientes cli)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosClienteAgregar(ref comando, cli);
            return ad.EjecutarProcedimientoAlmacenado(comando, "sp_AgregarCliente");
        }

        private void ArmarParametrosClienteAgregar(ref SqlCommand comando,Clientes cli)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@NOMBRE_CLI", SqlDbType.VarChar);
            parametros.Value = cli.Nombre1;
            parametros = comando.Parameters.Add("@APELLLIDO",SqlDbType.VarChar); ;
            parametros.Value = cli.Apellido1;
            parametros = comando.Parameters.Add("@EDAD_CLI", SqlDbType.Char);
            parametros.Value = cli.Edad1;
            parametros = comando.Parameters.Add("@TELEFONO_CLI", SqlDbType.VarChar);
            parametros.Value = cli.Telefono1;
            parametros = comando.Parameters.Add("EMAIL_CLI", SqlDbType.VarChar);
            parametros.Value = cli.Email1;
            parametros = comando.Parameters.Add("@DIRECCION_CLI", SqlDbType.VarChar);
            parametros.Value = cli.Direccion1;
            parametros = comando.Parameters.Add("@PROBLEMAS_CLI", SqlDbType.Text);
            parametros.Value = cli.ProblemasDeSalud1;
            parametros = comando.Parameters.Add("@IDRUTINA_CLI", SqlDbType.Int);
            parametros.Value = cli.IdRutina1;
        }

        public bool ModificarCliente(Clientes cli)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosClienteModificar(ref comando, cli);
            int FilasIsertadas = ad.EjecutarProcedimientoAlmacenado(comando, "sp_ModificarCliente");
            if (FilasIsertadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ArmarParametrosClienteModificar(ref SqlCommand comando, Clientes cli)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@IDCLIENTE_CLI", SqlDbType.BigInt);
            parametros.Value = cli.IdCliente1;
            parametros = comando.Parameters.Add("@NOMBRE_CLI", SqlDbType.VarChar);
            parametros.Value = cli.Nombre1;
            parametros = comando.Parameters.Add("@APELLLIDO", SqlDbType.VarChar); ;
            parametros.Value = cli.Apellido1;
            parametros = comando.Parameters.Add("@EDAD_CLI", SqlDbType.Char);
            parametros.Value = cli.Edad1;
            parametros = comando.Parameters.Add("@TELEFONO_CLI", SqlDbType.VarChar);
            parametros.Value = cli.Telefono1;
            parametros = comando.Parameters.Add("EMAIL_CLI", SqlDbType.VarChar);
            parametros.Value = cli.Email1;
            parametros = comando.Parameters.Add("@DIRECCION_CLI", SqlDbType.VarChar);
            parametros.Value = cli.Direccion1;
            parametros = comando.Parameters.Add("@PROBLEMAS_CLI", SqlDbType.Text);
            parametros.Value = cli.ProblemasDeSalud1;
            parametros = comando.Parameters.Add("@IDRUTINA_CLI", SqlDbType.Int);
            parametros.Value = cli.IdRutina1;
        }

        public int EliminarCLiente(Clientes cli)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosClienteEliminar(ref comando, cli);
            return ad.EjecutarProcedimientoAlmacenado(comando, "sp_EliminarCliente"); 
        }

        private void ArmarParametrosClienteEliminar(ref SqlCommand comando,Clientes cli)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@IDCLIENTE_CLI", SqlDbType.BigInt);
            parametros.Value = cli.IdCliente1;
        }
    }
}
