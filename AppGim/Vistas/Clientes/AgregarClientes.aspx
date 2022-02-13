<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarClientes.aspx.cs" Inherits="Vistas.Clientes.AgregarClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Nombre:<asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <br />
            Apellido:<asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            <br />
            <br />
            Edad:<asp:TextBox ID="txtEdad" runat="server"></asp:TextBox>
            <br />
            <br />
            Telefono:<asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            <br />
            <br />
            Email:<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <br />
            Direccion:<asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            <br />
            <br />
            Problemas de salud:<asp:TextBox ID="txtPds" runat="server"></asp:TextBox>
            <br />
            <br />
            Rutina:<asp:DropDownList ID="ddlRutinas" runat="server" AutoPostBack="True">
            </asp:DropDownList>
        </div>
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </form>
</body>
</html>
