using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class LstPermisoRolDAL
    {
        public static LstPermisoRol getLstPermisoRolById(Int64 pId)
        {
            LstPermisoRol item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from lstpermisoRol where Id=@pId", _con);
                    cmd.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmd.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new LstPermisoRol(
                            _reader.GetInt32(0),
                            _reader.GetString(1),
                            _reader.GetInt32(2),
                            _reader.GetInt32(3),
                            PermisoDAL.getPermisoById(_reader.GetInt32(3))
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
        public static List<LstPermiso> getLstPermisosByIdRol(Int64 pId)
        {
            List<LstPermiso> lista = new List<LstPermiso>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select Id from lstpermisoRol where IdRol=@pId order by Id asc", _con);
                    comando.Parameters.AddWithValue("@pId", pId);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        LstPermiso item = new LstPermiso(
                             _reader.GetInt64(0),
                             _reader.GetString(1),
                             true,
                             _reader.GetInt32(3),
                             0,
                             PermisoDAL.getPermisoById(_reader.GetInt32(3))
                             );

                        lista.Add(item);

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
            return lista;
        }

    }
}
