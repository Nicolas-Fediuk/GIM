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
    public class DaoRutinas
    {
        AccesoDatos ad = new AccesoDatos();
        const string TodasRutinas = "select * from Rutinas";

        public Rutinas ObtenerRutina(Rutinas r)
        {
            DataTable tabla = ad.ObtenerTabla("Rutinas", "select IdRutina_ru,Nombre_ru from Rutinas where IdRutina_ru= " + r.IdRutina1);
            r.IdRutina1 = Convert.ToInt32(tabla.Rows[0][0].ToString());
            r.Nombre1 = tabla.Rows[0][1].ToString();
            r.Estado1 = Convert.ToBoolean(tabla.Rows[0][2].ToString());
            return r;
        }

        public DataTable getTablaRutinaId(Rutinas r)
        {
            string NuevaConsulta = TodasRutinas + "where IdRutina_ru = " + r.IdRutina1;
            DataTable tabla = ad.ObtenerTabla("Rutinas", NuevaConsulta);
            return tabla;
        }

        public DataTable getRutinasTrue()
        {
            string consulta =  "select Nombre_ru from Rutinas where Estado_ru = 1";
            DataTable tabla = ad.ObtenerTabla("Rutinas", consulta);
            return tabla;

            
        }

        public DataTable getTablaRutinas()
        {
            DataTable tabla = ad.ObtenerTabla("Rutinas",TodasRutinas);
            return tabla;
        }

        public Boolean ExisteRutina(Rutinas r)
        {
            string consulta = TodasRutinas + "where IdRutina_ru = " + r.IdRutina1;
            return ad.existe(consulta);
        }

        public int AgregarRutina( Rutinas r)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametroAgregarRutina(ref comando, r);
            return ad.EjecutarProcedimientoAlmacenado(comando, "sp_AgregarRutina");

        }

        public void ArmarParametroAgregarRutina(ref SqlCommand comando,Rutinas r)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@NOMBRE_RU", SqlDbType.VarChar);
            parametros.Value = r.Nombre1;
        }

        public bool ModificarRutina(Rutinas r)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametroModificarRutina(ref comando, r);
            int FilasInsertadas = ad.EjecutarProcedimientoAlmacenado(comando, "sp_ModificarRutina");
            if(FilasInsertadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ArmarParametroModificarRutina(ref SqlCommand comando,Rutinas r)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@IDRUTINA_RU", SqlDbType.Int);
            parametros.Value = r.IdRutina1;
            parametros = comando.Parameters.Add("@NOMBRE_RU", SqlDbType.VarChar);
            parametros.Value = r.Nombre1;
        }

        public int EliminarRutina(Rutinas r)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametroEliminarRutina(ref comando, r);
            return ad.EjecutarProcedimientoAlmacenado(comando, "sp_EliminarRutina");
        }

        public void ArmarParametroEliminarRutina(ref SqlCommand comando, Rutinas r)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@IDRUTINA_RU", SqlDbType.Int);
            parametros.Value = r.IdRutina1;
        }
        
        
    }
}
