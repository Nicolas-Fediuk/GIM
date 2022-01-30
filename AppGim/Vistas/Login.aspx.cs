using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using CapaNegocio;

namespace Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        GestionAdmin ga = new GestionAdmin();
        Admin Admin = new Admin();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Admin.Nombre1 = txtNombre.Text;
            Admin.Contraseña1 = txtContraseña.Text;

            if (ga.ExisteAdmin(Admin))
            {
                Server.Transfer("HomeAdmin.aspx");
            }
            else
            {
                lblMensaje.Text = "Error";
            }
        }
    }
}