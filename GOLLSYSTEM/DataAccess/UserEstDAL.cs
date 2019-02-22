using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class UserEstDAL
    {
        public Userest getUserestById(int pId)
        {
            Userest item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from userest where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Userest(
                           _reader.GetInt64(0),
                           _reader.GetString(1),
                           _reader.GetString(2),
                           _reader.GetString(3),
                           _reader.GetString(4),
                           _reader.GetInt64(5),
                           _reader.GetInt64(6),
                           EstudianteDAL.getEstudianteById(_reader.GetInt64(6))
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

    }
}
