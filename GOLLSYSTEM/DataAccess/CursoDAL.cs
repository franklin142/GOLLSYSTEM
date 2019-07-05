using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class CursoDAL
    {
        public static Curso getCursoById(Int64 pId)
        {
            Curso item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from curso where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Curso(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetString(4),
                            _reader.GetString(5),
                            _reader.GetString(6),
                            _reader.GetString(7),
                            _reader.GetInt64(8),
                            _reader.GetInt64(9),
                            _reader.GetInt64(10),
                            ContratoDAL.getContratoById(_reader.GetInt64(8)),
                            YearDAL.getYearById(_reader.GetInt64(10)),
                            DiasDAL.getDiasByIdCurso(_reader.GetInt64(0)),
                            DetCursoDAL.getDetscursoByIdCurso(_reader.GetInt64(0))
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
        public static bool existeCurso(Curso pCurso)
        {
            bool item = false;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from curso where Upper(Nombre) like'%"+pCurso.Nombre.ToUpper().Trim()+
                        "%' and IdYear=@IdYear", _con);
                    cmdGetItemById.Parameters.AddWithValue("@IdYear", pCurso.IdYear);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = true;

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

        public static List<Curso> getCursosByIdSucursal(Int64 pIdSucursal, Year pYear)
        {
            List<Curso> lista = new List<Curso>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from curso where IdSucursal=@pIdSucursal " + (pYear == null ? "" : " and IdYear=" + pYear.Id) + " and Estado='A' order by Id desc", _con);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Curso item = new Curso(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetString(4),
                            _reader.GetString(5),
                            _reader.GetString(6),
                            _reader.GetString(7),
                            _reader.GetInt64(8),
                            _reader.GetInt64(9),
                            _reader.GetInt64(10),
                            ContratoDAL.getContratoById(_reader.GetInt64(8)),
                            YearDAL.getYearById(_reader.GetInt64(10)),
                            DiasDAL.getDiasByIdCurso(_reader.GetInt64(0)),
                            DetCursoDAL.getDetscursoByIdCurso(_reader.GetInt64(0))
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
        public static List<Curso> getCursosEliminados(Int64 pIdSucursal, Year pYear)
        {
            List<Curso> lista = new List<Curso>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from curso where IdSucursal=@pIdSucursal " + (pYear == null ? "" : " and IdYear=" + pYear.Id) + " and Estado='I' order by Id desc", _con);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Curso item = new Curso(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetString(4),
                            _reader.GetString(5),
                            _reader.GetString(6),
                            _reader.GetString(7),
                            _reader.GetInt64(8),
                            _reader.GetInt64(9),
                            _reader.GetInt64(10),
                            ContratoDAL.getContratoById(_reader.GetInt64(8)),
                            YearDAL.getYearById(_reader.GetInt64(10)),
                            DiasDAL.getDiasByIdCurso(_reader.GetInt64(0)),
                            DetCursoDAL.getDetscursoByIdCurso(_reader.GetInt64(0))
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

        public static List<Curso> searchCursos(Int64 pIdSucursal,string pText, Year pYear)
        {
            List<Curso> lista = new List<Curso>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from curso where IdSucursal=@pIdSucursal " + (pYear == null ? "" : " and IdYear=" + pYear.Id) + 
                        " and Upper(Nombre) like'%"+pText.ToUpper()+"%' and Estado ='A' order by Id desc", _con);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Curso item = new Curso(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetString(4),
                            _reader.GetString(5),
                            _reader.GetString(6),
                            _reader.GetString(7),
                            _reader.GetInt64(8),
                            _reader.GetInt64(9),
                            _reader.GetInt64(10),
                            ContratoDAL.getContratoById(_reader.GetInt64(8)),
                            YearDAL.getYearById(_reader.GetInt64(10)),
                            DiasDAL.getDiasByIdCurso(_reader.GetInt64(0)),
                            DetCursoDAL.getDetscursoByIdCurso(_reader.GetInt64(0))
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

        public static bool insertCurso(Curso item, Useremp pUser)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {
                    MySqlCommand cmdInsertCurso = new MySqlCommand("Insert into curso (Nombre,Seccion,Publico,Desde,Hasta,Estado,IdContrato,IdSucursal,IdYear) values (@Nombre,@Seccion,@Publico,@Desde,@Hasta,@Estado,@IdContrato,@IdSucursal,@IdYear)", _con, _trans);
                    cmdInsertCurso.Parameters.AddWithValue("@Nombre", item.Nombre);
                    cmdInsertCurso.Parameters.AddWithValue("@Seccion", item.Seccion);
                    cmdInsertCurso.Parameters.AddWithValue("@Publico", item.Publico);
                    cmdInsertCurso.Parameters.AddWithValue("@Desde", item.Desde);
                    cmdInsertCurso.Parameters.AddWithValue("@Hasta", item.Hasta);
                    cmdInsertCurso.Parameters.AddWithValue("@Estado", item.Estado);
                    cmdInsertCurso.Parameters.AddWithValue("@IdContrato", item.Contrato.Id);
                    cmdInsertCurso.Parameters.AddWithValue("@IdSucursal", item.IdSucursal);
                    cmdInsertCurso.Parameters.AddWithValue("@IdYear", item.IdYear);

                    if (cmdInsertCurso.ExecuteNonQuery() <= 0)
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
                        foreach (Dia dia in item.Horario)
                        {
                            MySqlCommand cmdInsertDia = new MySqlCommand("Insert into dias (Nombre,HEntrada,HSalida,IdCurso) values (@Nombre,@HEntrada,@HSalida,@IdCurso)", _con, _trans);
                            cmdInsertDia.Parameters.AddWithValue("@Nombre", dia.Nombre);
                            cmdInsertDia.Parameters.AddWithValue("@HEntrada", dia.HEntrada);
                            cmdInsertDia.Parameters.AddWithValue("@HSalida", dia.HSalida);
                            cmdInsertDia.Parameters.AddWithValue("@IdCurso", item.Id);

                            if (cmdInsertDia.ExecuteNonQuery() <= 0)
                            {
                                result = false;
                            }
                        }
                    }
                    if (result)
                    {
                        foreach (Detcurso detcurso in item.Libros)
                        {
                            MySqlCommand cmdInsertDia = new MySqlCommand("Insert into detcurso (IdLibro,IdCurso) values (@IdLibro,@IdCurso)", _con, _trans);
                            cmdInsertDia.Parameters.AddWithValue("@IdLibro", detcurso.IdLibro);
                            cmdInsertDia.Parameters.AddWithValue("@IdCurso", item.Id);

                            if (cmdInsertDia.ExecuteNonQuery() <= 0)
                            {
                                result = false;
                            }
                            else
                            {
                                MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                                cmdUltimoId.Transaction = _trans;
                                detcurso.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                                
                                    for (int i = 0; i < detcurso.Libro.NActividades;i++)
                                    {
                                    MySqlCommand cmdInsertActividad = new MySqlCommand("Insert into evaluacion (Nombre,Tipo,Porcentaje,IdDetCurso) values (@Nombre,@Tipo,@Porcentaje,@IdDetCurso)", _con, _trans);
                                    cmdInsertActividad.Parameters.AddWithValue("@Nombre", 1+i== detcurso.Libro.NActividades?"Examen Final": "Evaluación "+(1+i));
                                    cmdInsertActividad.Parameters.AddWithValue("@Tipo", 1 + i == detcurso.Libro.NActividades ? "Examen Final" : "Evaluación ");
                                    cmdInsertActividad.Parameters.AddWithValue("@Porcentaje", ((decimal)100/ (decimal)detcurso.Libro.NActividades).ToString());
                                    cmdInsertActividad.Parameters.AddWithValue("@IdDetCurso", detcurso.Id);

                                    if (cmdInsertActividad.ExecuteNonQuery() <= 0)
                                    {
                                        result = false;
                                    }
                                }
                                
                            }
                        }
                    }
                    
                    if (result)
                    {
                        MySqlCommand cmdInsertAuditoria = new MySqlCommand("Insert into regemphist (Detalle,Accion,TipoRegistro,IdUserEmp) values (@Detalle,@Accion,@TipoRegistro,@IdUserEmp)", _con, _trans);
                        cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Registro el curso \""+item.Nombre+"\" con un total de "+item.Libros+" libros y selecciono a \""+item.Contrato.Empleado.Persona.Nombre+"\" como encargado.");
                        cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Registrar");
                        cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Curso");
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
        public static bool updateCurso(Curso item, Useremp pUser)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {
                    MySqlCommand cmdUpdateCurso = new MySqlCommand("Update curso set Nombre=@Nombre, Seccion=@Seccion, Publico=@Publico, Desde=@Desde, Hasta=@Hasta, Estado=@Estado, IdContrato=@IdContrato where Id=@Id;", _con, _trans);
                    cmdUpdateCurso.Parameters.AddWithValue("@Id", item.Id);

                    cmdUpdateCurso.Parameters.AddWithValue("@Nombre", item.Nombre);
                    cmdUpdateCurso.Parameters.AddWithValue("@Seccion", item.Seccion);
                    cmdUpdateCurso.Parameters.AddWithValue("@Publico", item.Publico);
                    cmdUpdateCurso.Parameters.AddWithValue("@Desde", item.Desde);
                    cmdUpdateCurso.Parameters.AddWithValue("@Hasta", item.Hasta);
                    cmdUpdateCurso.Parameters.AddWithValue("@Estado", item.Estado);
                    cmdUpdateCurso.Parameters.AddWithValue("@IdContrato", item.Contrato.Id);

                    if (cmdUpdateCurso.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }

                    if (result)
                    {
                        foreach (Dia dia in DiasDAL.getDiasByIdCurso(item.Id))
                        {
                            if (item.Horario.Where(a=>a.Id==dia.Id).FirstOrDefault()==null)
                            {
                                MySqlCommand cmdDeleteDia = new MySqlCommand("Delete from dias where Id=@Id", _con, _trans);
                                cmdDeleteDia.Parameters.AddWithValue("@Id", dia.Id);

                                if (cmdDeleteDia.ExecuteNonQuery() <= 0)
                                {
                                    result = false;
                                }
                            }
                            
                        }
                        foreach (Dia dia in item.Horario.Where(a=>a.Id==0).ToList())
                        {
                            MySqlCommand cmdInsertDia = new MySqlCommand("Insert into dias (Nombre,HEntrada,HSalida,IdCurso) values (@Nombre,@HEntrada,@HSalida,@IdCurso)", _con, _trans);
                            cmdInsertDia.Parameters.AddWithValue("@Nombre", dia.Nombre);
                            cmdInsertDia.Parameters.AddWithValue("@HEntrada", dia.HEntrada);
                            cmdInsertDia.Parameters.AddWithValue("@HSalida", dia.HSalida);
                            cmdInsertDia.Parameters.AddWithValue("@IdCurso", item.Id);

                            if (cmdInsertDia.ExecuteNonQuery() <= 0)
                            {
                                result = false;
                            }
                        }
                    }

                    if (result)
                    {
                        foreach (Detcurso detcurso in DetCursoDAL.getDetscursoByIdCurso(item.Id))
                        {
                            if (item.Libros.Where(a => a.Id == detcurso.Id).FirstOrDefault() == null)
                            {
                                MySqlCommand cmdDeleteDetCurso = new MySqlCommand("update detcurso set Estado='E' where Id=@Id", _con, _trans);
                                cmdDeleteDetCurso.Parameters.AddWithValue("@Id", detcurso.Id);

                                if (cmdDeleteDetCurso.ExecuteNonQuery() <= 0)
                                {
                                    result = false;
                                }
                            }
                        }
                        foreach (Detcurso detcurso in item.Libros.Where(a=>a.Id==0).ToList())
                        {
                            MySqlCommand cmdInsertDia = new MySqlCommand("Insert into detcurso (IdLibro,IdCurso) values (@IdLibro,@IdCurso)", _con, _trans);
                            cmdInsertDia.Parameters.AddWithValue("@IdLibro", detcurso.IdLibro);
                            cmdInsertDia.Parameters.AddWithValue("@IdCurso", item.Id);

                            if (cmdInsertDia.ExecuteNonQuery() <= 0)
                            {
                                result = false;
                            }
                        }
                    }
                    if (result)
                    {
                        MySqlCommand cmdInsertAuditoria = new MySqlCommand("Insert into regemphist (Detalle,Accion,TipoRegistro,IdUserEmp) values (@Detalle,@Accion,@TipoRegistro,@IdUserEmp)", _con, _trans);
                        cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Registro el curso \"" + item.Nombre + "\" con un total de " + item.Libros + " libros y selecciono a \"" + item.Contrato.Empleado.Persona.Nombre + "\" como encargado.");
                        cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Registrar");
                        cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Curso");
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
        public static bool inhabilitarCurso(Curso item, Useremp pUser)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {
                    MySqlCommand cmdUpdateCurso = new MySqlCommand("Update curso set Estado='I' where Id=@Id;", _con, _trans);
                    cmdUpdateCurso.Parameters.AddWithValue("@Id", item.Id);


                    if (cmdUpdateCurso.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    if (result)
                    {
                        MySqlCommand cmdInsertAuditoria = new MySqlCommand("Insert into regemphist (Detalle,Accion,TipoRegistro,IdUserEmp) values (@Detalle,@Accion,@TipoRegistro,@IdUserEmp)", _con, _trans);
                        cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Inhabilito el curso \"" + item.Nombre + "\" con un total de " + item.Libros + " libros con \"" + item.Contrato.Empleado.Persona.Nombre + "\" como encargado.");
                        cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Inhabilitar");
                        cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Curso");
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
        public static bool habilitarCurso(Curso item, Useremp pUser)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {
                    MySqlCommand cmdUpdateCurso = new MySqlCommand("Update curso set Estado='A' where Id=@Id;", _con, _trans);
                    cmdUpdateCurso.Parameters.AddWithValue("@Id", item.Id);


                    if (cmdUpdateCurso.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    if (result)
                    {
                        MySqlCommand cmdInsertAuditoria = new MySqlCommand("Insert into regemphist (Detalle,Accion,TipoRegistro,IdUserEmp) values (@Detalle,@Accion,@TipoRegistro,@IdUserEmp)", _con, _trans);
                        cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "habilito el curso \"" + item.Nombre + "\" con un total de " + item.Libros + " libros con \"" + item.Contrato.Empleado.Persona.Nombre + "\" como encargado.");
                        cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "habilitar");
                        cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Curso");
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
