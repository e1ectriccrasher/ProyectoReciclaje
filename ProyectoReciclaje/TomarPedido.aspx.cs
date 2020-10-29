using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ProyectoReciclaje
{
    public partial class TomarPedido : System.Web.UI.Page
    {
        String tel = "";
        int cHist = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["placas"] == null || Session["nombre"] == null)
            {

                Session.Clear();
                Session.Abandon();
                Response.Redirect("Logins.aspx");
            }

            if(Label1.Text == "")
            {
                Label1.Text = "Bienvenid@ " + Session["nombre"].ToString();

                String query = "select descripcion, monto, fecha " +
                    "from Historial inner join Contacta on Historial.cHistorial = Contacta.cHistorial " +
                    "where Contacta.placa = ? ";

                OdbcConnection con = new ConexionBD().conexion;
                OdbcCommand comando = new OdbcCommand(query, con);

                comando.Parameters.AddWithValue("placa", Session["placas"]);
                OdbcDataReader lector = comando.ExecuteReader();

                GridView1.DataSource = lector;
                GridView1.DataBind();
                con.Close();
            }

            if (DropDownList1.Items.Count == 0)
            {
                String queryDropdown = "select cBasura, peso from basura where placa is null";
                OdbcConnection conDropDown = new ConexionBD().conexion;
                OdbcCommand comDropDown = new OdbcCommand(queryDropdown, conDropDown);
                OdbcDataReader lectorDropDown = comDropDown.ExecuteReader();

                DropDownList1.DataSource = lectorDropDown;
                DropDownList1.DataValueField = "cBasura";
                DropDownList1.DataTextField = "peso";
                DropDownList1.DataBind();
                conDropDown.Close();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Logins.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarInfoUnidad.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                String queryUp = "update Basura set placa=? where cBasura=?";

                OdbcConnection conUp = new ConexionBD().conexion;
                OdbcCommand comUp = new OdbcCommand(queryUp, conUp);
                comUp.Parameters.AddWithValue("placa", Session["placas"]);
                comUp.Parameters.AddWithValue("cBasura", DropDownList1.SelectedValue);
                comUp.ExecuteNonQuery();
                conUp.Close();

                String queryPed = "select usuario.nombre, usuario.telefono, Contacta.cHistorial, Usuario.direccion, Tipo.nombre, basura.peso " +
                                  " from Contacta inner join Usuario on Contacta.telefono = Usuario.telefono " +
                                  "inner join basura on Usuario.telefono = Basura.telefono " +
                                  "inner join Tipo on Basura.cTipo = Tipo.cTipo " +
                                  "where basura.cBasura = ?";

                OdbcConnection conPed = new ConexionBD().conexion;
                OdbcCommand comPed = new OdbcCommand(queryPed, conPed);

                comPed.Parameters.AddWithValue("cBasura", DropDownList1.SelectedValue);
                comPed.Parameters.AddWithValue("placa", Session["placas"]);
                OdbcDataReader lectorPedido = comPed.ExecuteReader();

                if(lectorPedido.HasRows == true)
                {
                    tel = lectorPedido.GetString(1);
                    Session["tel"] = tel;
                    cHist = lectorPedido.GetInt32(2);
                    Session["cHist"] = cHist;
                    Label4.Text = cHist.ToString();
                    GridView2.DataSource = lectorPedido;
                    GridView2.DataBind();
                }


                Label2.Text = "Se pueden ver los pedidos. ";

                conPed.Close();
            }
            catch (Exception es)
            {
                Label2.Text = "No se pudo ver los pedidos. " + es.ToString();
            }
            


        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {

                String querySaldo = "update Unidad set saldo=(select saldo from unidad where placa=?)+25 where placa=?";

                OdbcConnection conS = new ConexionBD().conexion;
                OdbcCommand comS = new OdbcCommand(querySaldo, conS);
                comS.Parameters.AddWithValue("placa", Session["placas"]);
                comS.Parameters.AddWithValue("placa", Session["placas"]);
                comS.ExecuteNonQuery();

                
                conS.Close();

                String queryBorrar = "delete from basura where placa is not null";

                OdbcConnection conB = new ConexionBD().conexion;
                OdbcCommand comB = new OdbcCommand(queryBorrar, conB);
                comB.ExecuteNonQuery();
                conB.Close();

                conB.Close();

                String queryC = "update Contacta set placa = ? where telefono = ? and cHistorial = ?";

                OdbcConnection conC = new ConexionBD().conexion;
                OdbcCommand comandoC = new OdbcCommand(queryC, conC);

                comandoC.Parameters.AddWithValue("placa", Session["placas"]);
                comandoC.Parameters.AddWithValue("tel", Session["tel"]);
                comandoC.Parameters.AddWithValue("cHist", Session["cHist"]);

                comandoC.ExecuteNonQuery();

                conC.Close();



                Label3.Text = "Se tomo exitosamente el pedido.";
            }
            catch (Exception es)
            {
                Label3.Text = "No se tomo el pedido exitosamente. " + es.ToString();
            }
            
            
        }
    }
}