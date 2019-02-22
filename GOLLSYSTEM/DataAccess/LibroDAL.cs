using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class LibroDAL
    {
        public static Libro getLibroById(Int64 pId)
        {
            Libro item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from libro where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Libro(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                             _reader.GetString(3),
                            _reader.GetInt32(4),
                            _reader.GetInt32(5)
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
        public static List<Libro> getLibrosByIdCurso(Int64 pIdCurso)
        {
            List<Libro> lista = new List<Libro>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from libro where IdCurso=@pIdCurso order by Id asc", _con);
                    comando.Parameters.AddWithValue("@pIdCurso", pIdCurso);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Libro item = new Libro(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                             _reader.GetString(3),
                            _reader.GetInt32(4),
                            _reader.GetInt32(5)
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
        public static List<Libro> getLibros(int pLimit)
        {
            List<Libro> lista = new List<Libro>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from libro order by Id asc limit @pLimit", _con);
                    comando.Parameters.AddWithValue("@pLimit", pLimit);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Libro item = new Libro(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                             _reader.GetString(3),
                            _reader.GetInt32(4),
                            _reader.GetInt32(5)
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

        public static List<Libro> searchLibros(string pText,int pLimit)
        {
            List<Libro> lista = new List<Libro>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from libro where Upper(Nombre) like '%"+pText.ToUpper()+"%' order by Id asc limit @pLimit", _con);
                    comando.Parameters.AddWithValue("@pLimit", pLimit);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Libro item = new Libro(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                             _reader.GetString(3),
                            _reader.GetInt32(4),
                            _reader.GetInt32(5)
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
        public static bool InsertLibro(Libro item, Useremp pUser)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {
                    MySqlCommand cmdInsertContrato = new MySqlCommand("Insert into libro (Nombre,Edicion,NActividades,Nivel) values (@Nombre,@Edicion,@NActividades,@Nivel)", _con, _trans);
                    cmdInsertContrato.Parameters.AddWithValue("@Nombre", item.Nombre);
                    cmdInsertContrato.Parameters.AddWithValue("@Edicion", item.Edicion);
                    cmdInsertContrato.Parameters.AddWithValue("@NActividades", item.NActividades);
                    cmdInsertContrato.Parameters.AddWithValue("@Nivel", item.Nivel);

                    if (cmdInsertContrato.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    else
                    {
                        MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                        cmdUltimoId.Transaction = _trans;
                        item.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                    }

                    if (result)
                    {
                        MySqlCommand cmdInsertAuditoria = new MySqlCommand("Insert into regemphist (Detalle,Accion,TipoRegistro,IdUserEmp) values (@Detalle,@Accion,@TipoRegistro,@IdUserEmp)", _con, _trans);
                        cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Registro libro nuevo titulado \""+item.Nombre+"\" edicion \""+item.Edicion+"\" nivel \""+item.Nivel+"\".");
                        cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Registrar");
                        cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Libro");
                        cmdInsertAuditoria.Parameters.AddWithValue("@IdUserEmp", pUser.Id);
                        if (cmdInsertAuditoria.ExecuteNonQuery() <= 0)
                        {
                            result = false;
                        }
                    }
                    if (result)
                    {
                        _trans.Commit();
                    }
                }
                catch (Exception)
                {
                    result = false;
                    _trans.Rollback();
                    _con.Close();
                    throw;
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
