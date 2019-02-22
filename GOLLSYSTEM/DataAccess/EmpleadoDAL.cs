using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;
using System.Windows;

namespace GOLLSYSTEM.DataAccess
{
    class EmpleadoDAL
    {
        public static Empleado getEmpleadoById(Int64 pId)
        {
            Empleado item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from empleado where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Empleado(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            CvDAL.getCvById(_reader.GetInt64(0)),
                            _reader.GetInt64(4),
                            PersonaDAL.getPersonaById(_reader.GetInt64(4))
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
        public static Empleado getEmpleadoByDuiNit(string Dui,string Nit)
        {
            Empleado item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select e.* from empleado as e inner join persona as p on p.Id=e.IdPersona where Dui=@Dui or Nit=@Nit", _con);
                    cmdGetItemById.Parameters.AddWithValue("@Dui", Dui);
                    cmdGetItemById.Parameters.AddWithValue("@Nit", Nit);

                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Empleado(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            CvDAL.getCvById(_reader.GetInt64(0)),
                            _reader.GetInt64(4),
                            PersonaDAL.getPersonaById(_reader.GetInt64(4))
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
        public static List<Cargo> getCargos(int pLimit)
        {
            List<Cargo> lista = new List<Cargo>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from cargo order by Id desc limit @pLimit", _con);
                    comando.Parameters.AddWithValue("@pLimit", pLimit);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Cargo item = new Cargo(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(1)
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
        public static bool updateEmpleado(Contrato item, Useremp pUser)
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
                    cmdUpdatePersona.Parameters.AddWithValue("@FechaNac", item.Empleado.Persona.FechaNac);
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

    }
}
