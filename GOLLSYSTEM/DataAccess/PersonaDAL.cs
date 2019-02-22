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
                            _reader.GetString("FechaNac")
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
