<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="ProyectoReciclaje.Reportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Reportes<br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Cerrar sesión" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Cambiar información personal" OnClick="Button2_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Dar de alta una unidad" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Cambiar datos de unidad" />
            <br />
            <br />
            <asp:GridView ID="GridView5" runat="server">
            </asp:GridView>
            <br />
            <br />
            <br />
            Reporte de Unidad<br />
            <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            </asp:CheckBoxList>
            <asp:DropDownList ID="DropDownList2" runat="server" Visible="False">
            </asp:DropDownList>
            <asp:CheckBox ID="CheckBox2" runat="server" Text="Filtrar por nombre repartidor" Visible="False" />
            <br />
            <br />
            <asp:GridView ID="GridView4" runat="server">
            </asp:GridView>
            <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click1" Text="Mostrar Reporte" />
            <br />
            <br />
            Reporte de Usuarios<br />
            <asp:CheckBoxList ID="CheckBoxList2" runat="server">
            </asp:CheckBoxList>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <asp:CheckBox ID="CheckBox1" runat="server" Text="usar filtro por nombre" />
            <br />
            <br />
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
            <br />
            <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
            <br />
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Mostrar Reporte" />
            <br />
            <br />
            Reporte Historial<br />
            <asp:CheckBoxList ID="CheckBoxList3" runat="server">
            </asp:CheckBoxList>
            <asp:GridView ID="GridView3" runat="server">
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Mostrar Reporte" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
