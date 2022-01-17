using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Admin
    {
        private string Nombre;
        private string Contraseña;

        public Admin()
        {

        }

        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Contraseña1 { get => Contraseña; set => Contraseña = value; }
    }
}
