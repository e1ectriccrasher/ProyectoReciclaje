using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ProyectoReciclaje
{
    public partial class NuevoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String tel = TextBox1.Text;
            String cor = TextBox2.Text;
            String nom = TextBox3.Text;
            String dir = TextBox4.Text;
            String tarjeta = TextBox5.Text;
            String pwd = TextBox6.Text;
            String confirmacion = TextBox7.Text;

            if (pwd == confirmacion)
            {
               
                String query = "insert into Usuario values(?, ?, ?, ?, ?)";
                try
                {
                    ConexionBD objetoConexion = new ConexionBD();
                    OdbcConnection con = objetoConexion.conexion;

                    OdbcCommand comando = new OdbcCommand(query, con);

                    comando.Parameters.AddWithValue("telefono", tel);
                    comando.Parameters.AddWithValue("nombre", nom);
                    comando.Parameters.AddWithValue("direccion", dir);
                    comando.Parameters.AddWithValue("contraseña", pwd);
                    comando.Parameters.AddWithValue("tarjeta", tarjeta);

                    comando.ExecuteNonQuery();

                    Label1.Text = "Se ha creado exitosamente";

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
            Response.Redirect("LoginUsuario.aspx");
        }
    }
}