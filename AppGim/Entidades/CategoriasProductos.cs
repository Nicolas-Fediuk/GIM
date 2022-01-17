using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CategoriasProductos
    {
        private int IdCategoria;
        private string Descripcion;
        private int Estado;

        public CategoriasProductos()
        {

        }

        public int IdCategoria1 { get => IdCategoria; set => IdCategoria = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public int Estado1 { get => Estado; set => Estado = value; }
    }
}
