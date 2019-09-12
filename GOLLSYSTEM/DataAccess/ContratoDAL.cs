using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class ContratoDAL
    {
        public static Contrato getContratoById(Int64 pId)
        {
            Contrato item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from contrato where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Contrato(
                        _reader.GetInt64(0),
                        _reader.GetString(1),
                        _reader.GetString(2),
                        _reader.IsDBNull(3) ? null : _reader.GetString(3),
                        _reader.GetString(4),
                        _reader.GetInt64(5),
                        _reader.GetInt64(6),
                        _reader.GetInt64(7),
                        CargoDAL.getCargoById(_reader.GetInt64(5)),
                        EmpleadoDAL.getEmpleadoById(_reader.GetInt64(6))

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
        public static List<Contrato> getContratos(int pLimit)
        {
            List<Contrato> lista = new List<Contrato>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from contrato order by Id desc limit @pLimit", _con);
                    comando.Parameters.AddWithValue("@pLimit", pLimit);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Contrato item = new Contrato(
                        _reader.GetInt64(0),
                        _reader.GetString(1),
                        _reader.GetString(2),
                        _reader.IsDBNull(3) ? null : _reader.GetString(3),
                        _reader.GetString(4),
                        _reader.GetInt64(5),
                        _reader.GetInt64(6),
                        _reader.GetInt64(7),
                        CargoDAL.getCargoById(_reader.GetInt64(5)),
                        EmpleadoDAL.getEmpleadoById(_reader.GetInt64(6))


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
        public static List<Contrato> searchContratos(string pText,int pLimit)
        {
            List<Contrato> lista = new List<Contrato>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from contrato as c inner join Empleado as e on e.Id=c.IdEmpleado inner join "+
                        " Cargo as ca on ca.Id = c.IdCargo inner join Persona as p on p.Id=e.IdPersona where "+
                        " upper(ca.Nombre) like '%"+ pText .ToUpper()+ "%' or e.Telefono like'%" + pText.ToUpper() + "%' or upper(e.correo) like '%" + pText.ToUpper() + "%' " +
                        " or upper(p.Nombre) like '%" + pText.ToUpper() + "%' or upper(p.Dui) like '%" + pText.ToUpper() + "%' or upper(p.Nit) like '%" + pText.ToUpper() + "%' order by c.Id desc limit @pLimit", _con);
                    comando.Parameters.AddWithValue("@pLimit", pLimit);
                    comando.Parameters.AddWithValue("@Text", pText.ToUpper());

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Contrato item = new Contrato(
                        _reader.GetInt64(0),
                        _reader.GetString(1),
                        _reader.GetString(2),
                        _reader.IsDBNull(3) ? null : _reader.GetString(3),
                        _reader.GetString(4),
                        _reader.GetInt64(5),
                        _reader.GetInt64(6),
                        _reader.GetInt64(7),
                        CargoDAL.getCargoById(_reader.GetInt64(5)),
                        EmpleadoDAL.getEmpleadoById(_reader.GetInt64(6))


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
        public static List<Contrato> searchContratosA(string pText, int pLimit)
        {
            List<Contrato> lista = new List<Contrato>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from contrato as c inner join Empleado as e on e.Id=c.IdEmpleado inner join " +
                        " Cargo as ca on ca.Id = c.IdCargo inner join Persona as p on p.Id=e.IdPersona where (" +
                        " upper(ca.Nombre) like '%" + pText.ToUpper() + "%' or e.Telefono like'%" + pText.ToUpper() + "%' or upper(e.correo) like '%" + pText.ToUpper() + "%' " +
                        " or upper(p.Nombre) like '%" + pText.ToUpper() + "%' or upper(p.Dui) like '%" + pText.ToUpper() + "%' or upper(p.Nit) like '%" + pText.ToUpper() + "%') and Estado='A' order by c.Id desc limit @pLimit", _con);
                    comando.Parameters.AddWithValue("@pLimit", pLimit);
                    comando.Parameters.AddWithValue("@Text", pText.ToUpper());

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Contrato item = new Contrato(
                        _reader.GetInt64(0),
                        _reader.GetString(1),
                        _reader.GetString(2),
                        _reader.IsDBNull(3) ? null : _reader.GetString(3),
                        _reader.GetString(4),
                        _reader.GetInt64(5),
                        _reader.GetInt64(6),
                        _reader.GetInt64(7),
                        CargoDAL.getCargoById(_reader.GetInt64(5)),
                        EmpleadoDAL.getEmpleadoById(_reader.GetInt64(6))


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
        public static List<Contrato> getContratosAByIdEmpleado(Int64 pIdEmpleado)
        {
            List<Contrato> lista = new List<Contrato>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from contrato where IdEmpleado=@pIdEmpleado and Estado='A' order by Id desc", _con);
                    comando.Parameters.AddWithValue("@pIdEmpleado", pIdEmpleado);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Contrato item = new Contrato(
                        _reader.GetInt64(0),
                        _reader.GetString(1),
                        _reader.GetString(2),
                        _reader.IsDBNull(3) ? null : _reader.GetString(3),
                        _reader.GetString(4),
                        _reader.GetInt64(5),
                        _reader.GetInt64(6),
                        _reader.GetInt64(7),
                        CargoDAL.getCargoById(_reader.GetInt64(5)),
                        EmpleadoDAL.getEmpleadoById(_reader.GetInt64(6))
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
        public static bool InsertFullContrato(Contrato item, Useremp pUser)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {
                    Empleado empleado = null;
                    MySqlCommand cmdBuscarEmpleado = new MySqlCommand("select e.* from empleado as e inner join persona as p on p.Id = e.IdPersona where Dui=@Dui or Nit=@Nit", _con, _trans);
                    cmdBuscarEmpleado.Parameters.AddWithValue("@Dui", item.Empleado.Persona.Dui);
                    cmdBuscarEmpleado.Parameters.AddWithValue("@Nit", item.Empleado.Persona.Nit);
                    MySqlDataReader _readerEmpleado = cmdBuscarEmpleado.ExecuteReader();
                    while (_readerEmpleado.Read())
                    {
                        empleado = new Empleado(_readerEmpleado.GetInt64(0),
                            _readerEmpleado.GetString(1),
                            _readerEmpleado.GetString(2),
                            _readerEmpleado.GetString(3),
                            CvDAL.getCvByIdEmpleado(_readerEmpleado.GetInt64(0)),
                            _readerEmpleado.GetInt64(4),
                          PersonaDAL.getPersonaById(_readerEmpleado.GetInt64(4))
                            );

                    }
                    _readerEmpleado.Close();

                    if (empleado == null)
                    {
                        MySqlCommand cmdInsertPersona = new MySqlCommand("Insert into persona (Nombre,Dui,Nit,FechaNac,Direccion) values (@Nombre,@Dui,@Nit,@FechaNac,@Direccion)", _con, _trans);
                        cmdInsertPersona.Parameters.AddWithValue("@Nombre", item.Empleado.Persona.Nombre);
                        cmdInsertPersona.Parameters.AddWithValue("@Dui", item.Empleado.Persona.Dui);
                        cmdInsertPersona.Parameters.AddWithValue("@Nit", item.Empleado.Persona.Nit);
                        cmdInsertPersona.Parameters.AddWithValue("@FechaNac",item.Empleado.Persona.FechaNac);
                        cmdInsertPersona.Parameters.AddWithValue("@Direccion", item.Empleado.Persona.Direccion);
                        if (cmdInsertPersona.ExecuteNonQuery() <= 0)
                        {
                            result = false;
                        }
                        else
                        {
                            MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                            cmdUltimoId.Transaction = _trans;
                            item.Empleado.Persona.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                        }

                        MySqlCommand cmdInsertEmpleado = new MySqlCommand("Insert into empleado (Telefono,Correo,IdPersona) values (@Telefono,@Correo,@IdPersona)", _con, _trans);
                        cmdInsertEmpleado.Parameters.AddWithValue("@Telefono", item.Empleado.Telefono);
                        cmdInsertEmpleado.Parameters.AddWithValue("@Correo", item.Empleado.Correo);
                        cmdInsertEmpleado.Parameters.AddWithValue("@IdPersona", item.Empleado.Persona.Id);

                        if (cmdInsertEmpleado.ExecuteNonQuery() <= 0)
                        {
                            result = false;
                        }
                        else
                        {
                            MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                            cmdUltimoId.Transaction = _trans;
                            item.Empleado.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                        }
                        
                        MySqlCommand cmdInsertContrato = new MySqlCommand("Insert into contrato (FhInicio,FhFin,Estado,IdCargo,IdEmpleado,IdSucursal) values (@FhInicio,@FhFin,@Estado,@IdCargo,@IdEmpleado,@IdSucursal)", _con, _trans);
                        cmdInsertContrato.Parameters.AddWithValue("@FhInicio", DateTime.Now.ToString("yyyy-MM-dd"));
                        cmdInsertContrato.Parameters.AddWithValue("@FhFin", item.FhFin);
                        cmdInsertContrato.Parameters.AddWithValue("@Estado", "A");
                        cmdInsertContrato.Parameters.AddWithValue("@IdCargo", item.IdCargo);
                        cmdInsertContrato.Parameters.AddWithValue("@IdEmpleado", item.Empleado.Id);
                        cmdInsertContrato.Parameters.AddWithValue("@IdSucursal", item.IdSucursal);

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
                            cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Registro empleado con el \"Dui " + item.Empleado.Persona.Dui + "\" contratado con el cargo de " + CargoDAL.getCargos(100).Where(a => a.Id == item.IdCargo).FirstOrDefault().Nombre);
                            cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Registrar");
                            cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Empleado");
                            cmdInsertAuditoria.Parameters.AddWithValue("@IdUserEmp", pUser.Id);
                            if (cmdInsertAuditoria.ExecuteNonQuery() <= 0)
                            {
                                result = false;
                            }
                        }
                    }
                    else
                    {
                        MySqlCommand cmdUpdatePersona = new MySqlCommand("update persona set Nombre=@Nombre,Dui=@Dui,Nit=@Nit,Direccion=@Direccion,FechaNac=@FechaNac where Id=@Id", _con, _trans);
                        cmdUpdatePersona.Parameters.AddWithValue("@Id", item.Empleado.Persona.Id);
                        cmdUpdatePersona.Parameters.AddWithValue("@Nombre", item.Empleado.Persona.Nombre);
                        cmdUpdatePersona.Parameters.AddWithValue("@Dui", item.Empleado.Persona.Dui);
                        cmdUpdatePersona.Parameters.AddWithValue("@Nit", item.Empleado.Persona.Nit);
                        cmdUpdatePersona.Parameters.AddWithValue("@Direccion", item.Empleado.Persona.Direccion);
                        cmdUpdatePersona.Parameters.AddWithValue("@FechaNac", Convert.ToDateTime(item.Empleado.Persona.FechaNac).ToString("yyyy-MM-dd"));
                        if (cmdUpdatePersona.ExecuteNonQuery() <= 0)
                        {
                            result = false;
                        }

                        MySqlCommand cmdUpdateEmpleado = new MySqlCommand("update empleado  set Telefono=@Telefono,Correo=@Correo where Id=@Id", _con, _trans);
                        cmdUpdateEmpleado.Parameters.AddWithValue("@Id", item.Empleado.Id);
                        cmdUpdateEmpleado.Parameters.AddWithValue("@Telefono", item.Empleado.Telefono);
                        cmdUpdateEmpleado.Parameters.AddWithValue("@Correo", item.Empleado.Correo);

                        if (cmdUpdateEmpleado.ExecuteNonQuery() <= 0)
                        {
                            result = false;
                        }

                        item.Empleado.Persona.Id = empleado.IdPersona;
                        item.Empleado.Id = empleado.Id;
                        MySqlCommand cmdInsertContrato = new MySqlCommand("Insert into contrato (FhRegistro,FhInicio,IdCargo,IdEmpleado,IdSucursal) values (@FhRegistro,@FhInicio,@IdCargo,@IdEmpleado,@IdSucursal)", _con, _trans);
                        cmdInsertContrato.Parameters.AddWithValue("@FhRegistro", item.FhRegistro);
                        cmdInsertContrato.Parameters.AddWithValue("@FhInicio", item.FhInicio);
                        cmdInsertContrato.Parameters.AddWithValue("@IdEmpleado", item.Empleado.Id);
                        cmdInsertContrato.Parameters.AddWithValue("@IdSucursal", item.IdSucursal);
                        cmdInsertContrato.Parameters.AddWithValue("@IdCargo", item.Cargo.Id);
                       
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
                            cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Registro un contrato nuevo al empleado con el Dui " + item.Empleado.Persona.Dui + " con el cargo de " + CargoDAL.getCargos(100).Where(a => a.Id == item.IdCargo).FirstOrDefault().Nombre);
                            cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Registrar");
                            cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Contrato");
                            cmdInsertAuditoria.Parameters.AddWithValue("@IdUserEmp", pUser.Id);
                            if (cmdInsertAuditoria.ExecuteNonQuery() <= 0)
                            {
                                result = false;
                            }
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
        public static bool InsertContrato(Contrato item, Useremp pUser)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {
                    MySqlCommand cmdInsertContrato = new MySqlCommand("Insert into contrato (FhInicio,FhFin,Estado,IdCargo,IdEmpleado,IdSucursal) values (@FhInicio,@FhFin,@Estado,@IdCargo,@IdEmpleado,@IdSucursal)", _con, _trans);
                    cmdInsertContrato.Parameters.AddWithValue("@FhInicio", item.FhInicio);
                    cmdInsertContrato.Parameters.AddWithValue("@FhFin", null);
                    cmdInsertContrato.Parameters.AddWithValue("@Estado", "A");
                    cmdInsertContrato.Parameters.AddWithValue("@IdCargo", item.IdCargo);
                    cmdInsertContrato.Parameters.AddWithValue("@IdEmpleado", item.Empleado.Id);
                    cmdInsertContrato.Parameters.AddWithValue("@IdSucursal", item.IdSucursal);

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
                        cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Registro contrato nuevo al empleado con con el \"Dui " + item.Empleado.Persona.Dui + "\" y dicho cargo es " + CargoDAL.getCargos(100).Where(a => a.Id == item.IdCargo).FirstOrDefault().Nombre);
                        cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Registrar");
                        cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Cargo");
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
        public static bool updateContrato(Contrato item, Useremp pUser)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {
                    MySqlCommand cmdUpdatePersona = new MySqlCommand("update persona set Nombre=@Nombre,Dui=@Dui,Nit=@Nit,Direccion=@Direccion,FechaNac=@FechaNac where Id=@Id", _con, _trans);
                    cmdUpdatePersona.Parameters.AddWithValue("@Id", item.Empleado.Persona.Id);
                    cmdUpdatePersona.Parameters.AddWithValue("@Nombre", item.Empleado.Persona.Nombre);
                    cmdUpdatePersona.Parameters.AddWithValue("@Dui", item.Empleado.Persona.Dui);
                    cmdUpdatePersona.Parameters.AddWithValue("@Nit", item.Empleado.Persona.Nit);
                    cmdUpdatePersona.Parameters.AddWithValue("@Direccion", item.Empleado.Persona.Direccion);
                    cmdUpdatePersona.Parameters.AddWithValue("@FechaNac", Convert.ToDateTime(item.Empleado.Persona.FechaNac).ToString("yyyy-MM-dd"));
                    if (cmdUpdatePersona.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }

                    MySqlCommand cmdUpdateEmpleado = new MySqlCommand("update empleado  set Telefono=@Telefono,Correo=@Correo where Id=@Id", _con, _trans);
                    cmdUpdateEmpleado.Parameters.AddWithValue("@Id", item.Empleado.Id);
                    cmdUpdateEmpleado.Parameters.AddWithValue("@Telefono", item.Empleado.Telefono);
                    cmdUpdateEmpleado.Parameters.AddWithValue("@Correo", item.Empleado.Correo);

                    if (cmdUpdateEmpleado.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }

                    MySqlCommand cmdUpdateContrato = new MySqlCommand("update contrato set IdCargo=@IdCargo where Id=@Id", _con, _trans);
                    cmdUpdateContrato.Parameters.AddWithValue("@Id", item.Id);
                    cmdUpdateContrato.Parameters.AddWithValue("@IdCargo", item.Cargo.Id);

                    if (cmdUpdateContrato.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }

                    if (result)
                    {
                        MySqlCommand cmdInsertAuditoria = new MySqlCommand("Insert into regemphist (Detalle,Accion,TipoRegistro,IdUserEmp) values (@Detalle,@Accion,@TipoRegistro,@IdUserEmp)", _con, _trans);
                        cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Actualizó empleado con el \"Dui " + item.Empleado.Persona.Dui + "\" con el cargo de " + CargoDAL.getCargos(100).Where(a => a.Id == item.IdCargo).FirstOrDefault().Nombre);
                        cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Actualizar");
                        cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Empleado");
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
        public static bool terminarContrato(Contrato item, Useremp pUser)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {

                    MySqlCommand cmdUpdateContrato = new MySqlCommand("update contrato set FhFin=CURRENT_TIME,Estado='F' where Id=@Id ", _con, _trans);
                    cmdUpdateContrato.Parameters.AddWithValue("@Id", item.Id);
                    if (cmdUpdateContrato.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }

                    if (result)
                    {
                        MySqlCommand cmdInsertAuditoria = new MySqlCommand("Insert into regemphist (Detalle,Accion,TipoRegistro,IdUserEmp) values (@Detalle,@Accion,@TipoRegistro,@IdUserEmp)", _con, _trans);
                        cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Terminó Contrato del empleado con el \"Dui " + item.Empleado.Persona.Dui + "\" y el cargo " + CargoDAL.getCargos(100).Where(a => a.Id == item.IdCargo).FirstOrDefault().Nombre);
                        cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Terminar");
                        cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Contrato");
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
