using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class EvaluacionDAL
    {
        public static Evaluacion getEvaluacionById(Int64 pId)
        {
            Evaluacion item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from evaluacion where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Evaluacion(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetString(4),
                            _reader.GetInt64(5),
                            CalificacionDAL.getCalificacionesByEvaluacion(_reader.GetInt64(0))
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
        public static List<Evaluacion> getEvaluacionByIdDetCurso(Int64 pIdDetCurso)
        {
            List<Evaluacion> lista = new List<Evaluacion>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from evaluacion where IdDetCurso=@pIdDetCurso order by Id asc", _con);
                    comando.Parameters.AddWithValue("@pIdDetCurso", pIdDetCurso);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Evaluacion item = new Evaluacion(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetString(4),
                            _reader.GetInt64(5),
                            CalificacionDAL.getCalificacionesByEvaluacion(_reader.GetInt64(0))
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
