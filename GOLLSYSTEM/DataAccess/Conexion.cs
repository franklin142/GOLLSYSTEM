using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class Conexion
    {
        public MySqlConnection Conectar()
        {
            string cadenaConexion = "server=" + Properties.Settings.Default.DBIp +
                ";port=" + Properties.Settings.Default.DBPort +
                ";user id=" + Properties.Settings.Default.DBUser +
                ";password=" + Properties.Settings.Default.DBPassword +
                ";database=" + Properties.Settings.Default.DBName;
            MySqlConnection con = new MySqlConnection(cadenaConexion);
            return con;
        }
    }
}
