using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class FacturaDAL
    {
        public static Factura getFacturaById(Int64 pId)
        {
            Factura item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from factura where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Factura(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetDecimal(4),
                            _reader.GetString(5),
                            _reader.GetInt64(6),
                            _reader.GetInt64(7),
                            DetFacturaDAL.getDetsfacturaByIdFactura(_reader.GetInt64(0))

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
        public static List<Factura> searchFacturasByParametro(Int64 pYear, string pMonth, string pText, Int64 pIdSucursal, int pLimit)
        {
            List<Factura> lista = new List<Factura>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select distinct f.* from producto as prod right join detfactura as df on df.IdProducto=prod.Id " +
                        " right join factura as f on f.Id=df.IdFactura right join persona as per on per.Id=f.IdPersona where (per.Nombre like '%" + pText + "%' or " +
                        "prod.Nombre like '%" + pText + "%' or df.Concepto like '%" + pText + "%' or df.Total like '%" + pText + "%' or " +
                        "f.Total like '%" + pText + "%' or f.Observacion or f.NFactura like '%" + pText + "%'" +
                        ") and (YEAR(f.FhRegistro)=@pYear and MONTH(f.FhRegistro)=@pMonth and f.IdSucursal=@pIdSucursal) and f.Estado='C' order by f.Id asc", _con);
                    comando.Parameters.AddWithValue("@pYear", pYear);
                    comando.Parameters.AddWithValue("@pMonth", pMonth);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);
                    comando.Parameters.AddWithValue("@pLimit", pLimit);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Factura item = new Factura(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetDecimal(4),
                            _reader.GetString(5),
                            _reader.GetInt64(6),
                            _reader.GetInt64(7),
                            DetFacturaDAL.getDetsfacturaByIdFactura(_reader.GetInt64(0))
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
        public static List<Factura> searchEgresoNoParametro(string pText, Int64 pIdSucursal, int pLimit)
        {
            List<Factura> lista = new List<Factura>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select distinct f.* from producto as prod right join detfactura as df on df.IdProducto=prod.Id " +
                        " right join factura as f on f.Id=df.Id right join persona as per on per.Id=f.IdPersona where (per.Nombre like '%" + pText + "%' or " +
                        "prod.Nombre like '%" + pText + "%' or df.Concepto like '%" + pText + "%' or df.Total like '%" + pText + "%' or " +
                        "f.Total like '%" + pText + "%' or f.Observacion or f.NFactura like '%" + pText + "%'" +
                        ") and f.IdSucursal=@pIdSucursal and f.Estado='C' order by f.Id asc", _con);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);
                    comando.Parameters.AddWithValue("@pLimit", pLimit);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Factura item = new Factura(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetDecimal(4),
                            _reader.GetString(5),
                            _reader.GetInt64(6),
                            _reader.GetInt64(7),
                            DetFacturaDAL.getDetsfacturaByIdFactura(_reader.GetInt64(0))
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
        public static List<List<Int64>> getIdsEgresoNoParametro(string pText, Int64 pIdSucursal, int pLimit)
        {
            List<List<Int64>> lista = new List<List<Int64>>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select distinct count(f.Id) from producto as prod right join detfactura as df on df.IdProducto=prod.Id " +
                        " right join factura as f on f.Id=df.Id right join persona as per on per.Id=f.IdPersona where (per.Nombre like '%" + pText + "%' or " +
                        "prod.Nombre like '%" + pText + "%' or df.Concepto like '%" + pText + "%' or df.Total like '%" + pText + "%' or " +
                        "f.Total like '%" + pText + "%' or f.Observacion or f.NFactura like '%" + pText + "%'" +
                        ") and f.IdSucursal=@pIdSucursal and f.Estado='C' order by f.NFactura desc", _con);
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
        public static List<List<Int64>> getIdsFacturasByParametro(Int64 pYear, string pMonth, string pText, Int64 pIdSucursal, int pLimit)
        {
            List<List<Int64>> lista = new List<List<Int64>>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select distinct Count(f.Id) from producto as prod right join detfactura as df on df.IdProducto=prod.Id " +
                        " right join factura as f on f.Id=df.IdFactura right join persona as per on per.Id=f.IdPersona where (per.Nombre like '%" + pText + "%' or " +
                        "prod.Nombre like '%" + pText + "%' or df.Concepto like '%" + pText + "%' or df.Total like '%" + pText + "%' or " +
                        "f.Total like '%" + pText + "%' or f.Observacion or f.NFactura like '%" + pText + "%'" +
                        ") and (YEAR(f.FhRegistro)=@pYear and MONTH(f.FhRegistro)=@pMonth and f.IdSucursal=@pIdSucursal) and f.Estado='C' order by f.NFactura desc", _con);
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
        public static decimal getTotalFacturasByParametro(Int64 pYear, string pMonth, string pText, Int64 pIdSucursal, int pLimit)
        {
            decimal item = 0;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select sum(df.Total)-SUM(df.Descuento) from producto as prod right join detfactura as df on df.IdProducto=prod.Id " +
                        " right join factura as f on f.Id=df.IdFactura right join persona as per on per.Id=f.IdPersona where (per.Nombre like '%" + pText + "%' or " +
                        "prod.Nombre like '%" + pText + "%' or df.Concepto like '%" + pText + "%' or df.Total like '%" + pText + "%' or " +
                        "f.Total like '%" + pText + "%' or f.Observacion or f.NFactura like '%" + pText + "%'" +
                        ") and (YEAR(f.FhRegistro)=@pYear and MONTH(f.FhRegistro)=@pMonth and f.IdSucursal=@pIdSucursal) and f.Estado='C' order by f.NFactura desc", _con);
                    comando.Parameters.AddWithValue("@pYear", pYear);
                    comando.Parameters.AddWithValue("@pMonth", pMonth);
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
        public static decimal getTotalFacturasNoParametro(string pText, Int64 pIdSucursal, int pLimit)
        {
            decimal item = 0;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select sum(df.Total)-SUM(df.Descuento) from producto as prod right join detfactura as df on df.IdProducto=prod.Id " +
                        " right join factura as f on f.Id=df.Id right join persona as per on per.Id=f.IdPersona where (per.Nombre like '%" + pText + "%' or " +
                        "prod.Nombre like '%" + pText + "%' or df.Concepto like '%" + pText + "%' or df.Total like '%" + pText + "%' or " +
                        "f.Total like '%" + pText + "%' or f.Observacion or f.NFactura like '%" + pText + "%'" +
                        ") and f.IdSucursal=@pIdSucursal and f.Estado='C' order by f.Id asc", _con);
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

        public static List<Factura> getFacturasIndexerNoParametro(string pText, Int64 pIdSucursal, Int64 pNumber1, Int64 pNumber2)
        {
            List<Factura> lista = new List<Factura>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select distinct f.* from producto as prod right join detfactura as df on df.IdProducto=prod.Id " +
                        " right join factura as f on f.Id=df.IdFactura right join persona as per on per.Id=f.IdPersona where (per.Nombre like '%" + pText + "%' or " +
                        "prod.Nombre like '%" + pText + "%' or df.Concepto like '%" + pText + "%' or df.Total like '%" + pText + "%' or " +
                        "f.Total like '%" + pText + "%' or f.Observacion or f.NFactura like '%" + pText + "%'" +
                        ") and ( and f.IdSucursal=@pIdSucursal) and f.Estado='C' order by f.NFactura desc limit @pNumber1,@pNumber2", _con);
                    comando.Parameters.AddWithValue("@pNumber1", pNumber1);
                    comando.Parameters.AddWithValue("@pNumber2", pNumber2);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Factura item = new Factura(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetDecimal(4),
                            _reader.GetString(5),
                            _reader.GetInt64(6),
                            _reader.GetInt64(7),
                            DetFacturaDAL.getDetsfacturaByIdFactura(_reader.GetInt64(0))
                            );

                        lista.Add(item);

                    }
                    _reader.Close();
                }
                catch (Exception ex)
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
        public static List<Factura> getFacturasIndexerParametro(Int64 pYear, string pMonth, string pText, Int64 pIdSucursal, Int64 pNumber1, Int64 pNumber2)
        {
            List<Factura> lista = new List<Factura>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select distinct f.* from producto as prod right join detfactura as df on df.IdProducto=prod.Id " +
                        " right join factura as f on f.Id=df.IdFactura right join persona as per on per.Id=f.IdPersona where (per.Nombre like '%" + pText + "%' or " +
                        "prod.Nombre like '%" + pText + "%' or df.Concepto like '%" + pText + "%' or df.Total like '%" + pText + "%' or " +
                        "f.Total like '%" + pText + "%' or f.Observacion or f.NFactura like '%" + pText + "%'" +
                        ") and (YEAR(f.FhRegistro)=@pYear and MONTH(f.FhRegistro)=@pMonth and f.IdSucursal=@pIdSucursal) and f.Estado='C' order by f.NFactura desc limit @pNumber1,@pNumber2", _con);
                    comando.Parameters.AddWithValue("@pNumber1", pNumber1 == 0 ? pNumber1 : pNumber1 * pNumber2);
                    comando.Parameters.AddWithValue("@pNumber2", pNumber2);
                    comando.Parameters.AddWithValue("@pYear", pYear);
                    comando.Parameters.AddWithValue("@pMonth", pMonth);
                    comando.Parameters.AddWithValue("@pIdSucursal", pIdSucursal);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Factura item = new Factura(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetString(2),
                            _reader.GetString(3),
                            _reader.GetDecimal(4),
                            _reader.GetString(5),
                            _reader.GetInt64(6),
                            _reader.GetInt64(7),
                            DetFacturaDAL.getDetsfacturaByIdFactura(_reader.GetInt64(0))
                            );

                        lista.Add(item);

                    }
                    _reader.Close();
                }
                catch (Exception ex)
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

        public static bool insertFactura(Factura item, Useremp pUser)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {

                    MySqlCommand cmdCorrelativoNfactura = new MySqlCommand("select CONCAT(DATE_FORMAT(CURRENT_DATE(), '%Y%m'),lpad(coalesce(max(FORMAT(CONVERT(SUBSTRING(NFactura,7),int),'####'))+1,1),4,'0'))from factura where SUBSTRING(NFactura,1,6)=CONVERT(DATE_FORMAT(now(), '%Y%m'),char);", _con, _trans);
                    item.NFactura = Convert.ToString(cmdCorrelativoNfactura.ExecuteScalar());

                    MySqlCommand cmdInsertFactura = new MySqlCommand("Insert into factura (Nfactura,Observacion,Total,Estado,IdPersona,IdSucursal) values (@Nfactura,@Observacion,@Total,@Estado,@IdPersona,@IdSucursal)", _con, _trans);
                    cmdInsertFactura.Parameters.AddWithValue("@Nfactura", item.NFactura);
                    cmdInsertFactura.Parameters.AddWithValue("@Observacion", item.Observacion);
                    cmdInsertFactura.Parameters.AddWithValue("@Total", item.Total);
                    cmdInsertFactura.Parameters.AddWithValue("@Estado", "C");
                    cmdInsertFactura.Parameters.AddWithValue("@IdPersona", item.IdPersona);
                    cmdInsertFactura.Parameters.AddWithValue("@IdSucursal", item.IdSucursal);

                    if (cmdInsertFactura.ExecuteNonQuery() <= 0)
                    {
                        result = false;
                    }
                    else
                    {
                        MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                        cmdUltimoId.Transaction = _trans;
                        item.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                    }
                    foreach (Detfactura det in item.DetsFactura)
                    {

                        if (det.Tipo == "M")
                        {
                            Cuota cuota = CuotaDAL.getCuotaById(det.Matricdetfac.IdCuota);

                            MySqlCommand cmdInsertDetFactura = new MySqlCommand("Insert into detfactura (Concepto,Total,Descuento,Tipo,IdFactura,IdProducto) values (@Concepto,@Total,@Descuento,@Tipo,@IdFactura,@IdProducto)", _con, _trans);
                            cmdInsertDetFactura.Parameters.AddWithValue("@Concepto", det.Producto.Nombre);
                            cmdInsertDetFactura.Parameters.AddWithValue("@Total", det.Total);
                            cmdInsertDetFactura.Parameters.AddWithValue("@Descuento", det.Descuento);
                            cmdInsertDetFactura.Parameters.AddWithValue("@Tipo", det.Tipo);
                            cmdInsertDetFactura.Parameters.AddWithValue("@IdFactura", item.Id);
                            cmdInsertDetFactura.Parameters.AddWithValue("@IdProducto", det.IdProducto);

                            if (cmdInsertDetFactura.ExecuteNonQuery() <= 0)
                            {
                                result = false;
                            }
                            else
                            {
                                MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                                cmdUltimoId.Transaction = _trans;
                                det.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                            }

                            MySqlCommand cmdInsertMatricDetFact = new MySqlCommand("Insert into matricdetfact (IdDetFactura,IdCuota) values (@IdDetFactura,@IdCuota)", _con, _trans);
                            cmdInsertMatricDetFact.Parameters.AddWithValue("@IdDetFactura", det.Id);
                            cmdInsertMatricDetFact.Parameters.AddWithValue("@IdCuota", det.Matricdetfac.IdCuota);

                            if (cmdInsertMatricDetFact.ExecuteNonQuery() <= 0)
                            {
                                result = false;
                            }
                            else
                            {
                                MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                                cmdUltimoId.Transaction = _trans;
                                det.Matricdetfac.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
                                det.Matricdetfac.IdDetFactura = det.Id;
                            }
                            MySqlCommand cmdUpdateCuota = new MySqlCommand("update cuota set Total=@pTotal where Id=@Id", _con, _trans);
                            cmdUpdateCuota.Parameters.AddWithValue("@Id", det.Matricdetfac.IdCuota);
                            cmdUpdateCuota.Parameters.AddWithValue("@pTotal", det.Total + cuota.Total);
                            if (cmdUpdateCuota.ExecuteNonQuery() <= 0)
                            {
                                result = false;
                            }
                        }
                        if (det.Tipo == "F")
                        {
                            MySqlCommand cmdInsertDetFactura = new MySqlCommand("Insert into detfactura (Concepto,Total,Descuento,Tipo,IdFactura,IdProducto) values (@Concepto,@Total,@Descuento,@Tipo,@IdFactura,@IdProducto)", _con, _trans);
                            cmdInsertDetFactura.Parameters.AddWithValue("@Concepto", det.Concepto);
                            cmdInsertDetFactura.Parameters.AddWithValue("@Total", det.Total);
                            cmdInsertDetFactura.Parameters.AddWithValue("@Descuento", det.Descuento);
                            cmdInsertDetFactura.Parameters.AddWithValue("@Tipo", det.Tipo);
                            cmdInsertDetFactura.Parameters.AddWithValue("@IdFactura", item.Id);
                            cmdInsertDetFactura.Parameters.AddWithValue("@IdProducto", det.IdProducto);

                            if (cmdInsertDetFactura.ExecuteNonQuery() <= 0)
                            {
                                result = false;
                            }
                            else
                            {
                                MySqlCommand cmdUltimoId = new MySqlCommand("select last_insert_id() as id;", _con);
                                cmdUltimoId.Transaction = _trans;
                                det.Id = Convert.ToInt32(cmdUltimoId.ExecuteScalar());
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

    }
}
