using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class PersonaDAL
    {
        public static Persona getPersonaById(Int64 pId)
        {
            Persona item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdBuscarPersona = new MySqlCommand("select * from persona where Id=@pId", _con);
                    cmdBuscarPersona.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdBuscarPersona.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Persona(
                            _reader.GetInt64("Id"),
                            _reader.GetString("Nombre"),
                            _reader.GetString("Dui"),
                            _reader.GetString("Nit"),
                            _reader.GetString("Direccion"),
                            (_reader.IsDBNull(4)) ? null : _reader.GetString("FechaNac")
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
        public static List<Persona> searchPersonaNoParametro(string pText, int pLimit)
        {
            List<Persona> lista = new List<Persona>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from persona where Upper(Nombre) like '%" + pText.ToUpper() + "%' order by Id asc", _con);
                    comando.Parameters.AddWithValue("@pLimit", pLimit);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Persona item = new Persona(
                            _reader.GetInt64("Id"),
                            _reader.GetString("Nombre"),
                            _reader.GetString("Dui"),
                            _reader.GetString("Nit"),
                            _reader.GetString("Direccion"),
                            (_reader.IsDBNull(4)) ? null : _reader.GetString("FechaNac"));

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
        public static bool insertPersona(Persona item, Useremp pUser)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {

                    MySqlCommand cmdInsertPersona = new MySqlCommand("Insert into persona (Nombre,Dui,Nit,FechaNac,Direccion) values (@Nombre,@Dui,@Nit,@FechaNac,@Direccion)", _con, _trans);
                    cmdInsertPersona.Parameters.AddWithValue("@Nombre", item.Nombre);
                    cmdInsertPersona.Parameters.AddWithValue("@Dui", "");
                    cmdInsertPersona.Parameters.AddWithValue("@Nit","");
                    cmdInsertPersona.Parameters.AddWithValue("@FechaNac", DateTime.Today.ToString("yyyy/MM/dd"));
                    cmdInsertPersona.Parameters.AddWithValue("@Direccion", "");
                    if (cmdInsertPersona.ExecuteNonQuery() <= 0)
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
