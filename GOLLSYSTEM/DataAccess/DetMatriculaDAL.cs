using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class DetMatriculaDAL
    {
        public static Detmatricula getDetmatriculaById(Int64 pId)
        {
            Detmatricula item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from detmatricula where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Detmatricula(
                            _reader.GetInt64(0),
                            _reader.GetInt64(1),
                            _reader.GetInt64(2),
                            EncargadoDAL.getEncargadoById(_reader.GetInt64(2))
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
        public static List<Detmatricula> getDetsmatriculaByIdMatricula(Int64 pIdMatricula, int pLimit)
        {
            List<Detmatricula> lista = new List<Detmatricula>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from detmatricula where IdMatricula=@pIdMatricula order by Id asc limit @pLimit", _con);
                    comando.Parameters.AddWithValue("@pLimit", pLimit);
                    comando.Parameters.AddWithValue("@pIdMatricula", pIdMatricula);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Detmatricula item = new Detmatricula(
                            _reader.GetInt64(0),
                            _reader.GetInt64(1),
                            _reader.GetInt64(2),
                            EncargadoDAL.getEncargadoById(_reader.GetInt64(2))
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
