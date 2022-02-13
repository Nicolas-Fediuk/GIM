<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" href="Estilos.css" type="text/css"/>
<title>Login - GIM</title>
</head>
<body>
    <form runat="server">
   
        <main class="main-login">
            
                
                <h1 class:"h1-login"> GIM </h1>
           
          
       
                <p class:"p-login">Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></p>
                    
            

            
                <p class:"p-login">Contraseña: <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox></p>
                 
           
            
            
                <asp:Button ID="btnEntrar" runat="server" OnClick="Button1_Click" Text="Entrar" />
           

     
                <asp:Label ID="lblMensaje" runat="server" CssClass="label-login"></asp:Label>
           

        </main>
  </form>
</body>
</html>
