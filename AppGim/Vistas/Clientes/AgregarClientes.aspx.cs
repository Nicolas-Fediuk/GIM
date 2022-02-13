using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Entidades;
using CapaNegocio;

namespace Vistas.Clientes
{
    public partial class AgregarClientes : System.Web.UI.Page
    {
        GestionClientes gc = new GestionClientes();
        GestionRutinas gr = new GestionRutinas();
        Entidades.Clientes cli = new Entidades.Clientes(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            string ruta = "Data Source=DESKTOP-PCL9NE0\\SQLEXPRESS;Initial Catalog=DB_Gim;Integrated Security=True";
            string consulta = "select IdRutina_ru, Nombre_ru from Rutinas where Estado_ru = 1";
            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                SqlConnection sc = new SqlConnection(ruta);
                sc.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, sc);
                adaptador.Fill(ds, "Rutinas");
                ddlRutinas.DataSource = ds.Tables["Rutinas"];
                ddlRutinas.DataTextField = "Nombre_ru";
                ddlRutinas.DataValueField = "IdRutina_ru";
                ddlRutinas.DataBind();
                sc.Close();
            }
            
        }
       

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            cli.Nombre1 = txtNombre.Text;
            cli.Apellido1 = txtApellido.Text;
            cli.Edad1 = txtEdad.ToString();
            cli.Telefono1 = txtTelefono.ToString();
            cli.Email1 = txtEmail.Text;
            cli.Direccion1 = txtDireccion.Text;
            cli.ProblemasDeSalud1 = txtPds.Text;

            if (gc.AgregarCliente(cli))
            {
                lblMensaje.Text = "Cliente agregado";
            }
            else
            {
                lblMensaje.Text = "El cliente no pudo ser cargado";
            }
        }
    }
}