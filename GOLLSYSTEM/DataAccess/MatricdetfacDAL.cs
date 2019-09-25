using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    class MatricdetfacDAL
    {
        public static Matricdetfac getMatricdetfacById(Int64 pId)
        {
            Matricdetfac item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from matricdetfact where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Matricdetfac(
                            _reader.GetInt64(0),
                            _reader.GetInt64(1),
                            _reader.GetInt64(2)
                            );

                    }
                    _reader.Close();
                }
                catch (Exception ex)
                {
                    _con.Close();
                    throw ex;
                }
                finally
                {
                    _con.Close();
                }
            }
            return item;
        }
        public static Matricdetfac getMatricdetfacByIdCuota(Int64 pId)
        {
            Matricdetfac item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from matricdetfact where IdCuota=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Matricdetfac(
                            _reader.GetInt64(0),
                            _reader.GetInt64(1),
                            _reader.GetInt64(2)
                            );

                    }
                    _reader.Close();
                }
                catch (Exception ex)
                {
                    _con.Close();
                    throw ex;
                }
                finally
                {
                    _con.Close();
                }
            }
            return item;
        }

        public static Matricdetfac getMatricdetfacByIdDetFactura(Int64 pIdDetFactura)
        {
            Matricdetfac item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from matricdetfact where IdDetFactura=@pIdDetFactura", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pIdDetFactura", pIdDetFactura);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Matricdetfac(
                            _reader.GetInt64(0),
                            _reader.GetInt64(1),
                            _reader.GetInt64(2)
                            );

                    }
                    _reader.Close();
                }
                catch (Exception ex)
                {
                    _con.Close();
                    throw ex;
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
