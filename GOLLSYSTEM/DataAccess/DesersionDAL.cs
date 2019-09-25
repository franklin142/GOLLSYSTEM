using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class DesersionDAL
    {
        public static Desersion getDesersionById(Int64 pId)
        {
            Desersion item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from desersion where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Desersion(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetInt64(3)
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
        public static bool insertDesersion(Desersion item, Useremp pUser)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {
                    MySqlCommand cmdInsertDesersion = new MySqlCommand("Insert into desersion (FhRegistro, Nota, IdMatricula) values (@FhRegistro, @Nota, @IdMatricula)", _con, _trans);
                    cmdInsertDesersion.Parameters.AddWithValue("@FhRegistro", item.FhRegistro);
                    cmdInsertDesersion.Parameters.AddWithValue("@Nota", item.Nota);
                    cmdInsertDesersion.Parameters.AddWithValue("@IdMatricula", item.IdMatricula);

                    if (cmdInsertDesersion.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    else
                    {
                        MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                        cmdUltimoId.Transaction = _trans;
                        item.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                    }
                    MySqlCommand cmdUpdateMatricula= new MySqlCommand("Update matricula set Estado='D' where Id=@Id", _con, _trans);
                    cmdUpdateMatricula.Parameters.AddWithValue("@Id", item.IdMatricula);

                    if (cmdUpdateMatricula.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    if (result)
                    {
                        _trans.Commit();
                    }
                    else
                    {
                        _trans.Rollback();
                    }

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
            return result;
        }

    }
}
