using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tarjetas
    {
        private Clientes IdUsuario;
        private string Titular;
        private string NombreTarjeta;
        private bool TipoTarjeta;
        private int NumeroTarjeta;
        private string FechaVencimiento;
        private int CodigoSeguridad;

        public Tarjetas()
        {

        }

        public Clientes IdUsuario1 { get => IdUsuario; set => IdUsuario = value; }
        public string Titular1 { get => Titular; set => Titular = value; }
        public string NombreTarjeta1 { get => NombreTarjeta; set => NombreTarjeta = value; }
        public bool TipoTarjeta1 { get => TipoTarjeta; set => TipoTarjeta = value; }
        public int NumeroTarjeta1 { get => NumeroTarjeta; set => NumeroTarjeta = value; }
        public string FechaVencimiento1 { get => FechaVencimiento; set => FechaVencimiento = value; }
        public int CodigoSeguridad1 { get => CodigoSeguridad; set => CodigoSeguridad = value; }
    }
}
