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
                           _reader.GetInt64(4),
                           ContratoDAL.getContratoById(_reader.GetInt64(4)),
                           AcsSucursalDAL.getAcsSucursalesByIdUser(_reader.GetInt64(0))
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
                           _reader.GetInt64(4),
                           ContratoDAL.getContratoById(_reader.GetInt64(4)),
                           AcsSucursalDAL.getAcsSucursalesByIdUser(_reader.GetInt64(0))
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
        public static Useremp getUseremp(string pLogin)
        {
            Useremp item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from useremp where Upper(Login)=@pLogin", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pLogin", pLogin);

                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Useremp(
                           _reader.GetInt64(0),
                           _reader.GetString(1),
                           _reader.GetString(2),
                           _reader.GetString(3),
                           _reader.GetInt64(4),
                           ContratoDAL.getContratoById(_reader.GetInt64(4)),
                           AcsSucursalDAL.getAcsSucursalesByIdUser(_reader.GetInt64(0))
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

        public static List<Useremp> getUsersemp()
        {
            List<Useremp> lista = new List<Useremp>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from useremp", _con);
                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Useremp item = new Useremp(
                           _reader.GetInt64(0),
                           _reader.GetString(1),
                           _reader.GetString(2),
                           _reader.GetString(3),
                           _reader.GetInt64(4),
                           ContratoDAL.getContratoById(_reader.GetInt64(4)),
                           AcsSucursalDAL.getAcsSucursalesByIdUser(_reader.GetInt64(0))
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
        public static bool InsertUserEmp(Useremp item,Useremp pUser)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {
                    MySqlCommand cmdInsertAuditoria = null;

                    MySqlCommand cmdInsert = new MySqlCommand("Insert into useremp(Login,Pass,Estado,IdContrato)" +
                        " values (@Login,md5(@Pass),@Estado,@IdContrato)", _con, _trans);
                    cmdInsert.Parameters.AddWithValue("@Login", item.Login);
                    cmdInsert.Parameters.AddWithValue("@Pass", item.Pass);
                    cmdInsert.Parameters.AddWithValue("@Estado", item.Estado);

                    cmdInsert.Parameters.AddWithValue("@IdContrato", item.IdContrato);

                    if (cmdInsert.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    else
                    {
                        cmdInsert = new MySqlCommand("select last_insert_id() as id;", _con);
                        cmdInsert.Transaction = _trans;
                        item.Id = Convert.ToInt32(cmdInsert.ExecuteScalar());
                        item.Sucursales[0].IdUserEmp = Convert.ToInt32(item.Id);
                    }
                    cmdInsert = new MySqlCommand("Insert into acssucursal values (null,null,@IdUserEmp,@IdRol,@IdSucursal)", _con, _trans);
                    cmdInsert.Parameters.AddWithValue("@IdUserEmp", item.Id);
                    cmdInsert.Parameters.AddWithValue("@IdRol", item.Sucursales[0].IdRol);
                    cmdInsert.Parameters.AddWithValue("@IdSucursal", item.Sucursales[0].IdSucursal);

                    if (cmdInsert.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    else
                    {
                        cmdInsert = new MySqlCommand("select last_insert_id() as id;", _con);
                        cmdInsert.Transaction = _trans;
                        item.Sucursales[0].Id = Convert.ToInt32(cmdInsert.ExecuteScalar());
                    }
                    foreach (LstPermiso obj in item.Sucursales[0].Permisos)
                    {
                        cmdInsert = new MySqlCommand("Insert into lstpermiso values (null,null,@Otorgado,@IdPermiso,@IdAcsSucursal)", _con, _trans);
                        cmdInsert.Parameters.AddWithValue("@Otorgado", obj.Otorgado?1:0);
                        cmdInsert.Parameters.AddWithValue("@IdPermiso", obj.IdPermiso);
                        cmdInsert.Parameters.AddWithValue("@IdAcsSucursal", item.Sucursales[0].Id);

                        if (cmdInsert.ExecuteNonQuery() <= 0)
                        {
                            result = false;
                        }
                        else
                        {
                            cmdInsert = new MySqlCommand("select last_insert_id() as id;", _con);
                            cmdInsert.Transaction = _trans;
                            obj.Id = Convert.ToInt32(cmdInsert.ExecuteScalar());
                        }
                    }
                    if (result)
                    {
                        cmdInsertAuditoria = new MySqlCommand("Insert into regemphist (Detalle,Accion,TipoRegistro,IdUserEmp) values (@Detalle,@Accion,@TipoRegistro,@IdUserEmp)", _con, _trans);
                        cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Registró el usuario con Id \"" + item.Id + "\", Login \"" + item.Login + "\", Id de Contrato \""+item.IdContrato+"\", Empleado \""+item.Contrato.Empleado.Persona.Nombre+"\".");
                        cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Inserción");
                        cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Usuario");
                        cmdInsertAuditoria.Parameters.AddWithValue("@IdUserEmp", pUser.Id);
                        if (cmdInsertAuditoria.ExecuteNonQuery() <= 0)
                        {
                            result = false;
                        }
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
        public static bool InsertUserEmpConf(Useremp item,Sucursal itemSucursal)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {
                    MySqlCommand cmdInsertRol = new MySqlCommand("Insert into rol (Nombre) values (@Nombre)", _con, _trans);
                    cmdInsertRol.Parameters.AddWithValue("@Nombre", item.Sucursales[0].Rol.Nombre);

                    if (cmdInsertRol.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    else
                    {
                        MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                        cmdUltimoId.Transaction = _trans;
                        item.Sucursales[0].IdRol = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                        item.Sucursales[0].Rol.Id = item.Sucursales[0].IdRol;
                    }
                    MySqlCommand cmdInsertRoles = new MySqlCommand("Insert into rol values (2,'Secretario/a'),(3,'Docente'),(4,'Administrador')", _con, _trans);

                    if (cmdInsertRoles.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    MySqlCommand cmdInsertSucursal = new MySqlCommand("Insert into sucursal (Nombre,Direccion) values (@Nombre,@Direccion)", _con, _trans);
                    cmdInsertRol.Parameters.AddWithValue("@Nombre", itemSucursal.Nombre);
                    cmdInsertRol.Parameters.AddWithValue("@Direccion", itemSucursal.Direccion);

                    if (cmdInsertRol.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    else
                    {
                        MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                        cmdUltimoId.Transaction = _trans;
                        item.Sucursales[0].IdSucursal = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                        item.Sucursales[0].Sucursal.Id = item.Sucursales[0].IdSucursal;
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
                    MySqlCommand cmdInsertUsuarioEmp = new MySqlCommand("Insert into useremp(Login,Pass,IdContrato)"+
                        " values (@Login,md5(@Pass),@IdContrato)", _con, _trans);
                    cmdInsertUsuarioEmp.Parameters.AddWithValue("@Login", item.Login);
                    cmdInsertUsuarioEmp.Parameters.AddWithValue("@Pass", item.Pass);
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
                    MySqlCommand cmdInsertAcsSucursal = new MySqlCommand("Insert into acssucursal (IdUserEmp,IdRol,IdSucursal) values (@IdUserEmp,@IdRol,@IdSucursal)", _con, _trans);
                    cmdInsertAcsSucursal.Parameters.AddWithValue("@IdUserEmp", item.Id);
                    cmdInsertAcsSucursal.Parameters.AddWithValue("@IdRol", item.Sucursales[0].IdRol);
                    cmdInsertAcsSucursal.Parameters.AddWithValue("@IdSucursal", item.Sucursales[0].IdSucursal);

                    if (cmdInsertAcsSucursal.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    else
                    {
                        MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                        cmdUltimoId.Transaction = _trans;
                        item.Sucursales[0].Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                    }
                    // asignacion de permisos al acceso de sucursal
                    MySqlCommand cmdInsertPermisos = new MySqlCommand("Insert into permiso values"+
                        "(1,'Gestionar Matriculas','Gestionar Matriculas'),"+
                        "(2,'Matricular Estudiantes','Gestionar Matriculas'),"+
                        "(3,'Editar Matriculas','Gestionar Matriculas')," +
                        "(4,'Desertar Estudiantes','Gestionar Matriculas')," +
                        "(5,'Gestionar Empleados','Gestionar Empleados')," +
                        "(6,'Crear Empleados','Gestionar Empleados')," +
                        "(7,'Editar Empleados','Gestionar Empleados')," +
                        "(8,'Crear Contratos','Gestionar Empleados')," +
                        "(9,'Editar Contratos','Gestionar Empleados')," +
                        "(10,'Terminar Contratos','Gestionar Empleados')," +
                        "(11,'Gestionar Cursos','Gestionar Cursos')," +
                        "(12,'Crear Cursos','Gestionar Cursos')," +
                        "(13,'Editar Cursos','Gestionar Cursos')," +
                        "(14,'Anular Cursos','Gestionar Cursos')," +
                        "(15,'Gestionar Ingresos','Gestionar Ingresos')," +
                        "(16,'Registrar Ingresos','Gestionar Ingresos')," +
                        "(17,'Anular Ingresos','Gestionar Ingresos')," +
                        "(18,'Exportar Ingresos y Egresos del mes','Gestionar Ingresos')," +
                        "(19,'Gestionar Egresos','Gestionar Egresos')," +
                        "(20,'Registrar Egresos','Gestionar Egresos')," +
                        "(21,'Editar Egresos','Gestionar Egresos')," +
                        "(22,'Anular Egresos','Gestionar Egresos')," +
                        "(23,'Gestionar Ajustes del Sistema','Gestionar Ajustes del Sistema')," +
                        "(24,'Configurar Conexión de base de datos','Gestionar Ajustes del Sistema')," +
                        "(25,'Importar base de datos','Gestionar Ajustes del Sistema')," +
                        "(26,'Exportar base de datos','Gestionar Ajustes del Sistema')"
                        , _con, _trans);

                    if (cmdInsertUsuarioEmp.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    List<Permiso> permisos = PermisoDAL.getPermisos();
                    foreach(Permiso obj in permisos)
                    {
                        MySqlCommand cmdInsertLstPermiso = new MySqlCommand("Insert into lstpermiso values (null,CURRENT_TIMESTAMP,1,@Permiso,@AcsSucursal)", _con, _trans);
                        cmdInsertContrato.Parameters.AddWithValue("@Permiso", obj.Id);
                        cmdInsertContrato.Parameters.AddWithValue("@AcsSucursal", item.Sucursales[0].Id);
                        if (cmdInsertCargos.ExecuteNonQuery() <= 0)
                        {
                            result = false;
                        }
                    }
                    MySqlCommand cmdInsertLstPermisoRol1 = new MySqlCommand("Insert into lstpermisorol values " +
                        "(null,CURRENT_TIMESTAMP,1,1)," +
                        "(null,CURRENT_TIMESTAMP,1,2)," +
                        "(null,CURRENT_TIMESTAMP,1,3)," +
                        "(null,CURRENT_TIMESTAMP,1,4)," +
                        "(null,CURRENT_TIMESTAMP,1,5)," +
                        "(null,CURRENT_TIMESTAMP,1,6)," +
                        "(null,CURRENT_TIMESTAMP,1,7)," +
                        "(null,CURRENT_TIMESTAMP,1,8)," +
                        "(null,CURRENT_TIMESTAMP,1,9)," +
                        "(null,CURRENT_TIMESTAMP,1,10)," +
                        "(null,CURRENT_TIMESTAMP,1,11)," +
                        "(null,CURRENT_TIMESTAMP,1,12)," +
                        "(null,CURRENT_TIMESTAMP,1,13)," +
                        "(null,CURRENT_TIMESTAMP,1,14)," +
                        "(null,CURRENT_TIMESTAMP,1,15)," +
                        "(null,CURRENT_TIMESTAMP,1,16)," +
                        "(null,CURRENT_TIMESTAMP,1,17)," +
                        "(null,CURRENT_TIMESTAMP,1,18)," +
                        "(null,CURRENT_TIMESTAMP,1,19)," +
                        "(null,CURRENT_TIMESTAMP,1,20)," +
                        "(null,CURRENT_TIMESTAMP,1,21)," +
                        "(null,CURRENT_TIMESTAMP,1,22)," +
                        "(null,CURRENT_TIMESTAMP,1,23)," +
                        "(null,CURRENT_TIMESTAMP,1,24)," +
                        "(null,CURRENT_TIMESTAMP,1,25)," +
                        "(null,CURRENT_TIMESTAMP,1,26)" 
                        , _con, _trans);
                    if (cmdInsertLstPermisoRol1.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    MySqlCommand cmdInsertLstPermisoRol2 = new MySqlCommand("Insert into lstpermisorol values "+
                        "(null,CURRENT_TIMESTAMP,2,1)," +
                        "(null,CURRENT_TIMESTAMP,2,2)," +
                        "(null,CURRENT_TIMESTAMP,2,3)," +
                        "(null,CURRENT_TIMESTAMP,2,4)," +
                        "(null,CURRENT_TIMESTAMP,2,5)," +
                        "(null,CURRENT_TIMESTAMP,2,6)," +
                        "(null,CURRENT_TIMESTAMP,2,7)," +
                        "(null,CURRENT_TIMESTAMP,2,8)," +
                        "(null,CURRENT_TIMESTAMP,2,9)," +
                        "(null,CURRENT_TIMESTAMP,2,11)," +
                        "(null,CURRENT_TIMESTAMP,2,12)," +
                        "(null,CURRENT_TIMESTAMP,2,13)," +
                        "(null,CURRENT_TIMESTAMP,2,15)," +
                        "(null,CURRENT_TIMESTAMP,2,16)," +
                        "(null,CURRENT_TIMESTAMP,2,18)," +
                        "(null,CURRENT_TIMESTAMP,2,19)," +
                        "(null,CURRENT_TIMESTAMP,2,20)," +
                        "(null,CURRENT_TIMESTAMP,2,21)," +
                        "(null,CURRENT_TIMESTAMP,2,22)," +
                        "(null,CURRENT_TIMESTAMP,2,23)"
                        , _con, _trans);
                    if (cmdInsertLstPermisoRol2.ExecuteNonQuery() <= 0)
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
        public static bool UpdateUserEmp(Useremp item,string opc,Useremp pUser)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {
                    MySqlCommand cmdUpdateUserEmp = null;
                    MySqlCommand cmdInsertAuditoria = null;
                    switch (opc)
                    {
                        case "pwd":
                            cmdUpdateUserEmp = new MySqlCommand("update useremp set Pass=md5(@Pass) where Id=@Id;", _con, _trans);
                            cmdUpdateUserEmp.Parameters.AddWithValue("@Pass", item.Pass);
                            cmdUpdateUserEmp.Parameters.AddWithValue("@Id", item.Id);
                            if (cmdUpdateUserEmp.ExecuteNonQuery() <= 0)
                            {
                                result = false;
                            }
                            cmdInsertAuditoria = new MySqlCommand("Insert into regemphist (Detalle,Accion,TipoRegistro,IdUserEmp) values (@Detalle,@Accion,@TipoRegistro,@IdUserEmp)", _con, _trans);
                            cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Actualizó la contraseña para el usuario con Id \""+item.Id+"\", Login \""+item.Login+"\".");
                            cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Actualización de contraseña");
                            cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Usuario");
                            cmdInsertAuditoria.Parameters.AddWithValue("@IdUserEmp", pUser.Id);
                            if (cmdInsertAuditoria.ExecuteNonQuery() <= 0)
                            {
                                result = false;
                            }
                            break;
                        case "all":
                            if (item.Pass=="")
                            {
                                cmdUpdateUserEmp = new MySqlCommand("update useremp set Login=@Login,Estado=@Estado,IdContrato=@IdContrato where Id=@Id;", _con, _trans);
                                cmdUpdateUserEmp.Parameters.AddWithValue("@Login", item.Login);
                                cmdUpdateUserEmp.Parameters.AddWithValue("@IdContrato", item.IdContrato);
                                cmdUpdateUserEmp.Parameters.AddWithValue("@Estado", item.Estado);
                                cmdUpdateUserEmp.Parameters.AddWithValue("@Id", item.Id);
                                if (cmdUpdateUserEmp.ExecuteNonQuery() <= 0)
                                {
                                    result = false;
                                }
                                cmdInsertAuditoria = new MySqlCommand("Insert into regemphist (Detalle,Accion,TipoRegistro,IdUserEmp) values (@Detalle,@Accion,@TipoRegistro,@IdUserEmp)", _con, _trans);
                                cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Actualizó la información para el usuario con Id \"" + item.Id + "\", Login \"" + item.Login + "\".");
                                cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Actualización de información");
                                cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Usuario");
                                cmdInsertAuditoria.Parameters.AddWithValue("@IdUserEmp", pUser.Id);
                                if (cmdInsertAuditoria.ExecuteNonQuery() <= 0)
                                {
                                    result = false;
                                }
                            }
                            else
                            {
                                cmdUpdateUserEmp = new MySqlCommand("update useremp set Login=@Login,Estado=@Estado,IdContrato=@IdContrato,Pass=md5(@Pass) where Id=@Id;", _con, _trans);
                                cmdUpdateUserEmp.Parameters.AddWithValue("@Login", item.Login);
                                cmdUpdateUserEmp.Parameters.AddWithValue("@IdContrato", item.IdContrato);
                                cmdUpdateUserEmp.Parameters.AddWithValue("@Pass", item.Pass);
                                cmdUpdateUserEmp.Parameters.AddWithValue("@Estado", item.Estado);
                                cmdUpdateUserEmp.Parameters.AddWithValue("@Id", item.Id);
                                if (cmdUpdateUserEmp.ExecuteNonQuery() <= 0)
                                {
                                    result = false;
                                }
                                cmdInsertAuditoria = new MySqlCommand("Insert into regemphist (Detalle,Accion,TipoRegistro,IdUserEmp) values (@Detalle,@Accion,@TipoRegistro,@IdUserEmp)", _con, _trans);
                                cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Actualizó la información para el usuario con Id \"" + item.Id + "\", Login \"" + item.Login + "\".");
                                cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Actualización de información y contraseña");
                                cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Usuario");
                                cmdInsertAuditoria.Parameters.AddWithValue("@IdUserEmp", pUser.Id);
                                if (cmdInsertAuditoria.ExecuteNonQuery() <= 0)
                                {
                                    result = false;
                                }
                            }
                            foreach(AcsSucursal suc in item.Sucursales)
                            {
                                foreach (LstPermiso obj in suc.Permisos)
                                {
                                    if (obj.Id==0)
                                    {
                                        cmdUpdateUserEmp = new MySqlCommand("insert into lstpermiso(null,null,@Otorgado,@IdPermiso,@IdAcsSucursal);", _con, _trans);
                                        cmdUpdateUserEmp.Parameters.AddWithValue("@Otorgado", obj.Otorgado?1:0);
                                        cmdUpdateUserEmp.Parameters.AddWithValue("@IdPermiso", obj.IdPermiso);
                                        cmdUpdateUserEmp.Parameters.AddWithValue("@IdAcsSucursal", suc.Id);
                                        if (cmdUpdateUserEmp.ExecuteNonQuery() <= 0)
                                        {
                                            result = false;
                                        }
                                        cmdInsertAuditoria = new MySqlCommand("Insert into regemphist (Detalle,Accion,TipoRegistro,IdUserEmp) values (@Detalle,@Accion,@TipoRegistro,@IdUserEmp)", _con, _trans);
                                        cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Se inserto un permiso con Id \"" + obj.Id + "\" descripción \""+obj.Permiso.Nombre+"\" al Login \"" + item.Login + "\".");
                                        cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Inserción de Permiso");
                                        cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Permiso");
                                        cmdInsertAuditoria.Parameters.AddWithValue("@IdUserEmp", pUser.Id);
                                        if (cmdInsertAuditoria.ExecuteNonQuery() <= 0)
                                        {
                                            result = false;
                                        }
                                    }
                                    else
                                    {
                                        cmdUpdateUserEmp = new MySqlCommand("update lstpermiso set Otorgado=@Otorgado where Id=@Id;", _con, _trans);
                                        cmdUpdateUserEmp.Parameters.AddWithValue("@Otorgado", obj.Otorgado?1:0);
                                        cmdUpdateUserEmp.Parameters.AddWithValue("@Id", obj.Id);
                                        if (cmdUpdateUserEmp.ExecuteNonQuery() <= 0)
                                        {
                                            result = false;
                                        }
                                        if (LstPermisoDAL.getLstPermisoById(obj.Id).Otorgado!=obj.Otorgado)
                                        {
                                            cmdInsertAuditoria = new MySqlCommand("Insert into regemphist (Detalle,Accion,TipoRegistro,IdUserEmp) values (@Detalle,@Accion,@TipoRegistro,@IdUserEmp)", _con, _trans);
                                            cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Se actualizó el registro de lstpermiso con Id \"" + obj.Id + "\" del permiso con descripción \"" + obj.Permiso.Nombre + "\" al Login \"" + item.Login + "\" .");
                                            cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Actualización de Permisos");
                                            cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Permiso");
                                            cmdInsertAuditoria.Parameters.AddWithValue("@IdUserEmp", pUser.Id);
                                            if (cmdInsertAuditoria.ExecuteNonQuery() <= 0)
                                            {
                                                result = false;
                                            }
                                        }
                                        
                                    }
                                }
                            }
                            if (cmdUpdateUserEmp.ExecuteNonQuery() <= 0)
                            {
                                result = false;
                            }
                            break;
                        default:
                            break;
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
