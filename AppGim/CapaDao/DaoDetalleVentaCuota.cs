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
    public class DaoDetalleVentaCuota
    {
        AccesoDatos ad = new AccesoDatos();
        const string TodoDetalleVentaCuota = "select * from DetalleVentasCuotas";

        public DetalleVentasCuota ObtenerDetalleVentasCuotas(DetalleVentasCuota dc)
        {
            DataTable tabla = ad.ObtenerTabla("DetalleVentasCuotas", TodoDetalleVentaCuota + " where IdVenta_dvc= " + dc.IdVenta1.IdVenta1);
            dc.IdVenta1.IdVenta1 = Convert.ToInt32(tabla.Rows[0][0].ToString());
            dc.IdCliente1.IdCliente1 = Convert.ToInt32(tabla.Rows[0][1].ToString());
            dc.IdCuota1.IdTipoCuota1 = Convert.ToInt32(tabla.Rows[0][2].ToString());
            dc.Precio1 = Convert.ToInt32(tabla.Rows[0][4].ToString());
            dc.FechaInicio1 = tabla.Rows[0][5].ToString();
            dc.FechaFin1 = tabla.Rows[0][6].ToString();
            return dc;
        }

        public DataTable getTablaDetalleVentaId(DetalleVentasCuota dc)
        {
            string consulta = TodoDetalleVentaCuota + " where IdVenta_dvc= " + dc.IdVenta1.IdVenta1;
            DataTable tabla = ad.ObtenerTabla("DetalleVentasCuotas", consulta);
            return tabla;
        }

        public DataTable getTablaDetalleVenta()
        {
            DataTable tabla = ad.ObtenerTabla("DetalleVentasCuotas", TodoDetalleVentaCuota);
            return tabla;
        }

        public Boolean ExisteDetalleVentaCuota(DetalleVentasCuota dc)
        {
            string consulta = TodoDetalleVentaCuota + " where IdVenta_dvc= " + dc.IdVenta1.IdVenta1;
            return ad.existe(consulta);
        }

        public int AgregarDetalleVentaCuota(DetalleVentasCuota dc)
        {
            SqlCommand comando = new SqlCommand();
            ArmarProcedimientoDetalleVentaCuotaAgregar(ref comando, dc);
            return ad.EjecutarProcedimientoAlmacenado(comando, "sp_AgregarDetalleVentaCuota");

        }

        private void ArmarProcedimientoDetalleVentaCuotaAgregar(ref SqlCommand comando,DetalleVentasCuota dc)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@IDVENTA_DVC", SqlDbType.BigInt);
            parametros.Value = dc.IdVenta1.IdVenta1;
            parametros = comando.Parameters.Add("@IDCLIENTE_DVC", SqlDbType.BigInt);
            parametros.Value = dc.IdCliente1.IdCliente1;
            parametros = comando.Parameters.Add("@IDTIPOCUOTA.DVC", SqlDbType.Int);
            parametros.Value = dc.IdCuota1.IdTipoCuota1;
            parametros = comando.Parameters.Add("@PRECIO_DVC", SqlDbType.Decimal);
            parametros.Value = dc.Precio1;
            parametros = comando.Parameters.Add("@FECHAFIN_DVC", SqlDbType.Date);
            parametros.Value = dc.FechaFin1;
        }
    }
}
