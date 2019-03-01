using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class YearDAL
    {
        public static Year getYearById(Int64 pId)
        {
            Year item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from year where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Year(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2)
                            );

                    }
                    _reader.Close();
                }
                catch (Exception)
                {
                    _con.Close();
                    throw;
                }
                finally
                {
                    _con.Close();
                }
            }
            return item;
        }
        public static DateTime getServerDate()
        {
            DateTime item = DateTime.Now;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select Now() as currentServerDate", _con);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = _reader.GetDateTime(0);

                    }
                    _reader.Close();
                }
                catch (Exception)
                {
                    _con.Close();
                    throw;
                }
                finally
                {
                    _con.Close();
                }
            }
            return item;
        }

        public static List<Year> getYears(int pLimit)
        {
            List<Year> lista = new List<Year>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from year order by Id desc limit @pLimit", _con);
                    comando.Parameters.AddWithValue("@pLimit", pLimit);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Year item = new Year(
                            _reader.GetInt64(0),
                            _reader.GetDateTime(1).ToString("yyyy"),
                            _reader.GetString(2)
                            );

                        lista.Add(item);

                    }
                    _reader.Close();
                }
                catch (Exception)
                {
                    _con.Close();
                    throw;
                }
                finally
                {
                    _con.Close();
                }
            }
            return lista;
        }
        public static Year getCurrentYear()
        {
            Year item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                try
                {
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from year  where YEAR(Desde)= YEAR(now())", _con);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Year(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2)
                            );

                    }
                    if (item == null)
                    {
                        insertCurrentYear();
                        getCurrentYear();
                    }

                }
                catch (Exception)
                {
                    _con.Close();
                    throw;
                }
                finally
                {
                    _con.Close();
                }
            }
            return item;
        }
        public static bool insertCurrentYear()
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {
                    MySqlCommand cmdInsertYear = new MySqlCommand("Insert into year (Desde,Hasta) values (CONCAT(YEAR(now()),'-01-01'),CONCAT(YEAR(now()),'-12-31'))", _con, _trans);
                

                    if (cmdInsertYear.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    
                    if (result)
                    {
                        _trans.Commit();
                    }

                }
                catch (Exception)
                {
                    result = false;
                    _trans.Rollback();
                    _con.Close();
                    throw;
                }
                finally
                {
                    _con.Close();
                }
            }
            return result;
        }

    }
}
