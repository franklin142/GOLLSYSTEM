using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class EncargadoDAL
    {
        public static Encargado getEncargadoById(Int64 pId)
        {
            Encargado item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from encargado where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Encargado(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetInt64(4),
                            PersonaDAL.getPersonaById(_reader.GetInt64(4))
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
        public static List<Encargado> searchEncargados(string Text,int pLimit)
        {
            List<Encargado> lista = new List<Encargado>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select distinct e.* from encargado as e inner join persona as p " +
                        "on p.Id=e.IdPersona where( Upper(p.Nombre) like '%" + Text.ToUpper() + "%' or Upper(e.Telefono) like '%" + Text.ToUpper() +
                        "%' or Upper(e.LugarTrabajo) like '%" + Text.ToUpper() + "%' or Upper(e.Trabajo)) like '%"+Text.ToUpper()+"%'" +
                        " order by e.Id asc limit @pLimit", _con);
                    comando.Parameters.AddWithValue("@pLimit", pLimit);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Encargado item = new Encargado(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetInt64(4),
                            PersonaDAL.getPersonaById(_reader.GetInt64(4))
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
