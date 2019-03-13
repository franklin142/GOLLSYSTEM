using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class EgresoDAL
    {
        public static Egreso getEgresoById(Int64 pId)
        {
            Egreso item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from egreso where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Egreso(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetDecimal(4),
                            _reader.GetString(5),
                            _reader.GetInt64(6)
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
        public static List<Egreso> searchEgresoByParametro(Int64 pYear,string pMonth, string pText, Int64 pIdSucursal, int pLimit)
        {
            List<Egreso> lista = new List<Egreso>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from egreso where Nombre like '%"+pText+ "%' and (YEAR(FhRegistro)=@pYear and MONTH(FhRegistro)=@pMonth and IdSucursal=@pIdSucursal) order by Id asc", _con);
                    comando.Parameters.AddWithValue("@pYear", pYear);
                    comando.Parameters.AddWithValue("@pMonth", pMonth);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);

                    comando.Parameters.AddWithValue("@pLimit", pLimit);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Egreso item = new Egreso(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetDecimal(4),
                            _reader.GetString(5),
                            _reader.GetInt64(6)
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
        public static List<Egreso> searchEgresoNoParametro(string pText,Int64 pIdSucursal, int pLimit)
        {
            List<Egreso> lista = new List<Egreso>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from egreso where Nombre like '%" + pText + "%' and IdSucursal=@pIdSucursal order by Id asc", _con);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);
                    comando.Parameters.AddWithValue("@pLimit", pLimit);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Egreso item = new Egreso(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetDecimal(4),
                            _reader.GetString(5),
                            _reader.GetInt64(6)
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
        public static decimal getTotalEgresoNoParametro(string pText, Int64 pIdSucursal, int pLimit)
        {
            decimal item = 0;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select sum(Total) from egreso where Nombre like '%" + pText + "%' and (IdSucursal=@pIdSucursal) order by Id asc", _con);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = _reader.IsDBNull(0) ? 0 : _reader.GetDecimal(0);
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
        public static decimal getTotalEgresoByParametro(Int64 pYear, string pMonth, string pText, Int64 pIdSucursal, int pLimit)
        {
            decimal item = 0;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select sum(Total) from egreso where Nombre like '%" + pText + "%' and (YEAR(FhRegistro)=@pYear and MONTH(FhRegistro)=@pMonth and IdSucursal=@pIdSucursal) order by Id asc", _con);
                    comando.Parameters.AddWithValue("@pYear", pYear);
                    comando.Parameters.AddWithValue("@pMonth", pMonth);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);

                    comando.Parameters.AddWithValue("@pLimit", pLimit);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = _reader.IsDBNull(0) ? 0 : _reader.GetDecimal(0);

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

    }
}
