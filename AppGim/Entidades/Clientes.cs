using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Clientes
    {
        private int IdCliente;
        private string Nombre;
        private string Apellido;
        private string Edad;
        private string Telefono;
        private string Email;
        private string Direccion;
        private string ProblemasDeSalud;
        private Rutinas IdRutina;
        private bool Estado;

        public Clientes()
        {

        }

        public int IdCliente1 { get => IdCliente; set => IdCliente = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apellido1 { get => Apellido; set => Apellido = value; }
        public string Edad1 { get => Edad; set => Edad = value; }
        public string Telefono1 { get => Telefono; set => Telefono = value; }
        public string Email1 { get => Email; set => Email = value; }
        public string Direccion1 { get => Direccion; set => Direccion = value; }
        public string ProblemasDeSalud1 { get => ProblemasDeSalud; set => ProblemasDeSalud = value; }
        public Rutinas IdRutina1 { get => IdRutina; set => IdRutina = value; }
        public bool Estado1 { get => Estado; set => Estado = value; }
    }
}
