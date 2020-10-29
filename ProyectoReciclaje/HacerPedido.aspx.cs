using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ProyectoReciclaje
{
    public partial class HacerPedido : System.Web.UI.Page
    {
        double plastico = 50, carton = 25, papel = 10, organica = 15, vidrio = 50;
        double monto = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["telefono"] == null || Session["nombre"] == null)
            {

                Session.Clear();
                Session.Abandon();
                Response.Redirect("Logins.aspx");
            }

            if(Label1.Text == "")
            {
                Label1.Text = "Bienvenid@ " + Session["nombre"].ToString();

                if (DropDownList1.Items.Count == 0)
                {
                    String queryDropdown = "select cTipo, nombre from Tipo";
                    OdbcConnection conDropDown = new ConexionBD().conexion;
                    OdbcCommand comDropDown = new OdbcCommand(queryDropdown, conDropDown);
                    OdbcDataReader lectorDropDown = comDropDown.ExecuteReader();

                    DropDownList1.DataSource = lectorDropDown;
                    DropDownList1.DataValueField = "cTipo";
                    DropDownList1.DataTextField = "nombre";
                    DropDownList1.DataBind();
                    conDropDown.Close();
                }

                String query = "select descripcion, monto, fecha " +
                    "from Historial inner join Contacta on Historial.cHistorial = Contacta.cHistorial " +
                    "where Contacta.telefono = ? ";

                OdbcConnection con = new ConexionBD().conexion;
                OdbcCommand comando = new OdbcCommand(query, con);

                comando.Parameters.AddWithValue("telefono", Session["telefono"]);
                OdbcDataReader lector = comando.ExecuteReader();

                GridView1.DataSource = lector;
                GridView1.DataBind();
                con.Close();
                
            }

            


        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            String cant = TextBox1.Text;
            double p = 0;
            double c = Convert.ToDouble(cant);

            int seleccion = DropDownList1.SelectedIndex;

            if (seleccion == 0)
                p = plastico;
            if (seleccion == 1)
                p = carton;
            if (seleccion == 2)
                p = papel;
            if (seleccion == 3)
                p = organica;
            if (seleccion == 4)
                p = vidrio;
            monto = c * p;
            double montoDe = Convert.ToDouble(monto);
            Session["monto"] = montoDe;
            Label3.Text = "Precio total: $" + monto.ToString();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            String queryDel = "delete from usuario where telefono = ?";

            OdbcConnection conDel = new ConexionBD().conexion;
            OdbcCommand comDel = new OdbcCommand(queryDel, conDel);
            comDel.Parameters.AddWithValue("telefono", Session["telefono"]);
            comDel.ExecuteNonQuery();
            conDel.Close();
            Session.Abandon();
            Response.Redirect("Logins.aspx");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int claveI = 0, claveF, claveI2 = 0, claveF2;

            //LLave primaira basuar
            String queryB = "select cBasura from Basura order by cBasura desc";
            OdbcConnection conB = new ConexionBD().conexion;

            OdbcCommand comandoB = new OdbcCommand(queryB, conB);
            OdbcDataReader lectorB = comandoB.ExecuteReader();

            if (lectorB.HasRows == true)
            {
                claveI2 = lectorB.GetInt32(0);   //Guarda la llave con numero mas alto
            }
            else
                claveI2 = 0;

            conB.Close();

            String queryPe = "insert into Basura values(?, ?, ?, null, ?)";

            claveF2 = claveI2 + 1;
            OdbcConnection conPe = new ConexionBD().conexion;
            OdbcCommand comPe = new OdbcCommand(queryPe, conPe);

            comPe.Parameters.AddWithValue("cBasura", claveF2);
            comPe.Parameters.AddWithValue("peso", TextBox1.Text);
            comPe.Parameters.AddWithValue("telefono", Session["telefono"]);
            comPe.Parameters.AddWithValue("cTipo", DropDownList1.SelectedValue);
            comPe.ExecuteNonQuery();

            Label4.Text = "Pedido exitoso";
            conPe.Close();

            //LLave primaira
            String query1 = "select cHistorial from Historial order by cHistorial desc";
            OdbcConnection con1 = new ConexionBD().conexion;

            OdbcCommand comando1 = new OdbcCommand(query1, con1);
            OdbcDataReader lector1 = comando1.ExecuteReader();

            if (lector1.HasRows == true)
            {
                claveI = lector1.GetInt32(0);   //Guarda la llave con numero mas alto
            }

            con1.Close();
            

            claveF = claveI + 1;
            String queryHist = "insert into Historial values(?, CURRENT_TIMESTAMP, ?, ?, ?)";
            OdbcConnection conHist = new ConexionBD().conexion;
            OdbcCommand comHist = new OdbcCommand(queryHist, conHist);

            comHist.Parameters.AddWithValue("cHis", claveF);
            comHist.Parameters.AddWithValue("monto", Session["monto"]);
            comHist.Parameters.AddWithValue("cantidad", TextBox1.Text);

            String txt = DropDownList1.SelectedItem.ToString() + " " + Label3.Text;
            comHist.Parameters.AddWithValue("descripcion", txt); ;
            comHist.ExecuteNonQuery();

            Label2.Text = "";
            Label3.Text = "";
            TextBox1.Text = "";


            conHist.Close();


            //INsert contact

            String queryCon = "insert into Contacta values (? , ? , null)";
            OdbcConnection conCon = new ConexionBD().conexion;
            OdbcCommand comandoCo = new OdbcCommand(queryCon, conCon);

            comandoCo.Parameters.AddWithValue("tel", Session["telefono"]);
            comandoCo.Parameters.AddWithValue("cHist", claveF);

            comandoCo.ExecuteNonQuery();

            conCon.Close();


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Logins.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarInfoUsuario.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            int seleccion = DropDownList1.SelectedIndex;

            if (seleccion == 0)
                Label2.Text = "$" + plastico + " por kilo";
            if (seleccion == 1)
                Label2.Text = "$" +carton+ " por kilo";
            if (seleccion == 2)
                Label2.Text = "$" + papel + " por kilo";
            if (seleccion == 3)
                Label2.Text = "$" + organica + " por kilo";
            if (seleccion == 4)
                Label2.Text = "$" + vidrio + " por kilo";

            TextBox1.Text = "";
            Label3.Text = "";
        }

    }
}