<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" href="Estilos.css" type="text/css"/>
<title>Login - GIM</title>
</head>
<body>
   
        <main class="main-login">
            <div>
                <p>Nombre:</p>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>    
            </div>

            <div>
                <p>Contraseña:</p>
                <asp:TextBox ID="txtContraseña" runat="server" CssClass="textBox"></asp:TextBox> 
            </div>
            
            <div>
                <asp:Button ID="btnEntrar" runat="server" OnClick="Button1_Click" Text="Entrar" />
            </div>

            <div style="height: 29px">
                <asp:Label ID="lblMensaje" runat="server" CssClass="label"></asp:Label>
            </div>

        </main>
  
</body>
</html>
