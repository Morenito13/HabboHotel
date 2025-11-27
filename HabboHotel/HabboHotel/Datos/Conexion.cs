using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HabboHotel.Datos
{
    internal class Conexion
    {
        private string basedeDatos;
        private string servidor;
        private string puerto;
        private string usuario;
        private string password;
        private static Conexion conexion = null;

        public Conexion()
        {
            this.basedeDatos = "habbo_hotel";
            this.servidor = "127.0.0.1";
            this.puerto = "3306";
            this.usuario = "root";
            this.password = "";
        }

        public MySqlConnection crearConexion()
        {
            MySqlConnection conexion = new MySqlConnection();

            try
            {
                conexion.ConnectionString = "Database= " + basedeDatos + ";Data Source= " + servidor + "; User Id= " + usuario + " ;" +
                    "Password=" + password + ";";

            }
            catch (MySqlException error)
            {
                conexion = null;
                error = null;
            }
            return conexion;
        }

        public static Conexion GetConexion()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
            return conexion;
        }
    }
}