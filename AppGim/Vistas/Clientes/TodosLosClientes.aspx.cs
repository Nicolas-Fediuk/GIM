using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using CapaNegocio;

namespace Vistas.Clientes
{
    public partial class TodosLosClientes : System.Web.UI.Page
    {
        GestionClientes gc = new GestionClientes();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarClientes();
        }

        public void cargarClientes()
        {
            gvClientes.DataSource = gc.ObtenerListaClientes();
            gvClientes.DataBind();
        }
    }
}