<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TomarPedido.aspx.cs" Inherits="ProyectoReciclaje.TomarPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Tomar pedidos disponibles<br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Cerrar sesión" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Cambiar información personal" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            Pedidos disponibles (en kilos):
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Tomar pedido" />
            <asp:Label ID="Label4" runat="server" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
            <br />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Finalizar pedido" />
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Historial de pedidos realizados" OnClick="Button3_Click" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" Visible="False">
            </asp:GridView>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
