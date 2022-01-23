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
    public class DaoVentas
    {
        AccesoDatos ad = new AccesoDatos();
        const string TodaVenta = "select * from Ventas";

        public Ventas ObtenerVenta(Ventas v)
        {
            DataTable tabla = ad.ObtenerTabla("Ventas", "select IdVenta_ve,IdCliente_ve,Total_ve,FechaVenta_ve,MetodoDePago from Ventas");
            v.IdVenta1 = Convert.ToInt32(tabla.Rows[0][0].ToString());
            v.IdCliente1.IdCliente1 = Convert.ToInt32(tabla.Rows[0][1].ToString());
            v.Total1 = Convert.ToInt32(tabla.Rows[0][2].ToString());
            v.FechaVenta1 = tabla.Rows[0][3].ToString();
            v.MetodoPago1 = Convert.ToBoolean(tabla.Rows[0][4].ToString());
            return v;
        }

        public DataTable getTablaVentaId(Ventas v)
        {
            string consulta = TodaVenta + " where IdVenta_ve= " + v.IdVenta1;
            DataTable tabla = ad.ObtenerTabla("Ventas", consulta);
            return tabla;
        }

        public DataTable getTablaVentas()
        {
            DataTable tabla = ad.ObtenerTabla("Ventas", TodaVenta);
            return tabla;
        }

        public Boolean ExisteVenta(Ventas v)
        {
            string consulta = TodaVenta + " where IdVenta_ve= " + v.IdVenta1;
            return ad.existe(consulta);
        }

        public int AgregarVenta(Ventas v)
        {
            SqlCommand comando = new SqlCommand();
            ArmarProcedimientoVentaAgregar(ref comando,v);
            return ad.EjecutarProcedimientoAlmacenado(comando, "sp_AgregarVenta");
        }

        private void ArmarProcedimientoVentaAgregar(ref SqlCommand comando,Ventas v)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@IDCLIENTE_VE", SqlDbType.BigInt);
            parametros.Value = v.IdCliente1.IdCliente1;
            parametros = comando.Parameters.Add("@METODOPAGO_VE", SqlDbType.Bit);
            parametros.Value = v.MetodoPago1;
        }
    }
}
