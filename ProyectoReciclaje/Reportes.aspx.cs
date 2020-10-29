using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ProyectoReciclaje
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["correo"] == null || Session["nombre"] == null)
            {

                Session.Clear();
                Session.Abandon();
                Response.Redirect("Logins.aspx");
            }

            if(Label1.Text == "")
            {
                Label1.Text = "Bienvenid@ " + Session["nombre"].ToString();

                
                String query = "select Usuario.nombre, Unidad.nombreRecolector, Historial.cHistorial, Historial.monto  " +
                    "from Historial inner join Contacta on Historial.cHistorial = Contacta.cHistorial " +
                    "inner join Usuario on Contacta.telefono = Usuario.telefono " +
                    "inner join Unidad on Contacta.placa = Unidad.placa ";

                OdbcConnection con = new ConexionBD().conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                OdbcDataReader lector = comando.ExecuteReader();

                GridView5.DataSource = lector;
                GridView5.DataBind();
                con.Close();
                
            }

            if (DropDownList2.Items.Count == 0)
            {
                String query02 = "select nombreRecolector, placa from Unidad";
                OdbcConnection con02 = new ConexionBD().conexion;
                OdbcCommand comando02 = new OdbcCommand(query02, con02);
                OdbcDataReader lector = comando02.ExecuteReader();
                DropDownList2.DataSource = lector;
                DropDownList2.DataTextField = "nombreRecolector";
                DropDownList2.DataValueField = "placa";
                DropDownList2.DataBind();
                con02.Close();
            }

            if (CheckBoxList1.Items.Count == 0)
            {
                CheckBoxList1.Items.Add(new ListItem("Placa de la unidad", "unidad.Placa"));
                CheckBoxList1.Items.Add(new ListItem("Nombre del conductor", "unidad.nombreRecolector"));
                CheckBoxList1.Items.Add(new ListItem("Saldo de la unidad", "unidad.saldo"));
                CheckBoxList1.Items.Add(new ListItem("Telefono del conductor", "unidad.telefono"));
            }

            if (DropDownList1.Items.Count == 0)
            {
                String query01 = "select nombre, telefono from Usuario";
                OdbcConnection con01 = new ConexionBD().conexion;
                OdbcCommand comando01 = new OdbcCommand(query01, con01);
                OdbcDataReader lector = comando01.ExecuteReader();
                DropDownList1.DataSource = lector;
                DropDownList1.DataTextField = "nombre";
                DropDownList1.DataValueField = "telefono";
                DropDownList1.DataBind();
                con01.Close();
            }

            if (CheckBoxList2.Items.Count == 0)
            {
                CheckBoxList2.Items.Add(new ListItem("Telefono del Usuario", "usuario.telefono"));
                CheckBoxList2.Items.Add(new ListItem("Nombre del Usuario", "usuario.nombre"));
                CheckBoxList2.Items.Add(new ListItem("Direccion del Usuario", "usuario.direccion"));
                CheckBoxList2.Items.Add(new ListItem("Tarjeta del Usuario", "usuario.tarjetaCredito"));
            }

            if (CheckBoxList3.Items.Count == 0)
            {
                CheckBoxList3.Items.Add(new ListItem("Fecha", "historial.fecha"));
                CheckBoxList3.Items.Add(new ListItem("Monto", "historial.monto"));
                CheckBoxList3.Items.Add(new ListItem("Cantidad", "historial.cantidad"));
                CheckBoxList3.Items.Add(new ListItem("Descripcion", "historial.descripcion"));
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Logins.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarInfoAdmin.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevaUnidad.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarUnidad.aspx");
        }

        protected void Button5_Click1(object sender, EventArgs e)
        {
            try
            {
                String select = " select ";
                String from = " from Unidad ";
                String where = " where placa= ";

                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (CheckBoxList1.Items[i].Selected == true)
                    {//Si esta seleccionado, lo pegamos
                        select = select + CheckBoxList1.Items[i].Value + ",";
                    }
                }


                //Quitar la , del final del select y le pongo un espacio
                select = select.Substring(0, select.Length - 1);
                select = select + " ";

                String GridView1Query = select + from;

                
                if (CheckBox2.Checked==true)
                {
                    where = where + DropDownList2.SelectedValue.ToString();
                    GridView1Query = GridView1Query + where;
                }

                Label2.Text = GridView1Query;
                OdbcConnection GridView1Con = new ConexionBD().conexion;
                OdbcCommand GridView1Comando = new OdbcCommand(GridView1Query, GridView1Con);
                OdbcDataReader GridView1Lector = GridView1Comando.ExecuteReader();

                GridView4.DataSource = GridView1Lector;
                GridView4.DataBind();
                GridView1Con.Close();
            }
            catch (Exception ex)
            {
                String exe = ex.ToString();
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            try
            {
                String select = " select ";
                String from = " from usuario ";
                String where = " where telefono= ";


                for (int i = 0; i < CheckBoxList2.Items.Count; i++)
                {
                    if (CheckBoxList2.Items[i].Selected == true)
                    {//Si esta seleccionado, lo pegamos
                        select = select + CheckBoxList2.Items[i].Value + ",";
                    }
                }

                
                //Quitar la , del final del select y le pongo un espacio
                select = select.Substring(0, select.Length - 1);
                select = select + " ";

                String GridView2Query = select + from;

                if (CheckBox1.Checked)
                {
                    where = where + DropDownList1.SelectedValue.ToString();
                    GridView2Query = GridView2Query + where;
                }

                Label3.Text = GridView2Query;
                OdbcConnection GridView2Con = new ConexionBD().conexion;
                OdbcCommand GridView2Comando = new OdbcCommand(GridView2Query, GridView2Con);
                OdbcDataReader GridView2Lector = GridView2Comando.ExecuteReader();

                GridView2.DataSource = GridView2Lector;
                GridView2.DataBind();
                GridView2Con.Close();

            }
            catch (Exception ese)
            {
                String esa = ese.ToString();
            }


        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            try
            {
                String select = " select ";
                String from = " from historial ";

                for (int i = 0; i < CheckBoxList3.Items.Count; i++)
                {
                    if (CheckBoxList3.Items[i].Selected == true)
                    {//Si esta seleccionado, lo pegamos
                        select = select + CheckBoxList3.Items[i].Value + ",";
                    }
                }

                select = select.Substring(0, select.Length - 1);
                select = select + " ";

                String GridView3Query = select + from;
                OdbcConnection GridView3Con = new ConexionBD().conexion;
                OdbcCommand GridView3Comando = new OdbcCommand(GridView3Query, GridView3Con);
                OdbcDataReader GridView3Lector = GridView3Comando.ExecuteReader();

                GridView3.DataSource = GridView3Lector;
                GridView3.DataBind();
                GridView3Con.Close();

            }
            catch (Exception ex)
            {
                String esas = ex.ToString();
            }

        }
    }
}