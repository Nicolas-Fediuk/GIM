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
    public class DaoTarjetas
    {
        AccesoDatos ad = new AccesoDatos();
        const string TodoTarjeta = "select * from Tarjetas";

        public Tarjetas ObtenerTarjeta(Tarjetas t)
        {
            DataTable tabla = ad.ObtenerTabla("Tarjetas", "select IdTarjetaUsuario_tar,TitularTarjeta_tar,NombreTarjeta_tar,TipoTarjeta_tar,NumeroTarjeta_tar,FechaVencimiento_tar,CodigoSeguridad_tar from Tarjetas where IdTarjetaUsuario_tar= " + t.IdUsuario1.IdCliente1);
            t.IdUsuario1.IdCliente1 = Convert.ToInt32(tabla.Rows[0][0].ToString());
            t.Titular1 = tabla.Rows[0][1].ToString();
            t.NombreTarjeta1 = tabla.Rows[0][2].ToString();
            t.TipoTarjeta1 = Convert.ToBoolean(tabla.Rows[0][3].ToString());
            t.NumeroTarjeta1 = Convert.ToInt32(tabla.Rows[0][4].ToString());
            t.FechaVencimiento1 = tabla.Rows[0][5].ToString();
            t.CodigoSeguridad1 = Convert.ToInt32(tabla.Rows[0][6].ToString());
            return t;
        }

        public DataTable getTablaTarjetaId(Tarjetas t)
        {
            string consulta = TodoTarjeta + " where IdTarjetaUsuario_tar= " + t.IdUsuario1.IdCliente1;
            DataTable tabla = ad.ObtenerTabla("Tarjetas", consulta);
            return tabla;
        }

        public DataTable getTablaTarjetas()
        {
            DataTable tabla = ad.ObtenerTabla("Tarjetas", TodoTarjeta);
            return tabla;
        }

        public Boolean ExisteTarjeta(Tarjetas t)
        {
            string consulta = TodoTarjeta + " where IdTarjetaUsuario_tar= " + t.IdUsuario1.IdCliente1;
            return ad.existe(consulta);
        }

        public int AgregarTarjeta(Tarjetas t)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosTarjetaAgregar(ref comando, t);
            return ad.EjecutarProcedimientoAlmacenado(comando, "sp_AgregarTarjeta");
        }

        private void ArmarParametrosTarjetaAgregar(ref SqlCommand comando,Tarjetas t)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@IDTARJETAUSUARIO_TAR", SqlDbType.BigInt);
            parametros.Value = t.IdUsuario1.IdCliente1;
            parametros = comando.Parameters.Add("@TITULARTARJETA_TAR", SqlDbType.VarChar);
            parametros.Value = t.Titular1;
            parametros = comando.Parameters.Add("@NOMBRETARJETA_TAR", SqlDbType.VarChar);
            parametros.Value = t.NombreTarjeta1;
            parametros = comando.Parameters.Add("@TIPOTARJETA.TAR", SqlDbType.Bit);
            parametros.Value = t.TipoTarjeta1;
            parametros = comando.Parameters.Add("@NUMEROTARJETA_TAR", SqlDbType.BigInt);
            parametros.Value = t.NumeroTarjeta1;
            parametros = comando.Parameters.Add("@CODIGOSEGURIDAD_TAR", SqlDbType.Int);
            parametros.Value = t.CodigoSeguridad1;
        }

        public bool ModificarTarjeta(Tarjetas t)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosTarjetaAgregar(ref comando, t);
            int FilasInsertadas = ad.EjecutarProcedimientoAlmacenado(comando, "sp_ModificarTarjeta");
            if(FilasInsertadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int EliminarTarjeta(Tarjetas t)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosTarjetaEliminar(ref comando, t);
            return ad.EjecutarProcedimientoAlmacenado(comando, "sp_EliminarTarjeta");
        }
        
        public void ArmarParametrosTarjetaEliminar(ref SqlCommand comando,Tarjetas t)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@IDTARJETAUSUARIO_TAR", SqlDbType.BigInt);
            parametros.Value = t.IdUsuario1.IdCliente1;
        }

    }
}
