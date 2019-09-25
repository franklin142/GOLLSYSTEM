using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class DetCursoDAL
    {
        public static Detcurso getDetCursoById(Int64 pId)
        {
            Detcurso item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from detcurso where Id=@pId and Estado='A';", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Detcurso(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetInt64(3),
                            _reader.GetInt64(4),
                            LibroDAL.getLibroById(_reader.GetInt64(3))
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
        public static List<Detcurso> getDetscursoByIdCurso(Int64 pIdCurso)
        {
            List<Detcurso> lista = new List<Detcurso>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from detcurso where IdCurso=@pIdCurso and Estado='A' order by Id asc", _con);
                    comando.Parameters.AddWithValue("@pIdCurso", pIdCurso);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Detcurso item = new Detcurso(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetInt64(3),
                            _reader.GetInt64(4),
                            LibroDAL.getLibroById(_reader.GetInt64(3))
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
