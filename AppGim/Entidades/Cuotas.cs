using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cuotas
    {
        private int IdTipoCuota;
        private string Descripcion;
        private float Precio;
        private bool Estado;

        public Cuotas()
        {

        }
        public int IdTipoCuota1 { get => IdTipoCuota; set => IdTipoCuota = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public float Precio1 { get => Precio; set => Precio = value; }
        public bool Estado1 { get => Estado; set => Estado = value; }
    }
}
