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
        public static bool testConexion()
        {
            bool result = true;
            try
            {
                using (MySql.Data.MySqlClient.MySqlConnection _conn = new Conexion().Conectar())
                {
                    _conn.Open();
                    _conn.Close();
                }
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;
        }
        public static bool checkDB(string pConexion)
        {
            bool result = true;
            try
            {
                using (MySqlConnection _conn = new MySqlConnection(pConexion))
                {
                    _conn.Open();

                    _conn.Close();
                }
            }
            catch (Exception)
            {
                result = false;

            }
            return result;
        }
        public static bool MakeBackup(string pRuta)
        {
            bool result = true;
            try
            {
                using (MySqlConnection _con = new Conexion().Conectar())
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = _con;
                            _con.Open();
                            mb.ExportToFile(pRuta);
                            _con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;

            }
            finally
            {

            }
            return result;

        }
        public static bool RestoreBackup(string pRuta)
        {
            bool result = true;
            try
            {
                using (MySqlConnection _con = new Conexion().Conectar())
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = _con;
                            _con.Open();
                            mb.ImportFromFile(pRuta);
                            _con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;

            }
            finally
            {

            }
            return result;

        }

    }
}
