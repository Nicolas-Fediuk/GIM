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
    public class DaoCategoriaProducto
    {
        AccesoDatos ad = new AccesoDatos();
        const string TodasLasCategorias = "select * from CategoriasProductos"; 

        public CategoriasProductos ObtenerCategoria(CategoriasProductos cp)
        {
            DataTable tabla = ad.ObtenerTabla("CategoriasProductos", "select IdCategoria_cp,Descripcion_cp from CategoriasProductos where IdCategoria_cp = "+cp.IdCategoria1);
            cp.IdCategoria1 = Convert.ToInt32(tabla.Rows[0][0].ToString());
            cp.Descripcion1 = tabla.Rows[0][1].ToString();
            cp.Estado1 = Convert.ToBoolean(tabla.Rows[0][2].ToString());
            return cp;
        }

        public DataTable getTablaCategoriaId(CategoriasProductos cp)
        {
            string NuevaConsulta = TodasLasCategorias + "where IdCategoria_cp = " + cp.IdCategoria1;
            DataTable tabla = ad.ObtenerTabla("CategoriasProductos", NuevaConsulta);
            return tabla;
        }

        public DataTable getTablaCategoria() {
            DataTable tabla = ad.ObtenerTabla("CategoriasProductos", TodasLasCategorias);
            return tabla;
        }

        public Boolean ExisteCategoria(CategoriasProductos cp)
        {
            string cosulta = TodasLasCategorias + "where IdCategoria_cp= " + cp.IdCategoria1;
            return ad.existe(cosulta);
        }

        public int AgregarCategoria(CategoriasProductos cp)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosAgregarCategoria(ref comando, cp);
            return ad.EjecutarProcedimientoAlmacenado(comando, "sp_AgregarCategoriasProductos");
        }

        public void ArmarParametrosAgregarCategoria(ref SqlCommand comando, CategoriasProductos cp)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar);
            parametros.Value = cp.Descripcion1;
        }

        public bool ModificarCategoria(CategoriasProductos cp)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosModificarCategoria(ref comando, cp);
            int FilasInsertadas = ad.EjecutarProcedimientoAlmacenado(comando, "sp_ModificarCategorias");
            if(FilasInsertadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ArmarParametrosModificarCategoria(ref SqlCommand comando, CategoriasProductos cp)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@IDCATEGORIA", SqlDbType.BigInt);
            parametros.Value = cp.IdCategoria1;
            parametros = comando.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar);
            parametros.Value = cp.Descripcion1;
        }

        public int EliminarCategoria(CategoriasProductos cp)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosEliminarCategoria(ref comando, cp);
            return ad.EjecutarProcedimientoAlmacenado(comando, "sp_EliminarCategoriasProductos");
        }

        public void ArmarParametrosEliminarCategoria(ref SqlCommand comando,CategoriasProductos cp)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@IDCATEGORIA", SqlDbType.BigInt);
            parametros.Value = cp.IdCategoria1;
        }
    }
}
