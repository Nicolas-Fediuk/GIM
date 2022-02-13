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
    public class AccesoDatos
    {
        string DbGim = "Data Source=DESKTOP-PCL9NE0\\SQLEXPRESS;Initial Catalog=DB_Gim;Integrated Security=True";

        public AccesoDatos()
        {

        }
            
        private SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(DbGim);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private SqlDataAdapter ObtenerAdaptador(string colsultaSql, SqlConnection cn)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(colsultaSql, cn);
                return adaptador;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public DataTable ObtenerTabla(string NombreTabla, string Sql)
        {
            DataSet dt = new DataSet();
            SqlConnection conexion = ObtenerConexion();
            SqlDataAdapter adp = ObtenerAdaptador(Sql, conexion);
            adp.Fill(dt,NombreTabla);
            conexion.Close();
            return dt.Tables[NombreTabla];
        }

        public int EjecutarProcedimientoAlmacenado (SqlCommand comando, string NombreSp)
        {
            int FilasCambiadas;
            SqlConnection conexion = ObtenerConexion ();
            SqlCommand cmd = new SqlCommand();
            cmd = comando;
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSp; 
            FilasCambiadas = cmd.ExecuteNonQuery();
            conexion.Close();
            return FilasCambiadas;
        }

        public Boolean existe(string consulta)
        {
            Boolean estado = false;
            SqlConnection conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand (consulta,conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                estado = true;
            }
            return estado;
        }


    }



    


}
