<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TodosLosClientes.aspx.cs" Inherits="Vistas.Clientes.TodosLosClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvClientes" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
