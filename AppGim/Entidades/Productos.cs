using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Productos
    {
        private string CodigoArticulo;
        private CategoriasProductos Categoria;
        private string Descripcion;
        private int Stock;
        private float Precio;
        private string Imagen;
        private bool Estado;

        public Productos()
        {

        }

        public string CodigoArticulo1 { get => CodigoArticulo; set => CodigoArticulo = value; }
        public CategoriasProductos Categoria1 { get => Categoria; set => Categoria = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public int Stock1 { get => Stock; set => Stock = value; }
        public float Precio1 { get => Precio; set => Precio = value; }
        public string Imagen1 { get => Imagen; set => Imagen = value; }
        public bool Estado1 { get => Estado; set => Estado = value; }
    }
}
