using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class UserempDAL
    {
        public static Useremp getUserempById(int pId)
        {
            Useremp item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from useremp where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Useremp(
                           _reader.GetInt64(0),
                           _reader.GetString(1),
                           _reader.GetString(2),
                           _reader.GetString(3),
                           _reader.GetString(4),
                           _reader.GetInt64(5),
                           _reader.GetInt64(6),
                           ContratoDAL.getContratoById(_reader.GetInt64(6))
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
        public static Useremp getUseremp(string pLogin,string pPass)
        {
            Useremp item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from useremp where Login=@pLogin and Pass=md5(@pPass)", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pLogin", pLogin);
                    cmdGetItemById.Parameters.AddWithValue("@pPass", pPass);

                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Useremp(
                           _reader.GetInt64(0),
                           _reader.GetString(1),
                           _reader.GetString(2),
                           _reader.GetString(3),
                           _reader.GetString(4),
                           _reader.GetInt64(5),
                           _reader.GetInt64(6),
                           ContratoDAL.getContratoById(_reader.GetInt64(6))
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
        public static bool verificarUseremp()
        {
            bool item = false;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from useremp", _con);

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
        public static bool testConexion()
        {
            bool result = true;
            try
            {
                using (MySql.Data.MySqlClient.MySqlConnection _conn = new Conexion().Conectar())
                {
                    _conn.Open();
                    _conn.Close();
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public static bool InsertUserEmpConf(Useremp item,Sucursal itemSucursal)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {
                    MySqlCommand cmdInsertSucursal = new MySqlCommand("Insert into sucursal (Nombre,Direccion) values (@Nombre,@Direccion)", _con, _trans);
                    cmdInsertSucursal.Parameters.AddWithValue("@Nombre", itemSucursal.Nombre);
                    cmdInsertSucursal.Parameters.AddWithValue("@Direccion", itemSucursal.Direccion);

                    if (cmdInsertSucursal.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    else
                    {
                        MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                        cmdUltimoId.Transaction = _trans;
                        item.IdSucursal = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                    }

                    MySqlCommand cmdInsertPersona = new MySqlCommand("Insert into persona (Nombre,Dui,Nit,FechaNac,Direccion) values (@Nombre,@Dui,@Nit,@FechaNac,@Direccion)", _con, _trans);
                    cmdInsertPersona.Parameters.AddWithValue("@Nombre", item.Contrato.Empleado.Persona.Nombre);
                    cmdInsertPersona.Parameters.AddWithValue("@Dui", item.Contrato.Empleado.Persona.Dui);
                    cmdInsertPersona.Parameters.AddWithValue("@Nit", item.Contrato.Empleado.Persona.Nit);
                    cmdInsertPersona.Parameters.AddWithValue("@FechaNac", item.Contrato.Empleado.Persona.FechaNac);
                    cmdInsertPersona.Parameters.AddWithValue("@Direccion", item.Contrato.Empleado.Persona.Direccion);
                    if (cmdInsertPersona.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    else
                    {
                        MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                        cmdUltimoId.Transaction = _trans;
                        item.Contrato.Empleado.Persona.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                        item.Contrato.Empleado.IdPersona = item.Contrato.Empleado.Persona.Id;

                    }

                    MySqlCommand cmdInsertEmpleado = new MySqlCommand("Insert into empleado (Telefono,Correo,IdPersona) values (@Telefono,@Correo,@IdPersona)", _con, _trans);
                    cmdInsertEmpleado.Parameters.AddWithValue("@Telefono", item.Contrato.Empleado.Telefono);
                    cmdInsertEmpleado.Parameters.AddWithValue("@Correo", item.Contrato.Empleado.Correo);
                    cmdInsertEmpleado.Parameters.AddWithValue("@IdPersona", item.Contrato.Empleado.Persona.Id);

                    if (cmdInsertEmpleado.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    else
                    {
                        MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                        cmdUltimoId.Transaction = _trans;
                        item.Contrato.Empleado.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                        item.Contrato.IdEmpleado = item.Contrato.Empleado.Id;

                    }
                    MySqlCommand cmdInsertCargo = new MySqlCommand("Insert into cargo (Nombre) values (@Nombre)", _con, _trans);
                    cmdInsertCargo.Parameters.AddWithValue("@Nombre", item.Contrato.Cargo.Nombre);

                    if (cmdInsertCargo.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    else
                    {
                        MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                        cmdUltimoId.Transaction = _trans;
                        item.Contrato.Cargo.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                        item.Contrato.IdCargo = item.Contrato.Cargo.Id;

                    }

                    MySqlCommand cmdInsertContrato = new MySqlCommand("Insert into contrato (FhInicio,Estado,IdCargo,IdEmpleado) values (@FhInicio,@Estado,@IdCargo,@IdEmpleado)", _con, _trans);
                    cmdInsertContrato.Parameters.AddWithValue("@FhInicio", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmdInsertContrato.Parameters.AddWithValue("@Estado", "A");
                    cmdInsertContrato.Parameters.AddWithValue("@IdCargo", item.Contrato.IdCargo);
                    cmdInsertContrato.Parameters.AddWithValue("@IdEmpleado", item.Contrato.Empleado.Id);

                    if (cmdInsertContrato.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    else
                    {
                        MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                        cmdUltimoId.Transaction = _trans;
                        item.IdContrato = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                        item.Contrato.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());

                    }
                    MySqlCommand cmdInsertUsuarioEmp = new MySqlCommand("Insert into useremp(Login,Pass,Rol,IdSucursal,IdContrato)"+
                        " values (@Login,md5(@Pass),@Rol,@IdSucursal,@IdContrato)", _con, _trans);
                    cmdInsertUsuarioEmp.Parameters.AddWithValue("@Login", item.Login);
                    cmdInsertUsuarioEmp.Parameters.AddWithValue("@Pass", item.Pass);
                    cmdInsertUsuarioEmp.Parameters.AddWithValue("@Rol", item.Rol);
                    cmdInsertUsuarioEmp.Parameters.AddWithValue("@IdSucursal", item.IdSucursal);
                    cmdInsertUsuarioEmp.Parameters.AddWithValue("@IdContrato", item.IdContrato);

                    if (cmdInsertUsuarioEmp.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }

                    MySqlCommand cmdInsertCargos = new MySqlCommand("Insert into cargo (Nombre) values ('Director');Insert into cargo (Nombre) values ('Docente');Insert into cargo (Nombre) values ('Secretario/a')", _con, _trans);
                    if (cmdInsertCargos.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    if(result)
                        _trans.Commit();

                }
                catch (Exception ex)
                {
                    result = false;
                    _trans.Rollback();
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
        public static bool UpdateUserEmp(Useremp item)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {
                    MySqlCommand cmdUpdateUserEmp = new MySqlCommand("update useremp set Pass=md5(@Pass) where Id=@Id", _con, _trans);
                    cmdUpdateUserEmp.Parameters.AddWithValue("@Pass", item.Pass);
                    cmdUpdateUserEmp.Parameters.AddWithValue("@Id", item.Id);

                    if (cmdUpdateUserEmp.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    if (result)
                        _trans.Commit();

                }
                catch (Exception ex)
                {
                    result = false;
                    _trans.Rollback();
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
