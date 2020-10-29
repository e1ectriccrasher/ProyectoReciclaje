<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HacerPedido.aspx.cs" Inherits="ProyectoReciclaje.HacerPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Realizar pedidos&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Cerrar sesión" OnClick="Button2_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Cambiar información personal" OnClick="Button3_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" Text="Historial de pedidos" OnClick="Button4_Click" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" Visible="False">
            </asp:GridView>
            <br />
            <br />
&nbsp;&nbsp;&nbsp; - Crear pedido
            <br />
            <br />
            Seleccione su tipo de basura<br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Mostrar precio" />
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <br />
            Ingrese la cantidad en kilos:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Cotizar" />
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Hacer pedido" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Borrar cuenta" />
            <br />
        </div>
    </form>
</body>
</html>
