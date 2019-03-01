using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class CuotaDAL
    {
        public static Cuota getCuotaById(Int64 pId)
        {
            Cuota item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from cuota where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Cuota(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetDecimal(2),
                            _reader.GetDecimal(3),
                            _reader.GetInt64(4)
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
        public static List<Cuota> getCuotasByIdMatricula(Int64 pIdMatricula, int pLimit)
        {
            List<Cuota> lista = new List<Cuota>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from cuota where IdMatricula=@pIdMatricula order by Id desc limit @pLimit", _con);
                    comando.Parameters.AddWithValue("@pIdMatricula", pIdMatricula);
                    comando.Parameters.AddWithValue("@pLimit", pLimit);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Cuota item = new Cuota(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetDecimal(2),
                            _reader.GetDecimal(3),
                            _reader.GetInt64(4)
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
