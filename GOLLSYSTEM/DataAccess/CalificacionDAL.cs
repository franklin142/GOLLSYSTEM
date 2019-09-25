using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class CalificacionDAL
    {
        public static Calificacion getCalificacionById(Int64 pId)
        {
            Calificacion item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdBuscarPersona = new MySqlCommand("select * from calificacion where Id=@pId", _con);
                    cmdBuscarPersona.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdBuscarPersona.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Calificacion(_reader.GetInt32(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetInt64(3),
                            _reader.GetInt64(4)
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
        public static List<Calificacion> getCalificaciones(int pLimit)
        {
            List<Calificacion> lista = new List<Calificacion>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from calificacion order by Id desc limit @pLimit", _con);
                    comando.Parameters.AddWithValue("@pLimit", pLimit);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Calificacion item = new Calificacion(
                            _reader.GetInt32(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetInt64(3),
                            _reader.GetInt64(4)
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
        public static List<Calificacion> getCalificacionesByEvaluacion(Int64 pIdEvaluacion)
        {
            List<Calificacion> lista = new List<Calificacion>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from calificacion where IdEvaluacion =@pIdEvaluacion order by Id asc limit @pLimit", _con);
                    comando.Parameters.AddWithValue("@pIdEvaluacion", pIdEvaluacion);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Calificacion item = new Calificacion(
                            _reader.GetInt32(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetInt64(3),
                            _reader.GetInt64(4)
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
