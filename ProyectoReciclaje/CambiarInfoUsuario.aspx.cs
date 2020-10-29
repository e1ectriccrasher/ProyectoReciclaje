using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ProyectoReciclaje
{
    public partial class CambiarInfoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["telefono"] == null || Session["nombre"] == null)
            {

                Session.Clear();
                Session.Abandon();
                Response.Redirect("Logins.aspx");
            }

            if (Label1.Text == "")
            {
                String query = "select telefono, nombre, direccion, contrasena, tarjetaCredito from Usuario where telefono = ?";

                OdbcConnection con = new ConexionBD().conexion;

                OdbcCommand comando = new OdbcCommand(query, con);
                
                comando.Parameters.AddWithValue("telefono", Session["telefono"].ToString());

                OdbcDataReader lector = comando.ExecuteReader();
                if (lector.Read() == true)
                {
                    String nombre = lector.GetString(1);
                    String direccion = lector.GetString(2);
                    String pwd = lector.GetString(3);
                    String tarjeta = lector.GetString(4);

                    Label1.Text = Session["telefono"].ToString();
                    TextBox4.Text = nombre;
                    TextBox5.Text = direccion;
                    TextBox6.Text = tarjeta;

                    Session["pwd"] = pwd;
                }

                con.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HacerPedido.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String query = "update Usuario set contrasena = ?, nombre = ?, direccion = ?, tarjetaCredito = ? where telefono = ?";

            ConexionBD objetoConexion = new ConexionBD();
            OdbcConnection con = objetoConexion.conexion;

            OdbcCommand comando = new OdbcCommand(query, con);

            if (TextBox2.Text == TextBox3.Text && TextBox1.Text == Session["pwd"].ToString())
            {
                comando.Parameters.AddWithValue("passwd", TextBox2.Text);
                Label2.Text = "Las contraseñas coinciden";
            }
            else
            {
                Label2.Text = "Las contraseñas no coinciden";
                comando.Parameters.AddWithValue("passwd", Session["pwd"].ToString());
            }


            comando.Parameters.AddWithValue("nombre", TextBox4.Text);
            comando.Parameters.AddWithValue("direccion", TextBox5.Text);
            comando.Parameters.AddWithValue("tarjeta", TextBox6.Text);
            comando.Parameters.AddWithValue("telefono", Session["telefono"].ToString());

            comando.ExecuteNonQuery();

            con.Close();
        }
    }
}