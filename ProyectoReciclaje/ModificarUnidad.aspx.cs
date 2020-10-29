using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace ProyectoReciclaje
{
    public partial class ModificarUnidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["correo"] == null || Session["nombre"] == null)
            {

                Session.Clear();
                Session.Abandon();
                Response.Redirect("Logins.aspx");
            }

            if (DropDownList1.Items.Count == 0)
            {
                String query = "select placa, nombreRecolector from Unidad";
                OdbcConnection con = new ConexionBD().conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                OdbcDataReader lector = comando.ExecuteReader();

                DropDownList1.DataSource = lector;
                DropDownList1.DataValueField = "placa";
                DropDownList1.DataTextField = "nombreRecolector";
                DropDownList1.DataBind();

                con.Close();

            }

         }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String query = "select saldo from Unidad where placa = ? ";

            OdbcConnection con = new ConexionBD().conexion;
            OdbcCommand comando = new OdbcCommand(query, con);

            comando.Parameters.AddWithValue("placa", DropDownList1.SelectedValue);
            OdbcDataReader lector = comando.ExecuteReader();

            if (lector.Read() == true)
            {
                int saldo = lector.GetInt32(0);
                Label1.Text = "El saldo anterior es: " + saldo;
            }

            
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "update Unidad set saldo = ? where placa = ? ";

                OdbcConnection con = new ConexionBD().conexion;
                OdbcCommand comando = new OdbcCommand(query, con);
                comando.Parameters.AddWithValue("saldo", TextBox1.Text);
                comando.Parameters.AddWithValue("placa", DropDownList1.SelectedValue);

                comando.ExecuteNonQuery();

                Label2.Text = "Cambio exitoso";
            }
            catch (Exception es)
            {
                Label2.Text = "No se hizo el cambio: " + es.ToString();
            }
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }
    }
}