<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevaUnidad.aspx.cs" Inherits="ProyectoReciclaje.NuevaUnidad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nueva Unidad</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Nueva Unidad<br />
            <br />
            Placas:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            Nombre del recolector:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            Telefono:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            Saldo:
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            <br />
            <br />
            Contraseña:<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            <br />
            Confirmar contaseña:<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Alta" />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Regresar a reportes" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
