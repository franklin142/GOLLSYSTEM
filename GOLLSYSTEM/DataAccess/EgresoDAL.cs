using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace GOLLSYSTEM.DataAccess
{
    public class EgresoDAL
    {
        public static Egreso getEgresoById(Int64 pId)
        {
            Egreso item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from egreso where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Egreso(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetDecimal(4),
                            _reader.GetString(5),
                            _reader.GetInt64(6)
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
        public static List<List<Int64>> getIdsEgresosNoParametro(string pText, Int64 pIdSucursal, int pLimit)
        {
            List<List<Int64>> lista = new List<List<Int64>>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from egreso where (Upper(Nombre) like '%" + pText.ToUpper() + "%' or Upper(Tipo) like '%" + pText.ToUpper() +
                        "%') and IdSucursal=@pIdSucursal and Estado='C' order by Id desc", _con);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        if (lista.Count == 0)
                        {
                            lista.Add(new List<Int64>());
                        }
                        if (lista[lista.Count - 1].Count == pLimit)
                        {
                            lista.Add(new List<Int64>());
                            lista[lista.Count - 1].Add(1);
                        }
                        else
                        {
                            lista[lista.Count - 1].Add(1);
                        }
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
        public static List<List<Int64>> getIdsEgresosByParametro(Int64 pYear, string pMonth, string pText, Int64 pIdSucursal, int pLimit)
        {
            List<List<Int64>> lista = new List<List<Int64>>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select count(Id) from egreso where (Upper(Nombre) like '%" + pText.ToUpper() + "%' or Upper(Tipo) like '%" + pText.ToUpper() +
                        "%') and (YEAR(FhRegistro)=@pYear and MONTH(FhRegistro)=@pMonth and IdSucursal=@pIdSucursal) and Estado='C' order by Id desc", _con);
                    comando.Parameters.AddWithValue("@pYear", pYear);
                    comando.Parameters.AddWithValue("@pMonth", pMonth);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);
                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        for (int i = 0; i < _reader.GetInt64(0); i++)
                        {
                            if (lista.Count == 0)
                            {
                                lista.Add(new List<Int64>());
                            }
                            if (lista[lista.Count - 1].Count == pLimit)
                            {
                                lista.Add(new List<Int64>());
                                lista[lista.Count - 1].Add(i);
                            }
                            else
                            {
                                lista[lista.Count - 1].Add(i);
                            }
                        }

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
        public static decimal getTotalEgresoNoParametro(string pText, Int64 pIdSucursal, int pLimit)
        {
            decimal item = 0;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select sum(Total) from egreso where (IdSucursal=@pIdSucursal and Estado='C') order by Id asc", _con);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = _reader.IsDBNull(0) ? 0 : _reader.GetDecimal(0);
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
        public static decimal getTotalEgresoByParametro(Int64 pYear, string pMonth, string pText, Int64 pIdSucursal, int pLimit)
        {
            decimal item = 0;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select sum(Total) from egreso where (YEAR(FhRegistro)=@pYear and MONTH(FhRegistro)=@pMonth and IdSucursal=@pIdSucursal and Estado='C') order by Id asc", _con);
                    comando.Parameters.AddWithValue("@pYear", pYear);
                    comando.Parameters.AddWithValue("@pMonth", pMonth);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);

                    comando.Parameters.AddWithValue("@pLimit", pLimit);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = _reader.IsDBNull(0) ? 0 : _reader.GetDecimal(0);

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
        public static List<Egreso> getEgresosIndexerNoParametro(string pText, Int64 pIdSucursal, Int64 pNumber1, Int64 pNumber2)
        {
            List<Egreso> lista = new List<Egreso>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from egreso where (Upper(Nombre) like '%" + pText.ToUpper() + "%' or Upper(Tipo) like '%" + pText.ToUpper() +
                        "%') and IdSucursal=@pIdSucursal and Estado='C' order by Id desc limit @pNumber1,@pNumber2", _con);
                    comando.Parameters.AddWithValue("@pNumber1", pNumber1);
                    comando.Parameters.AddWithValue("@pNumber2", pNumber2);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Egreso item = new Egreso(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetDecimal(4),
                            _reader.GetString(5),
                            _reader.GetInt64(6)
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
        public static List<string> getNameEgresos(Int64 pIdSucursal)
        {
            List<string> lista = new List<string>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select distinct Nombre from egreso where IdSucursal=@pIdSucursal order by Nombre desc ", _con);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);
                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        lista.Add(_reader.GetString(0));
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

        public static List<Egreso> getEgresosIndexerParametro(Int64 pYear, string pMonth, string pText, Int64 pIdSucursal, Int64 pNumber1, Int64 pNumber2)
        {
            List<Egreso> lista = new List<Egreso>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from egreso where (Upper(Nombre) like '%" + pText.ToUpper() + "%' or Upper(Tipo) like '%" + pText.ToUpper() +
                        "%') and (YEAR(FhRegistro)=@pYear and MONTH(FhRegistro)=@pMonth and IdSucursal=@pIdSucursal) and Estado='C' order by Id desc limit @pNumber1,@pNumber2", _con);
                    comando.Parameters.AddWithValue("@pNumber1", pNumber1 == 0 ? pNumber1 : pNumber1 * pNumber2);
                    comando.Parameters.AddWithValue("@pNumber2", pNumber2);
                    comando.Parameters.AddWithValue("@pYear", pYear);
                    comando.Parameters.AddWithValue("@pMonth", pMonth);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Egreso item = new Egreso(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetDecimal(4),
                            _reader.GetString(5),
                            _reader.GetInt64(6)
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
        public static List<List<List<Egreso>>> getEgresosSemanas(Int64 pYear, string pMonth, string pText, Int64 pIdSucursal)
        {
            List<Egreso> lista = new List<Egreso>();
            List<List<List<Egreso>>> semanasList = new List<List<List<Egreso>>>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from egreso where (Upper(Nombre) like '%" + pText.ToUpper() + "%' or Upper(Tipo) like '%" + pText.ToUpper() +
                        "%') and (YEAR(FhRegistro)=@pYear and MONTH(FhRegistro)=@pMonth and IdSucursal=@pIdSucursal) and Estado='C' order by Id desc", _con);
                    comando.Parameters.AddWithValue("@pYear", pYear);
                    comando.Parameters.AddWithValue("@pMonth", pMonth);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);

                    MySqlDataReader _reader = comando.ExecuteReader();


                    while (_reader.Read())
                    {
                        Egreso item = new Egreso(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetDecimal(4),
                            _reader.GetString(5),
                            _reader.GetInt64(6)
                            );

                        lista.Add(item);

                    }

                    DateTime date1 = new DateTime(Convert.ToInt32(pYear), Convert.ToInt32(pMonth), 1);
                    DateTime date2 = new DateTime((Convert.ToInt32(pMonth) < 12 ? Convert.ToInt32(pYear) : Convert.ToInt32(pYear) + 1), (Convert.ToInt32(pMonth) < 12 ? Convert.ToInt32(pMonth) + 1 : 1), 1).AddDays(-1);
                    List<List<int>> semanasArray = new List<List<int>>();
                    semanasArray.Add(new List<int>());
                    int currentWeek = 0;
                    for (int i = 0; i < date2.Day; i++)
                    {
                        if (new DateTime(Convert.ToInt32(pYear), Convert.ToInt32(pMonth), date1.Day + i).ToString("dddd", new CultureInfo("es-ES")).ToLower() == "domingo")
                        {
                            semanasArray[currentWeek].Add(i + 1);
                            semanasArray.Add(new List<int>());
                            currentWeek++;
                        }
                        else
                        {
                            semanasArray[currentWeek].Add(i + 1);
                        }
                    }
                    if (semanasArray.Last().Count == 0)
                    {
                        semanasArray.Remove(semanasArray.Last());
                    }
                    int daymonth = 1;
                    for (int s = 0; s < semanasArray.Count; s++)
                    {
                        semanasList.Add(new List<List<Egreso>>());
                        for (int d = 0; d < semanasArray[s].Count; d++)
                        {
                            semanasList[s].Add(new List<Egreso>());
                            foreach (Egreso fact in lista.Where(a => Convert.ToDateTime(a.FhRegistro).Day == daymonth))
                            {
                                semanasList[s][d].Add(fact);
                            }
                            daymonth++;

                        }

                    }

                    /*int semanas = Convert.ToInt32(Math.Truncate((decimal)date2.Day / 7));
                    for (int i = 0; i < semanas; i++)
                    {
                        semanasList.Add(new List<List<Factura>>());
                        for (int d = i*7; d <((i + 1) * 7);d++)
                        {
                            semanasList[i].Add(new List<Factura>());
                            foreach (Factura fact in lista.Where(a => Convert.ToDateTime(a.FhRegistro).Day == d+1))
                            {
                                semanasList[i][(((d+1)-(i*7))-1)].Add(fact);
                            }
                        }
                       
                    }*/

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
            return semanasList;
        }

        public static bool insertEgreso(Egreso item, Useremp pUser)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {

                    MySqlCommand cmdInsertEgreso = new MySqlCommand("Insert into egreso (FhRegistro,Tipo,Nombre,Total,Estado,IdSucursal) values (@FhRegistro,@Tipo,@Nombre,@Total,@Estado,@IdSucursal)", _con, _trans);
                    if (item.Id != 0)
                    {
                        cmdInsertEgreso = new MySqlCommand("Update egreso set FhRegistro=@FhRegistro,Tipo=@Tipo,Nombre=@Nombre,Total=@Total where Id=@Id", _con, _trans);
                        cmdInsertEgreso.Parameters.AddWithValue("@FhRegistro", item.FhRegistro);
                        cmdInsertEgreso.Parameters.AddWithValue("@Tipo", item.Tipo);
                        cmdInsertEgreso.Parameters.AddWithValue("@Nombre", item.Nombre);
                        cmdInsertEgreso.Parameters.AddWithValue("@Total", item.Total);
                        cmdInsertEgreso.Parameters.AddWithValue("@Id", item.Id);

                    }
                    else
                    {
                        cmdInsertEgreso.Parameters.AddWithValue("@FhRegistro", item.FhRegistro);
                        cmdInsertEgreso.Parameters.AddWithValue("@Tipo", item.Tipo);
                        cmdInsertEgreso.Parameters.AddWithValue("@Nombre", item.Nombre);
                        cmdInsertEgreso.Parameters.AddWithValue("@Total", item.Total);
                        cmdInsertEgreso.Parameters.AddWithValue("@Estado", "C");
                        cmdInsertEgreso.Parameters.AddWithValue("@IdSucursal", item.IdSucursal);
                    }

                    if (cmdInsertEgreso.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }

                    if (result)
                    {
                        MySqlCommand cmdInsertAuditoria = new MySqlCommand("Insert into regemphist (Detalle,Accion,TipoRegistro,IdUserEmp) values (@Detalle,@Accion,@TipoRegistro,@IdUserEmp)", _con, _trans);
                        cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Registró el egreso con \"Nombre " + item.Nombre + "\" de \"Tipo " + item.Tipo + "\" y con total de $" + item.Total + ".");
                        cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Registrar Egreso");
                        cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Egreso");
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
        public static bool anularEgreso(Int64 pIdEgreso, bool isParent, Useremp pUser)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {

                    MySqlCommand cmdUpdateContrato = new MySqlCommand("update egreso set Estado='A' where Id=@pIdEgreso ", _con, _trans);
                    cmdUpdateContrato.Parameters.AddWithValue("@pIdEgreso", pIdEgreso);
                    if (cmdUpdateContrato.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }


                    if (result)
                    {
                        MySqlCommand cmdInsertAuditoria = new MySqlCommand("Insert into regemphist (Detalle,Accion,TipoRegistro,IdUserEmp) values (@Detalle,@Accion,@TipoRegistro,@IdUserEmp)", _con, _trans);
                        cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Anuló el egreso con \"Nombre " + EgresoDAL.getEgresoById(pIdEgreso).Nombre + "\" con total de $" + EgresoDAL.getEgresoById(pIdEgreso).Total + ".");
                        cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Anular Egreso");
                        cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Egreso");
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
