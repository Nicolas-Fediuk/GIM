using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using CapaDao;

namespace CapaNegocio
{
    public class GestionCategoriaArticulos
    {
        DaoCategoriaProducto dao = new DaoCategoriaProducto();

        public DataTable getCategoriasArticulos()
        {
            return dao.getTablaCategoria();
        }

        public DataTable getCategoriaPorId(CategoriasProductos cp)
        {
            return dao.getTablaCategoriaId(cp);
        }

        public bool ExisteCategoriaProducto(CategoriasProductos cp)
        {
            if (dao.ExisteCategoria(cp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AgregarCategoriaProducto(CategoriasProductos cp)
        {
            int cantFila = 0;
            if (dao.ExisteCategoria(cp) == false)
            {
                cantFila = dao.AgregarCategoria(cp);
            }

            if(cantFila == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ModificarCategoriaProducto(CategoriasProductos cp)
        {
            bool eliminado = dao.ModificarCategoria(cp);
            if(eliminado == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool EliminarCategoriaProducto(CategoriasProductos cp)
        {
            int eliminado = dao.EliminarCategoria(cp);

            if(eliminado == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
