using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace CapaDao
{
    public class DaoDetalleVentaProducto
    {
        AccesoDatos ad = new AccesoDatos();
        const string TodoDetalleVentaProducto = "select * from DetalleVentasProductos";

        public DetalleVentasProductos ObtenerDetalleVentasProducto(DetalleVentasProductos dc)
        {
            DataTable tabla = ad.ObtenerTabla("DetalleVentasProductos", TodoDetalleVentaProducto + " where IdVenta_dvp= " + dc.IdVenta1.IdVenta1);
            dc.IdVenta1.IdVenta1 = Convert.ToInt32(tabla.Rows[0][0].ToString());
            dc.IdCliente1.IdCliente1 = Convert.ToInt32(tabla.Rows[0][1].ToString());
            dc.CodArticulo1.CodigoArticulo1 = tabla.Rows[0][2].ToString();
            dc.Cantidad1 = Convert.ToInt32(tabla.Rows[0][3].ToString());
            dc.Precio1 = Convert.ToInt32(tabla.Rows[0][4].ToString());
            return dc;
        }

        public DataTable getTablaDetalleProductoId(DetalleVentasProductos dc)
        {
            string consulta = TodoDetalleVentaProducto + " where IdVenta_dvp= " + dc.IdVenta1.IdVenta1;
            DataTable tabla = ad.ObtenerTabla("DetalleVentasProductos", consulta);
            return tabla;
        }

        public DataTable getTablaDetalleVentaProductos()
        {
            DataTable tabla = ad.ObtenerTabla("DetalleVentasProductos", TodoDetalleVentaProducto);
            return tabla;
        }

        public Boolean ExisteDetalleVentaProducto(DetalleVentasProductos dc)
        {
            string consulta = TodoDetalleVentaProducto + " where IdVenta_dvp= " + dc.IdVenta1.IdVenta1;
            return ad.existe(consulta);
        }

        public int AgregarDetalleVentaProducto(DetalleVentasProductos dc)
        {
            SqlCommand comando = new SqlCommand();
            ArmarProcedimientoDetalleVentaProductoAgregar(ref comando, dc);
            return ad.EjecutarProcedimientoAlmacenado(comando, "sp_AgregarDetalleVentaProducto");

        }

        private void ArmarProcedimientoDetalleVentaProductoAgregar(ref SqlCommand comando, DetalleVentasProductos dc)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@IDVENTA_DVP", SqlDbType.BigInt);
            parametros.Value = dc.IdVenta1.IdVenta1;
            parametros = comando.Parameters.Add("@IDCLIENTE_DVP", SqlDbType.BigInt);
            parametros.Value = dc.IdCliente1.IdCliente1;
            parametros = comando.Parameters.Add("@CODARTICULO_DVP", SqlDbType.Char);
            parametros.Value = dc.CodArticulo1.CodigoArticulo1;
            parametros = comando.Parameters.Add("@CANTIDAD_DVP", SqlDbType.BigInt);
            parametros.Value = dc.Cantidad1;
            parametros = comando.Parameters.Add("@PRECIO_DVC", SqlDbType.Decimal);
            parametros.Value = dc.Precio1;
            
        }
    }
}
