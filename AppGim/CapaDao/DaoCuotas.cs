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
    public class DaoCuotas
    {
        AccesoDatos ad = new AccesoDatos();
        const string TodoCuota = "select * from Cuotas";

        public Cuotas ObtenerCuotas(Cuotas c)
        {
            DataTable tabla = ad.ObtenerTabla("Cuotas", "IdTipoCuota_cuo,DescripcionCuota_cuo,Precio_cuo from Cuotas where IdTipoCuota_cuo= " + c.IdTipoCuota1);
            c.IdTipoCuota1 =Convert.ToInt32(tabla.Rows[0][0].ToString());
            c.Descripcion1 = tabla.Rows[0][1].ToString();
            c.Precio1 = Convert.ToInt32(tabla.Rows[0][2].ToString());
            c.Estado1 = Convert.ToBoolean(tabla.Rows[0][3].ToString());
            return c;
        }

        public DataTable getTablaCuota(Cuotas c)
        {
            string consulta = TodoCuota + "where IdTipoCuota_cuo= " + c.IdTipoCuota1;
            DataTable tabla = ad.ObtenerTabla("Cuotas", consulta);
            return tabla;
        }

        public DataTable getTablaCuota()
        {
            DataTable tabla = ad.ObtenerTabla("Cuota", TodoCuota);
            return tabla;
        }

        public Boolean ExisteCuota(Cuotas c)
        {
            string consulta = TodoCuota + "where IdTipoCuota_cuo= " + c.IdTipoCuota1;
            return ad.existe(consulta);
        }

        public int AgregarCuota(Cuotas c)
        {
            SqlCommand comando = new SqlCommand;
            ArmarParamatrosCuotaAgregar(ref comando, c);
            return ad.EjecutarProcedimientoAlmacenado(comando, "sp_AgregarCuota");
        }

        private void ArmarParamatrosCuotaAgregar(ref SqlCommand comando,Cuotas c)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@DESCRIPCIONCUOTA_CUO", SqlDbType.Int);
            parametros.Value = c.IdTipoCuota1;
            parametros = comando.Parameters.Add("@PRECIO_CUO", SqlDbType.Decimal);
            parametros.Value = c.Precio1;
        }

        public bool ModificarCuota(Cuotas c)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParamatrosCuotaModificar(ref comando, c);
            int FilasInsertadas = ad.EjecutarProcedimientoAlmacenado(comando, "sp_ModificarCuota");
            if (FilasInsertadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ArmarParamatrosCuotaModificar(ref SqlCommand comando,Cuotas c)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@IDTIPOCUOTA_CUO", SqlDbType.Int);
            parametros.Value = c.IdTipoCuota1;
            parametros = comando.Parameters.Add("@DESCRIPCIONCUOTA_CUO", SqlDbType.VarChar);
            parametros.Value = c.Descripcion1;
            parametros = comando.Parameters.Add("@PRECIO_CUO", SqlDbType.Decimal);
            parametros.Value = c.Precio1;
        }

        public int EliminarCuota(Cuotas c)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParamatrosCuotaEliminar(comando, c);
            return ad.EjecutarProcedimientoAlmacenado(comando, "sp_EliminarCuota");
        }

        private void ArmarParamatrosCuotaEliminar(SqlCommand comando,Cuotas c)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@IDTIPOCUOTA_CUO", SqlDbType.Int);
            parametros.Value = c.IdTipoCuota1;
        }

    }
}
