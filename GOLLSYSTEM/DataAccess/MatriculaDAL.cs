using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class MatriculaDAL
    {
        public static Matricula getMatriculaById(Int64 pId)
        {
            Matricula item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from matricula where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Matricula(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetInt32(3),
                            _reader.GetInt32(4),
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
        public static int countMatriculasByCurso(Int64 pId)
        {
            int item = 0;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdBuscarPersona = new MySqlCommand("select count(Id) as MatriculasCount from matricula where IdCurso=@pId", _con);
                    cmdBuscarPersona.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdBuscarPersona.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = _reader.GetInt32("MatriculasCount");

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
