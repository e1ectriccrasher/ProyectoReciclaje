using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ProyectoReciclaje
{
    public partial class CambiarInfoAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["correo"] == null || Session["nombre"] == null)
            {

                Session.Clear();
                Session.Abandon();
                Response.Redirect("Logins.aspx");
            }

            if (Label1.Text == "")
            {
                String query = "select correo, contrasena, nombre from Admin where correo = ?";

                OdbcConnection con = new ConexionBD().conexion;

                OdbcCommand comando = new OdbcCommand(query, con);

                comando.Parameters.AddWithValue("correo", Session["correo"].ToString());

                OdbcDataReader lector = comando.ExecuteReader();
                if (lector.Read() == true)
                {
                    String pwd = lector.GetString(1);
                    String nombre = lector.GetString(2);

                    Label1.Text = Session["correo"].ToString();
                    TextBox4.Text = nombre;


                    Session["pwd"] = pwd;
                }

                con.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String query = "update Admin set contrasena = ?, nombre = ? where correo = ?";

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
            comando.Parameters.AddWithValue("correo", Session["correo"].ToString());

            comando.ExecuteNonQuery();

            con.Close();
        }
    }
    
}