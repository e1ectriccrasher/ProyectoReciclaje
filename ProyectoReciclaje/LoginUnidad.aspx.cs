using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ProyectoReciclaje
{
    public partial class LoginUnidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String pla = TextBox1.Text;
            String p = TextBox2.Text;

            OdbcConnection con = new ConexionBD().conexion;

            //Un comando ejecutar query

            String query = "select nombreRecolector from Unidad where placa = ? and contrasena = ?";
            OdbcCommand comando = new OdbcCommand(query, con);

            //Pasar los parametrps
            comando.Parameters.AddWithValue("placas", pla);
            comando.Parameters.AddWithValue("passwd", p);

            //Recibir una tabla
            OdbcDataReader lector = comando.ExecuteReader();
            if (lector.HasRows == true)
            {
                Label1.Text = "Credenciales correctas";

                lector.Read();
                String s = lector.GetString(0);

                Session["nombre"] = s;
                Session["placas"] = pla;

                Session.Timeout = 10; //En 10 minutos de inactividad cierra la sesion

                Response.Redirect("TomarPedido.aspx");

            }
            else
            {
                Label1.Text = "Credenciales incorrectas";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logins.aspx");
        }
    }
}