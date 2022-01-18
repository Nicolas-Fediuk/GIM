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
    public class DaoProductos
    {
        AccesoDatos ad = new AccesoDatos();
        const string TodosProductos = "select * from Productos";

        public Productos ObtenerProducto(Productos p)
        {
            DataTable tabla = ad.ObtenerTabla("Productos", "select CodArticulo_p,Categoria_p,Descripcion_p,Stock_p,Precio_p,Imagen_p from Productos where CodArticulo_p= '" + p.CodigoArticulo1 + "'");
            p.CodigoArticulo1 = tabla.Rows[0][0].ToString();
            p.Categoria1.IdCategoria1 = Convert.ToInt32(tabla.Rows[0][1].ToString());
            p.Descripcion1 = tabla.Rows[0][2].ToString();
            p.Stock1 = Convert.ToInt32(tabla.Rows[0][3].ToString());
            p.Precio1 = Convert.ToInt32(tabla.Rows[0][4].ToString());
            p.Imagen1 = tabla.Rows[0][5].ToString();
            p.Estado1 = Convert.ToBoolean(tabla.Rows[0][6].ToString());
            return p;
        }

        public DataTable getTablaCodProducto(Productos p)
        {
            string NuevaCosulta = TodosProductos + "where CodArticulo_p = '" + p.CodigoArticulo1 + "'";
            DataTable tabla = ad.ObtenerTabla("Productos", NuevaCosulta);
            return tabla;
        }

        public DataTable getTablaProductos()
        {
            DataTable tabla = ad.ObtenerTabla("Productos", TodosProductos);
            return tabla;
        }

        public Boolean ExisteProducto(Productos p)
        {
            string consulta = TodosProductos + "where Descripcion_p = '" + p.Descripcion1 + "'";
            return ad.existe(consulta);
        }

        public int AgregarProducto(Productos p)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosAgregarProductos(ref comando, p);
            return ad.EjecutarProcedimientoAlmacenado(comando, "sp_AgregarProducto");
        }

        private void ArmarParametrosAgregarProductos(ref SqlCommand comando, Productos p)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@CODARTICULO_P", SqlDbType.Char);
            parametros.Value = p.CodigoArticulo1;
            parametros = comando.Parameters.Add("@CATEGORIA_P", SqlDbType.BigInt);
            parametros.Value = p.Categoria1.IdCategoria1;
            parametros = comando.Parameters.Add("@DESCRIPCION_P", SqlDbType.VarChar);
            parametros.Value = p.Descripcion1;
            parametros = comando.Parameters.Add("@STOCK_P", SqlDbType.BigInt);
            parametros.Value = p.Stock1;
            parametros = comando.Parameters.Add("@PRECIO_P", SqlDbType.Decimal);
            parametros.Value = p.Precio1;
            parametros = comando.Parameters.Add("@IMAGEN_P", SqlDbType.VarChar);
            parametros.Value = p.Imagen1;
        }

        public bool ModificarProducto(Productos p)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosAgregarProductos(ref comando, p);
            int FilasInsertadas = ad.EjecutarProcedimientoAlmacenado(comando, "sp_ModificarArticulo");
            if(FilasInsertadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int EliminarProducto(Productos p)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosEliminarProductos(ref comando, p);
            return ad.EjecutarProcedimientoAlmacenado(comando, "sp_EliminarProducto");
        }

        private void ArmarParametrosEliminarProductos(ref SqlCommand comando,Productos p)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@CODARTICULO_P",SqlDbType.Char);
            parametros.Value = p.CodigoArticulo1;
        }
    }
}
