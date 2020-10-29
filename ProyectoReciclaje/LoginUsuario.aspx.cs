using System;
using System.Data.Odbc;

namespace ProyectoReciclaje
{
    public partial class LoginUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String tel = TextBox1.Text;
            String c = TextBox2.Text;

            //Crear conexion
            OdbcConnection con = new ConexionBD().conexion;

            //Iniciar busqueda
            String query = "select nombre from usuario where telefono = ? and contrasena = ?";

            //Pasar parametros
            OdbcCommand comando = new OdbcCommand(query, con);
            comando.Parameters.AddWithValue("telefono", tel);
            comando.Parameters.AddWithValue("contraseña", c);

            //Checar si se encontro en la tabla el usuario
            OdbcDataReader lector = comando.ExecuteReader();
            if (lector.HasRows == true)
            {
                Label1.Text = "Credenciales correctas";

                lector.Read();
                String s = lector.GetString(0);

                Session["telefono"] = tel;
                Session["nombre"] = s;

                Session.Timeout = 10; //En 10 minutos de inactividad cierra la sesion

                Response.Redirect("HacerPedido.aspx"); 

            }
            else
            {
                Label1.Text = "Credenciales incorrectas";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoUsuario.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logins.aspx");
        }
    }
}