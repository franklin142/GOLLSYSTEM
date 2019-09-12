using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class AcsSucursalDAL
    {
        public static AcsSucursal getAcsSucursalById(Int64 pId)
        {
            AcsSucursal item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from acssucursal where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new AcsSucursal(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetInt32(2),
                            _reader.GetInt32(3),
                            _reader.GetInt64(4),
                            RolDAL.getRolById(_reader.GetInt32(3)),
                            SucursalDAL.getSucursaloById(_reader.GetInt64(4)),
                            LstPermisoDAL.getLstPermisosByIdAcs(_reader.GetInt64(0))
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
        public static List<AcsSucursal> getAcsSucursalesByIdUser(Int64 pId)
        {
            List<AcsSucursal> lista = new List<AcsSucursal>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from acssucursal where IdUserEmp=@pId order by Id asc", _con);
                    comando.Parameters.AddWithValue("@pId", pId);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        AcsSucursal item = new AcsSucursal(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetInt32(2),
                            _reader.GetInt32(3),
                            _reader.GetInt64(4),
                            RolDAL.getRolById(_reader.GetInt32(3)),
                            SucursalDAL.getSucursaloById(_reader.GetInt64(4)),
                            LstPermisoDAL.getLstPermisosByIdAcs(_reader.GetInt64(0))
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

    }
}
