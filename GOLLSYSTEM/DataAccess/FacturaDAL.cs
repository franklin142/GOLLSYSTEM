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
                            _reader.GetInt64(8),
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
        public static List<Factura> searchFacturasByParametro(string pYear, string pMonth, string pText,int pIdSucursal, int pLimit)
        {
            List<Factura> lista = new List<Factura>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select distinct f.* from producto as prod inner join detfactura as df in df.IdProducto=prod.Id "+
                        " inner join factura as f on f.Id=df.Id inner join persona as per on per.Id=f.IdPersona where (per.Nombre like '%" + pText + "%' or "+
                        "prod.Nombre like '%" + pText + "%' or df.Concepto like '%" + pText + "%' or df.Total like '%" + pText + "%' or "+
                        "f.Total like '%" + pText + "%' or f.Observacion or f.NFactura like '%" + pText + "%'" +
                        ") and (YEAR(f.FhRegistro)=@pYear and MONTH(f.FhRegistro)=@pMonth and f.IdSucursal=@pIdSucursal) order by f.Id asc", _con);
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
                            _reader.GetInt64(8),
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
        public static List<Factura> searchEgresoNoParametro(string pText,int pIdSucursal, int pLimit)
        {
            List<Factura> lista = new List<Factura>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select distinct f.* from producto as prod inner join detfactura as df in df.IdProducto=prod.Id " +
                        " inner join factura as f on f.Id=df.Id inner join persona as per on per.Id=f.IdPersona where (per.Nombre like '%" + pText + "%' or " +
                        "prod.Nombre like '%" + pText + "%' or df.Concepto like '%" + pText + "%' or df.Total like '%" + pText + "%' or " +
                        "f.Total like '%" + pText + "%' or f.Observacion or f.NFactura like '%" + pText + "%'" +
                        ") and f.IdSucursal=@pIdSucursal order by f.Id asc", _con);
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
                            _reader.GetInt64(8),
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

    }
}
