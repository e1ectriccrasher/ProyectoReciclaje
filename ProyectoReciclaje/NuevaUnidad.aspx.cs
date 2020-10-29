using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ProyectoReciclaje
{
    public partial class NuevaUnidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["correo"] == null || Session["nombre"] == null)
            {

                Session.Clear();
                Session.Abandon();
                Response.Redirect("Logins.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String placa = TextBox1.Text;
            String nomRec = TextBox2.Text;
            String tel = TextBox3.Text;
            String pwd = TextBox6.Text;
            String confirmacion = TextBox7.Text;
            String saldo = TextBox8.Text;

            if (pwd == confirmacion)
            {

                String query = "insert into Unidad values(?, ?, ?, ?, ?)";
                try
                {
                    ConexionBD objetoConexion = new ConexionBD();
                    OdbcConnection con = objetoConexion.conexion;

                    OdbcCommand comando = new OdbcCommand(query, con);

                    comando.Parameters.AddWithValue("placa", placa);
                    comando.Parameters.AddWithValue("nombreRecolector", nomRec);
                    comando.Parameters.AddWithValue("contraseña", pwd);
                    comando.Parameters.AddWithValue("saldo", Int32.Parse(saldo));
                    comando.Parameters.AddWithValue("telefono", tel);

                    comando.ExecuteNonQuery();

                    Label1.Text = "Alta exitosa";

                    con.Close();

                }
                catch (Exception ex)
                {
                    Label1.Text = ex.ToString();
                }
            }
            else
            {
                Label1.Text = "Las contraseñas no coinciden";
                TextBox2.Text = "";
                TextBox3.Text = "";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }
    }
}