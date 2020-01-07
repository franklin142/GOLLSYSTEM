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
                            _reader.GetString(4),
                            _reader.GetInt64(5),
                            _reader.GetInt64(6),
                            EstudianteDAL.getEstudianteById(_reader.GetInt64(6)),
                            CuotaDAL.getCuotasByIdMatricula(_reader.GetInt64(0), 50),
                            DetMatriculaDAL.getDetsmatriculaByIdMatricula(_reader.GetInt64(0), 2)
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
        public static Matricula verificarMatriculado(Int64 pIdCurso,Int64 IdEstudiante)
        {
            Matricula item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from matricula where IdCurso=@pIdCurso and IdEstudiante=@IdEstudiante", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pIdCurso", pIdCurso);
                    cmdGetItemById.Parameters.AddWithValue("@IdEstudiante", IdEstudiante);

                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Matricula(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetInt32(3),
                            _reader.GetString(4),
                            _reader.GetInt64(5),
                            _reader.GetInt64(6),
                            EstudianteDAL.getEstudianteById(_reader.GetInt64(6)),
                            CuotaDAL.getCuotasByIdMatricula(_reader.GetInt64(0), 50),
                            DetMatriculaDAL.getDetsmatriculaByIdMatricula(_reader.GetInt64(0), 2)
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
                    MySqlCommand cmdBuscarPersona = new MySqlCommand("select count(Id) as MatriculasCount from matricula where IdCurso=@pId and Estado='A'", _con);
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
        public static int countMatriculasActivasByCurso(Int64 pId)
        {
            int item = 0;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdBuscarPersona = new MySqlCommand("select count(m.Id) as MatriculasCount from matricula m inner join curso c on c.Id=m.IdCurso where m.IdCurso=@pId and m.Estado='A' and c.Hasta>=CURRENT_DATE;", _con);
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
        public static List<Matricula> searchMatriculasParametro(string Text, Int64 pIdYear, Int64 pIdCurso)
        {
            List<Matricula> lista = new List<Matricula>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select m.* from matricula as m inner join curso as c on c.Id =m.IdCurso " +
                        "inner join year as y on y.Id=c.IdYear inner join estudiante as e on e.Id=m.IdEstudiante inner join persona as p " +
                        "on p.Id=e.IdPersona where( Upper(p.Nombre) like '%" + Text.ToUpper() + "%' or Upper(e.Telefono) like '%" + Text.ToUpper() +
                        "%' or Upper(e.TelEmergencia) like '%" + Text.ToUpper() + "%' or Upper(e.ParentEmergencia) like '%" + Text.ToUpper() + "%') and m.IdCurso=@pIdCurso and c.IdYear=@pIdYear and m.Estado='A' order by Id asc", _con);
                    comando.Parameters.AddWithValue("@pIdYear", pIdYear);
                    comando.Parameters.AddWithValue("@pIdCurso", pIdCurso);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Matricula item = new Matricula(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetInt32(3),
                            _reader.GetString(4),
                            _reader.GetInt64(5),
                            _reader.GetInt64(6),
                            EstudianteDAL.getEstudianteById(_reader.GetInt64(6)),
                            CuotaDAL.getCuotasByIdMatricula(_reader.GetInt64(0), 50),
                            DetMatriculaDAL.getDetsmatriculaByIdMatricula(_reader.GetInt64(0), 2)
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
        public static List<Matricula> searchMatriculasNoParametro(string Text, Int64 pIdSucursal, int pLimit)
        {
            List<Matricula> lista = new List<Matricula>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select m.* from matricula as m inner join curso as c on c.Id =m.IdCurso " +
                        "inner join year as y on y.Id=c.IdYear inner join estudiante as e on e.Id=m.IdEstudiante inner join persona as p " +
                        "on p.Id=e.IdPersona where( Upper(p.Nombre) like '%" + Text.ToUpper() + "%' or Upper(e.Telefono) like '%" + Text.ToUpper() +
                        "%' or Upper(e.TelEmergencia) like '%" + Text.ToUpper() + "%' or Upper(e.ParentEmergencia) like '%" + Text.ToUpper() +
                        "%') and (c.IdSucursal=@pIdSucursal) and m.Estado='A' order by Id asc limit @pLimit", _con);
                    comando.Parameters.AddWithValue("@pLimit", pLimit+900);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Matricula item = new Matricula(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetInt32(3),
                            _reader.GetString(4),
                            _reader.GetInt64(5),
                            _reader.GetInt64(6),
                            EstudianteDAL.getEstudianteById(_reader.GetInt64(6)),
                            CuotaDAL.getCuotasByIdMatricula(_reader.GetInt64(0), 50),
                            DetMatriculaDAL.getDetsmatriculaByIdMatricula(_reader.GetInt64(0), 2)
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
        public static List<Matricula> searchMatriculas(string Text, Int64 pIdSucursal)
        {
            List<Matricula> lista = new List<Matricula>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select distinct m.* from matricula as m inner join curso as c on c.Id =m.IdCurso " +
                        "inner join year as y on y.Id=c.IdYear inner join estudiante as e on e.Id=m.IdEstudiante inner join persona as p " +
                        "on p.Id=e.IdPersona where( Upper(p.Nombre) like '%" + Text.ToUpper() + "%' or Upper(e.Telefono) like '%" + Text.ToUpper() +
                        "%' or Upper(e.TelEmergencia) like '%" + Text.ToUpper() + "%' or Upper(e.ParentEmergencia) like '%" + Text.ToUpper() + "%') and c.IdSucursal=@pIdSucursal " +
                        " and m.Estado='A' order by m.Id asc", _con);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Matricula item = new Matricula(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetInt32(3),
                            _reader.GetString(4),
                            _reader.GetInt64(5),
                            _reader.GetInt64(6),
                            EstudianteDAL.getEstudianteById(_reader.GetInt64(6)),
                            CuotaDAL.getCuotasByIdMatricula(_reader.GetInt64(0), 50),
                            DetMatriculaDAL.getDetsmatriculaByIdMatricula(_reader.GetInt64(0), 2)
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
        public static List<Matricula> searchMatriculas(string Text, Int64 pIdSucursal, int pLimit,string opc)
        {
            List<Matricula> lista = new List<Matricula>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                   
                    MySqlCommand comando = new MySqlCommand("select m.* from matricula as m inner join curso as c on c.Id =m.IdCurso " +
                       "inner join year as y on y.Id=c.IdYear inner join estudiante as e on e.Id=m.IdEstudiante inner join persona as p " +
                       "on p.Id=e.IdPersona where( Upper(p.Nombre) like '%" + Text.ToUpper() + "%' or Upper(e.Telefono) like '%" + Text.ToUpper() +
                       "%' or Upper(e.TelEmergencia) like '%" + Text.ToUpper() + "%' or Upper(e.ParentEmergencia) like '%" + Text.ToUpper() +
                       "%') and (c.IdSucursal=@pIdSucursal) "+(opc!="ingreso"? " and m.Estado='A' " : "")+ " order by Id asc limit @pLimit", _con);

                    comando.Parameters.AddWithValue("@pLimit", pLimit);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Matricula item = new Matricula(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetInt32(3),
                            _reader.GetString(4),
                            _reader.GetInt64(5),
                            _reader.GetInt64(6),
                            EstudianteDAL.getEstudianteById(_reader.GetInt64(6)),
                            CuotaDAL.getCuotasByIdMatricula(_reader.GetInt64(0), 50),
                            DetMatriculaDAL.getDetsmatriculaByIdMatricula(_reader.GetInt64(0), 2)
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

        public static bool insertMatricula(Matricula item, Useremp pUser)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {
                    if (item.Estudiante.Id == 0)
                    {
                        MySqlCommand cmdInsertPersona = new MySqlCommand("Insert into persona (Nombre,Dui,Nit,FechaNac,Direccion) values (@Nombre,@Dui,@Nit,@FechaNac,@Direccion)", _con, _trans);
                        cmdInsertPersona.Parameters.AddWithValue("@Nombre", item.Estudiante.Persona.Nombre);
                        cmdInsertPersona.Parameters.AddWithValue("@Dui", "");
                        cmdInsertPersona.Parameters.AddWithValue("@Nit", "");
                        cmdInsertPersona.Parameters.AddWithValue("@FechaNac", item.Estudiante.Persona.FechaNac);
                        cmdInsertPersona.Parameters.AddWithValue("@Direccion", item.Estudiante.Persona.Direccion);
                        if (cmdInsertPersona.ExecuteNonQuery() <= 0)
                        {
                            result = false;
                        }
                        else
                        {
                            MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                            cmdUltimoId.Transaction = _trans;
                            item.Estudiante.Persona.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                            item.Estudiante.IdPersona = Convert.ToInt32(cmdUltimoId.ExecuteScalar());

                        }

                        MySqlCommand cmdInsertEstudiante = new MySqlCommand("Insert into estudiante (ApPaterno,ApMaterno,Telefono,Enfermedad,Correo,TelEmergencia,ParentEmergencia,IdPersona) values " +
                            "(@ApPaterno,@ApMaterno,@Telefono,@Enfermedad,@Correo,@TelEmergencia,@ParentEmergencia,@IdPersona)", _con, _trans);
                        cmdInsertEstudiante.Parameters.AddWithValue("@ApPaterno", item.Estudiante.ApPaterno);
                        cmdInsertEstudiante.Parameters.AddWithValue("@ApMaterno", item.Estudiante.ApMaterno);
                        cmdInsertEstudiante.Parameters.AddWithValue("@Telefono", item.Estudiante.Telefono);
                        cmdInsertEstudiante.Parameters.AddWithValue("@Enfermedad", item.Estudiante.Enfermedad);
                        cmdInsertEstudiante.Parameters.AddWithValue("@Correo", item.Estudiante.Correo);
                        cmdInsertEstudiante.Parameters.AddWithValue("@TelEmergencia", item.Estudiante.TelEmergencia);
                        cmdInsertEstudiante.Parameters.AddWithValue("@ParentEmergencia", item.Estudiante.ParentEmergencia);
                        cmdInsertEstudiante.Parameters.AddWithValue("@IdPersona", item.Estudiante.IdPersona);

                        if (cmdInsertEstudiante.ExecuteNonQuery() <= 0)
                        {
                            result = false;
                        }
                        else
                        {
                            MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                            cmdUltimoId.Transaction = _trans;
                            item.IdEstudiante = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                            item.Estudiante.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());

                        }
                    }

                    if (result)
                    {

                        MySqlCommand cmdInsertMatricula = new MySqlCommand("Insert into matricula (FhRegistro,Becado,DiaLimite,IdCurso,IdEstudiante) values (@FhRegistro,@Becado,@DiaLimite,@IdCurso,@IdEstudiante)", _con, _trans);
                        cmdInsertMatricula.Parameters.AddWithValue("@FhRegistro", item.FhRegistro);
                        cmdInsertMatricula.Parameters.AddWithValue("@Becado", item.Becado);
                        cmdInsertMatricula.Parameters.AddWithValue("@DiaLimite", item.DiaLimite);
                        cmdInsertMatricula.Parameters.AddWithValue("@IdCurso", item.IdCurso);
                        cmdInsertMatricula.Parameters.AddWithValue("@IdEstudiante", item.Estudiante.Id);

                        if (cmdInsertMatricula.ExecuteNonQuery() <= 0)
                        {
                            result = false;
                        }
                        else
                        {
                            MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                            cmdUltimoId.Transaction = _trans;
                            item.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());

                        }

                    }
                    if (result)
                    {
                        foreach (Detmatricula detMatricula in item.Padres)
                        {
                            if (detMatricula.IdEncargado == 0)
                            {
                                MySqlCommand cmdInsertPersona = new MySqlCommand("Insert into persona (Nombre,Dui,Nit,Direccion) values (@Nombre,@Dui,@Nit,@Direccion)", _con, _trans);
                                cmdInsertPersona.Parameters.AddWithValue("@Nombre", detMatricula.encargado.Persona.Nombre);
                                cmdInsertPersona.Parameters.AddWithValue("@Dui", "");
                                cmdInsertPersona.Parameters.AddWithValue("@Nit", "");
                                cmdInsertPersona.Parameters.AddWithValue("@Direccion", detMatricula.encargado.Persona.Direccion);
                                if (cmdInsertPersona.ExecuteNonQuery() <= 0)
                                {
                                    result = false;
                                }
                                else
                                {
                                    MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                                    cmdUltimoId.Transaction = _trans;
                                    detMatricula.encargado.Persona.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                                    detMatricula.encargado.IdPersona = Convert.ToInt32(cmdUltimoId.ExecuteScalar());

                                }

                                MySqlCommand cmdInsertEncargado = new MySqlCommand("Insert into encargado (LugarTrabajo,Trabajo,Telefono,IdPersona) values (@LugarTrabajo,@Trabajo,@Telefono,@IdPersona)", _con, _trans);
                                cmdInsertEncargado.Parameters.AddWithValue("@LugarTrabajo", detMatricula.encargado.LugarTrabajo);
                                cmdInsertEncargado.Parameters.AddWithValue("@Trabajo", detMatricula.encargado.Trabajo);
                                cmdInsertEncargado.Parameters.AddWithValue("@Telefono", detMatricula.encargado.Telefono);
                                cmdInsertEncargado.Parameters.AddWithValue("@IdPersona", detMatricula.encargado.IdPersona);

                                if (cmdInsertEncargado.ExecuteNonQuery() <= 0)
                                {
                                    result = false;
                                }
                                else
                                {
                                    MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                                    cmdUltimoId.Transaction = _trans;
                                    detMatricula.IdEncargado = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                                    detMatricula.encargado.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());

                                }
                            }
                            MySqlCommand cmdInsertDetMatricula = new MySqlCommand("Insert into detmatricula (Parentesco,IdMatricula,IdEncargado) values (@Parentesco,@IdMatricula,@IdEncargado)", _con, _trans);
                            cmdInsertDetMatricula.Parameters.AddWithValue("@Parentesco", detMatricula.Parentesco);
                            cmdInsertDetMatricula.Parameters.AddWithValue("@IdMatricula", item.Id);
                            cmdInsertDetMatricula.Parameters.AddWithValue("@IdEncargado", detMatricula.IdEncargado);

                            if (cmdInsertDetMatricula.ExecuteNonQuery() <= 0)
                            {
                                result = false;
                            }
                            else
                            {
                                MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                                cmdUltimoId.Transaction = _trans;
                                detMatricula.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());

                            }

                        }
                    }
                    DateTime date = Convert.ToDateTime(item.FhRegistro);
                    Curso curso = CursoDAL.getCursoById(item.IdCurso);
                    int nCuotas = Math.Abs((Convert.ToDateTime(curso.Hasta).Month - Convert.ToDateTime(item.FhRegistro).Month) + 12 * (Convert.ToDateTime(curso.Hasta).Year - Convert.ToDateTime(item.FhRegistro).Year))+1;
                    for (int i =0;i<nCuotas;i++)
                    {
                        MySqlCommand cmdInsertCuota = new MySqlCommand("Insert into cuota (FhRegistro,Precio,Total,IdMatricula) values (@FhRegistro,@Precio,@Total,@IdMatricula)", _con, _trans);
                        cmdInsertCuota.Parameters.AddWithValue("@FhRegistro", date.AddMonths(i).ToString("yyyy")+"/"+ date.AddMonths(i).ToString("MM")+"/"+(Validation.Validation.getMaxDayMonth(Convert.ToInt32(date.AddMonths(i).ToString("MM")))>Convert.ToInt32(item.DiaLimite)? item.DiaLimite:Validation.Validation.getMaxDayMonth(Convert.ToInt32(date.AddMonths(i).ToString("MM"))).ToString()));
                        cmdInsertCuota.Parameters.AddWithValue("@Precio", Properties.Settings.Default.PrecioCuota);
                        cmdInsertCuota.Parameters.AddWithValue("@Total", "0.00");
                        cmdInsertCuota.Parameters.AddWithValue("@IdMatricula", item.Id);

                        if (cmdInsertCuota.ExecuteNonQuery() <= 0)
                        {
                            result = false;
                        }
                    }
                    if (result)
                    {
                        MySqlCommand cmdInsertAuditoria = new MySqlCommand("Insert into regemphist (Detalle,Accion,TipoRegistro,IdUserEmp) values (@Detalle,@Accion,@TipoRegistro,@IdUserEmp)", _con, _trans);
                        cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Inscribio al estudiante \"" + item.Estudiante.Persona.Nombre + "\" en el curso \"" + CursoDAL.getCursoById(item.IdCurso).Nombre + "\"" +
                            (item.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault() == null ? "" : ", selecciono a \"" + item.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.Persona.Nombre + "\"" +
                            (item.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault() == null ? "." : " y a \"" + item.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.Persona.Nombre + "\" como su padre.")));
                        cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Registrar");
                        cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Inscripcion");
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
        public static bool updateMatricula(Matricula item, Useremp pUser)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {
                    Matricula matricula = getMatriculaById(item.Id);
                    MySqlCommand cmdUpdatePersona = new MySqlCommand("update persona set Nombre=@Nombre,Dui=@Dui,Nit=@Nit,Direccion=@Direccion,FechaNac=@FechaNac where Id=@Id", _con, _trans);
                    cmdUpdatePersona.Parameters.AddWithValue("@Id", item.Estudiante.Persona.Id);
                    cmdUpdatePersona.Parameters.AddWithValue("@Nombre", item.Estudiante.Persona.Nombre);
                    cmdUpdatePersona.Parameters.AddWithValue("@Dui", item.Estudiante.Persona.Dui);
                    cmdUpdatePersona.Parameters.AddWithValue("@Nit", item.Estudiante.Persona.Nit);
                    cmdUpdatePersona.Parameters.AddWithValue("@Direccion", item.Estudiante.Persona.Direccion);
                    cmdUpdatePersona.Parameters.AddWithValue("@FechaNac", Convert.ToDateTime(item.Estudiante.Persona.FechaNac).ToString("yyyy-MM-dd"));
                    if (cmdUpdatePersona.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    MySqlCommand cmdUpdateEstudiante = new MySqlCommand("update estudiante set ApPaterno=@ApPaterno,ApMaterno=@ApMaterno, " +
                        "Telefono=@Telefono,Enfermedad=@Enfermedad,Correo=@Correo,TelEmergencia=@TelEmergencia,ParentEmergencia=@ParentEmergencia,IdPersona=@IdPersona " +
                        "where Id=@Id", _con, _trans);
                    cmdUpdateEstudiante.Parameters.AddWithValue("@Id", item.Estudiante.Id);

                    cmdUpdateEstudiante.Parameters.AddWithValue("@ApPaterno", item.Estudiante.ApPaterno);
                    cmdUpdateEstudiante.Parameters.AddWithValue("@ApMaterno", item.Estudiante.ApMaterno);
                    cmdUpdateEstudiante.Parameters.AddWithValue("@Telefono", item.Estudiante.Telefono);
                    cmdUpdateEstudiante.Parameters.AddWithValue("@Enfermedad", item.Estudiante.Enfermedad);
                    cmdUpdateEstudiante.Parameters.AddWithValue("@Correo", item.Estudiante.Correo);
                    cmdUpdateEstudiante.Parameters.AddWithValue("@TelEmergencia", item.Estudiante.TelEmergencia);
                    cmdUpdateEstudiante.Parameters.AddWithValue("@ParentEmergencia", item.Estudiante.ParentEmergencia);
                    cmdUpdateEstudiante.Parameters.AddWithValue("@IdPersona", item.Estudiante.IdPersona);

                    if (cmdUpdateEstudiante.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }

                    MySqlCommand cmdUpdateMatricula = new MySqlCommand("update matricula set FhRegistro=@FhRegistro,Becado=@Becado,DiaLimite=@DiaLimite,IdCurso=@IdCurso where Id=@Id", _con, _trans);
                    cmdUpdateMatricula.Parameters.AddWithValue("@Id", item.Id);
                    cmdUpdateMatricula.Parameters.AddWithValue("@FhRegistro", item.FhRegistro);
                    cmdUpdateMatricula.Parameters.AddWithValue("@Becado", item.Becado);
                    cmdUpdateMatricula.Parameters.AddWithValue("@DiaLimite", item.DiaLimite);
                    cmdUpdateMatricula.Parameters.AddWithValue("@IdCurso", item.IdCurso);

                    if (cmdUpdateMatricula.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }

                    if (result)
                    {
                        foreach (Detmatricula detMatricula in item.Padres)
                        {
                            if (detMatricula.Id == 0)
                            {
                                if (detMatricula.encargado.Id == 0)
                                {
                                    MySqlCommand cmdInsertPersona = new MySqlCommand("Insert into persona (Nombre,Dui,Nit,Direccion) values (@Nombre, @Dui, @Nit, @Direccion)", _con, _trans);
                                    cmdInsertPersona.Parameters.AddWithValue("@Nombre", detMatricula.encargado.Persona.Nombre);
                                    cmdInsertPersona.Parameters.AddWithValue("@Dui", "");
                                    cmdInsertPersona.Parameters.AddWithValue("@Nit", "");
                                    cmdInsertPersona.Parameters.AddWithValue("@Direccion", detMatricula.encargado.Persona.Direccion);
                                    if (cmdInsertPersona.ExecuteNonQuery() <= 0)
                                    {
                                        result = false;
                                    }
                                    else
                                    {
                                        MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                                        cmdUltimoId.Transaction = _trans;
                                        detMatricula.encargado.Persona.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                                        detMatricula.encargado.IdPersona = Convert.ToInt32(cmdUltimoId.ExecuteScalar());

                                    }

                                    MySqlCommand cmdInsertEncargado = new MySqlCommand("Insert into encargado (LugarTrabajo,Trabajo,Telefono,IdPersona) values (@LugarTrabajo,@Trabajo,@Telefono,@IdPersona)", _con, _trans);
                                    cmdInsertEncargado.Parameters.AddWithValue("@LugarTrabajo", detMatricula.encargado.LugarTrabajo);
                                    cmdInsertEncargado.Parameters.AddWithValue("@Trabajo", detMatricula.encargado.Trabajo);
                                    cmdInsertEncargado.Parameters.AddWithValue("@Telefono", detMatricula.encargado.Telefono);
                                    cmdInsertEncargado.Parameters.AddWithValue("@IdPersona", detMatricula.encargado.IdPersona);

                                    if (cmdInsertEncargado.ExecuteNonQuery() <= 0)
                                    {
                                        result = false;
                                    }
                                    else
                                    {
                                        MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                                        cmdUltimoId.Transaction = _trans;
                                        detMatricula.IdEncargado = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                                        detMatricula.encargado.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());

                                    }
                                    MySqlCommand cmdInsertDetMatricula = new MySqlCommand("Insert into detmatricula (Parentesco,IdMatricula,IdEncargado) values (@Parentesco,@IdMatricula,@IdEncargado)", _con, _trans);
                                    cmdInsertDetMatricula.Parameters.AddWithValue("@Parentesco", detMatricula.Parentesco);
                                    cmdInsertDetMatricula.Parameters.AddWithValue("@IdMatricula", item.Id);
                                    cmdInsertDetMatricula.Parameters.AddWithValue("@IdEncargado", detMatricula.IdEncargado);

                                    if (cmdInsertDetMatricula.ExecuteNonQuery() <= 0)
                                    {
                                        result = false;
                                    }
                                    else
                                    {
                                        MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                                        cmdUltimoId.Transaction = _trans;
                                        detMatricula.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                                    }
                                }
                                else
                                {
                                    MySqlCommand cmdInsertDetMatricula = new MySqlCommand("Insert into detmatricula (Parentesco,IdMatricula,IdEncargado) values (@Parentesco,@IdMatricula,@IdEncargado)", _con, _trans);
                                    cmdInsertDetMatricula.Parameters.AddWithValue("@Parentesco", detMatricula.Parentesco);
                                    cmdInsertDetMatricula.Parameters.AddWithValue("@IdMatricula", detMatricula.IdMatricula);
                                    cmdInsertDetMatricula.Parameters.AddWithValue("@IdEncargado", detMatricula.IdEncargado);

                                    if (cmdInsertDetMatricula.ExecuteNonQuery() <= 0)
                                    {
                                        result = false;
                                    }
                                    else
                                    {
                                        MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                                        cmdUltimoId.Transaction = _trans;
                                        detMatricula.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                                    }
                                }
                            }
                            else
                            {
                                //actualizar persona

                                MySqlCommand cmdUpdatePersonaEnc = new MySqlCommand("update persona set Nombre=@Nombre,Direccion=@Direccion where Id=@Id", _con, _trans);
                                cmdUpdatePersonaEnc.Parameters.AddWithValue("@Id", detMatricula.encargado.Persona.Id);
                                cmdUpdatePersonaEnc.Parameters.AddWithValue("@Nombre", detMatricula.encargado.Persona.Nombre);
                                cmdUpdatePersonaEnc.Parameters.AddWithValue("@Direccion", detMatricula.encargado.Persona.Direccion);
                                if (cmdUpdatePersonaEnc.ExecuteNonQuery() <= 0)
                                {
                                    result = false;
                                }
                                MySqlCommand cmdUpdateEncargado = new MySqlCommand("update encargado set LugarTrabajo=@LugarTrabajo,Trabajo=@Trabajo,Telefono=@Telefono where Id=@Id", _con, _trans);
                                cmdUpdateEncargado.Parameters.AddWithValue("@Id", detMatricula.encargado.Id);
                                cmdUpdateEncargado.Parameters.AddWithValue("@LugarTrabajo", detMatricula.encargado.LugarTrabajo);
                                cmdUpdateEncargado.Parameters.AddWithValue("@Trabajo", detMatricula.encargado.Trabajo);
                                cmdUpdateEncargado.Parameters.AddWithValue("@Telefono", detMatricula.encargado.Telefono);

                                if (cmdUpdateEncargado.ExecuteNonQuery() <= 0)
                                {
                                    result = false;
                                }
                            }
                        }
                    }
                    if (result)
                    {
                        DateTime date = Convert.ToDateTime(item.FhRegistro);
                        Curso curso = CursoDAL.getCursoById(item.IdCurso);

                        foreach(Cuota cuota in item.Cuotas)
                        {
                            MySqlCommand cmdInsertCuota = new MySqlCommand("update cuota set FhRegistro=@FhRegistro where Id=@pId", _con, _trans);
                            cmdInsertCuota.Parameters.AddWithValue("@FhRegistro", Convert.ToDateTime(cuota.FhRegistro).ToString("yyyy") + "/" + Convert.ToDateTime(cuota.FhRegistro).ToString("MM") + "/" + (Validation.Validation.getMaxDayMonth(Convert.ToDateTime(cuota.FhRegistro).Month) > Convert.ToInt32(item.DiaLimite) ? item.DiaLimite: Validation.Validation.getMaxDayMonth(Convert.ToDateTime(cuota.FhRegistro).Month).ToString()));

                            cmdInsertCuota.Parameters.AddWithValue("@pId", cuota.Id);
                            
                            if (cmdInsertCuota.ExecuteNonQuery() <= 0)
                            {
                                result = false;
                            }
                        }
                    }
                    if (result)
                    {
                        foreach (Detmatricula detMatricula in matricula.Padres)
                        {
                            if (item.Padres.Where(a=>a.Id==detMatricula.Id).FirstOrDefault()==null)
                            {
                                MySqlCommand cmdDeleteDetMatricula = new MySqlCommand("Delete from detmatricula where Id=@pId;", _con, _trans);
                                cmdDeleteDetMatricula.Parameters.AddWithValue("@pId", detMatricula.Id);

                                if (cmdDeleteDetMatricula.ExecuteNonQuery() <= 0)
                                {
                                    result = false;
                                }
                            }
                        }
                    }
                    if (result)
                    {
                        Estudiante est = matricula.Estudiante;
                        MySqlCommand cmdInsertAuditoria = new MySqlCommand("Insert into regemphist (Detalle,Accion,TipoRegistro,IdUserEmp) values (@Detalle,@Accion,@TipoRegistro,@IdUserEmp)", _con, _trans);
                        cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Actualizó la información de inscripción del alumno \""+est.Persona.Nombre+"\" valores antiguos: \n"+
                            "Nombre: "+est.Persona.Nombre+", Apellido Paterno: "+est.ApPaterno+", Apellido Materno: "+est.ApMaterno+", Fecha de Nacimiento: "+est.Persona.FechaNac+", "+
                            "Enfermedad: "+est.Enfermedad+ ", Dirección: "+est.Persona.Direccion+", Correo: "+est.Correo+ ", Teléfono: "+est.Telefono+ ", Teléfono de emergencias: "+
                            est.TelEmergencia+", Parentesco o nombre: "+est.ParentEmergencia+", Curso: "+CursoDAL.getCursoById(matricula.IdCurso).Nombre+", Dia limite de pago: "+
                            matricula.DiaLimite+", Becado: "+(matricula.Becado==0?"No":"Si")+(matricula.Padres.Where(a=>a.Parentesco=="Padre").FirstOrDefault()== null?"": ", Padre:"+matricula.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.Persona.Nombre)+
                           (matricula.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault() == null ? ".\n" : ", Madre: "+matricula.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.Persona.Nombre)+
                            "Datos Nuevos: \n"+
                            "Nombre: " + item.Estudiante.Persona.Nombre + ", Apellido Paterno: " + item.Estudiante.ApPaterno + ", Apellido Materno: " + item.Estudiante.ApMaterno + ", Fecha de Nacimiento: " + item.Estudiante.Persona.FechaNac + ", " +
                            "Enfermedad: " + item.Estudiante.Enfermedad + ", Dirección: " + item.Estudiante.Persona.Direccion + ", Correo: " + item.Estudiante.Correo + ", Teléfono: " + item.Estudiante.Telefono + ", Teléfono de emergencias: " +
                            item.Estudiante.TelEmergencia + ", Parentesco o nombre: " + item.Estudiante.ParentEmergencia + ", Curso: " + CursoDAL.getCursoById(item.IdCurso).Nombre + ", Dia limite de pago: " +
                            item.DiaLimite + ", Becado: " + (item.Becado == 0 ? "No" : "Si") + (item.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault() == null ? "" : ", Padre:" + item.Padres.Where(a => a.Parentesco == "Padre").FirstOrDefault().encargado.Persona.Nombre) +
                           (item.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault() == null ? ".\n" : ", Madre: " + item.Padres.Where(a => a.Parentesco == "Madre").FirstOrDefault().encargado.Persona.Nombre));

                        cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Actualizar");
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
