using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ProyectoReciclaje
{
    public partial class CambiarInfoUnidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["placas"] == null || Session["nombre"] == null)
            {

                Session.Clear();
                Session.Abandon();
                Response.Redirect("Logins.aspx");
            }

            if (Label1.Text == "")
            {
                String query = "select placa, nombreRecolector, contrasena, telefono from Unidad where placa = ?";

                OdbcConnection con = new ConexionBD().conexion;

                OdbcCommand comando = new OdbcCommand(query, con);

                comando.Parameters.AddWithValue("placa", Session["placas"].ToString());

                OdbcDataReader lector = comando.ExecuteReader();
                if (lector.Read() == true)
                {
                    String nombre = lector.GetString(1);
                    String pwd = lector.GetString(2);
                    String telefono = lector.GetString(3);

                    Label1.Text = Session["placas"].ToString();
                    TextBox4.Text = nombre;
                    TextBox5.Text = telefono;


                    Session["pwd"] = pwd;
                }

                con.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("TomarPedido.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String query = "update Unidad set contrasena = ?, nombreRecolector = ?, telefono =? where placa = ?";

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
            comando.Parameters.AddWithValue("telefono", TextBox5.Text);
            comando.Parameters.AddWithValue("placa", Session["placas"].ToString());

            comando.ExecuteNonQuery();

            con.Close();
        }
    }
}