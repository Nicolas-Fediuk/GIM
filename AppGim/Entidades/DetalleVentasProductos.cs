using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleVentasProductos
    {
        private Ventas IdVenta;
        private Clientes IdCliente;
        private Productos CodArticulo;
        private int Cantidad;
        private float Precio;

        public DetalleVentasProductos()
        {

        }

        public Ventas IdVenta1 { get => IdVenta; set => IdVenta = value; }
        public Clientes IdCliente1 { get => IdCliente; set => IdCliente = value; }
        public Productos CodArticulo1 { get => CodArticulo; set => CodArticulo = value; }
        public int Cantidad1 { get => Cantidad; set => Cantidad = value; }
        public float Precio1 { get => Precio; set => Precio = value; }
    }
}
