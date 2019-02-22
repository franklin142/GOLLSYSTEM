using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class SucursalDAL
    {
        public static Sucursal getSucursaloById(Int64 pId)
        {
            Sucursal item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from sucursal where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Sucursal(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            CursoDAL.getCursosByIdSucursal(_reader.GetInt64(0),null)
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
        public static bool InsertSucursalConf(Sucursal item)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {
                    MySqlCommand cmdInsertSucursal = new MySqlCommand("Insert into sucursal (Nombre,Direccion) values (@Nombre,@Direccion)", _con, _trans);
                    cmdInsertSucursal.Parameters.AddWithValue("@Nombre", item.Nombre);
                    cmdInsertSucursal.Parameters.AddWithValue("@Direccion", item.Direccion);

                    if (cmdInsertSucursal.ExecuteNonQuery() <= 0)
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
