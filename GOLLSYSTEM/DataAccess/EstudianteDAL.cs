using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class EstudianteDAL
    {
        public static Estudiante getEstudianteById(Int64 pId)
        {
            Estudiante item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from estudiante where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Estudiante(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetString(4),
                             _reader.GetString(5),
                            _reader.GetString(6),
                            _reader.GetString(7),
                            _reader.GetString(8), 
                            _reader.GetInt64(9),
                            PersonaDAL.getPersonaById(_reader.GetInt64(9))
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
        public static Estudiante getEstudent(string pNombre)
        {
            Estudiante item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select e.* from persona as p inner join estudiante as e on e.IdPersona=p.Id where Upper(Nombre)=Upper(@pNombre)", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pNombre", pNombre);

                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Estudiante(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetString(4),
                             _reader.GetString(5),
                            _reader.GetString(6),
                            _reader.GetString(7),
                            _reader.GetString(8),
                            _reader.GetInt64(9),
                            PersonaDAL.getPersonaById(_reader.GetInt64(9))
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
