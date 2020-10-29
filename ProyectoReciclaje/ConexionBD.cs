using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;

namespace ProyectoReciclaje
{
    public class ConexionBD
    {
     
        //Atributo
        public OdbcConnection conexion { get; set; }

        //Constructor
        public ConexionBD ()
        {
            //Extraer las caracteristicas de conexion del Web.config
            System.Configuration.Configuration webConfig;
            webConfig = System.Web.Configuration
                .WebConfigurationManager.OpenWebConfiguration("/ProyectoReciclaje");

            //Sacar el String de conexion
            System.Configuration.ConnectionStringSettings objetoStringDeConexion;
            objetoStringDeConexion = webConfig.ConnectionStrings.ConnectionStrings["BDProyReciclaje"];

            //Crear la nueva conexion
            conexion = new OdbcConnection(objetoStringDeConexion.ToString());

            //Abrir la conexion
            conexion.Open();
        }
    }
}