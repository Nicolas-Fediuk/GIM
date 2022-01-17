using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ventas
    {
        private int IdVenta;
        private Clientes IdCliente;
        private float Total;
        private string FechaVenta;
        private bool MetodoPago;

        public Ventas()
        {

        }

        public int IdVenta1 { get => IdVenta; set => IdVenta = value; }
        public Clientes IdCliente1 { get => IdCliente; set => IdCliente = value; }
        public float Total1 { get => Total; set => Total = value; }
        public string FechaVenta1 { get => FechaVenta; set => FechaVenta = value; }
        public bool MetodoPago1 { get => MetodoPago; set => MetodoPago = value; }
    }
}
