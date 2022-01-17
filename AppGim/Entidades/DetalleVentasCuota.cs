using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleVentasCuota
    {
        private Ventas IdVenta;
        private Clientes IdCliente;
        private Cuotas IdCuota;
        private float Precio;
        private string FechaInicio;
        private string FechaFin;

        public DetalleVentasCuota()
        {

        }

        public Ventas IdVenta1 { get => IdVenta; set => IdVenta = value; }
        public Clientes IdCliente1 { get => IdCliente; set => IdCliente = value; }
        public Cuotas IdCuota1 { get => IdCuota; set => IdCuota = value; }
        public float Precio1 { get => Precio; set => Precio = value; }
        public string FechaInicio1 { get => FechaInicio; set => FechaInicio = value; }
        public string FechaFin1 { get => FechaFin; set => FechaFin = value; }
    }
}
