using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class DetFacturaDAL
    {
        public static Detfactura getDetfacturaById(Int64 pId)
        {
            Detfactura item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from detfactura where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Detfactura(
                           _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetDecimal(2),
                            _reader.GetDecimal(3),
                            _reader.GetString(4),
                            _reader.IsDBNull(5)?null:_reader.GetString(5),
                            _reader.GetInt64(6),
                            _reader.GetInt64(7),
                            ProductoDAL.getProductoById(_reader.GetInt64(7)),
                            MatricdetfacDAL.getMatricdetfacByIdDetFactura(_reader.GetInt64(0))
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
        public static List<Detfactura> getDetsfacturaByIdFactura(Int64 pIdFactura)
        {
            List<Detfactura> lista = new List<Detfactura>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from detfactura where IdFactura=@pIdFactura order by Id asc", _con);
                    comando.Parameters.AddWithValue("@pIdFactura", pIdFactura);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Detfactura item = new Detfactura(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetDecimal(2),
                            _reader.GetDecimal(3),
                            _reader.GetString(4),
                            _reader.IsDBNull(5) ? null : _reader.GetString(5),
                            _reader.GetInt64(6),
                            _reader.GetInt64(7),
                            ProductoDAL.getProductoById(_reader.GetInt64(7)),
                            MatricdetfacDAL.getMatricdetfacByIdDetFactura(_reader.GetInt64(0))
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
        public static List<Detfactura> getDetsfacturaByIdPersona(Int64 pIdPersona)
        {
            List<Detfactura> lista = new List<Detfactura>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select df.* from detfactura as df inner join factura as f "+
                        "on f.Id=df.IdFactura inner join Producto as p on p.Id = df.IdProducto where f.IdPersona = @pIdPersona " +
                        " and df.Tipo = 'R' and (SELECT sum(dfs.Total) from detfactura as dfs inner join factura fs on fs.Id=dfs.IdFactura where dfs.RefNFactura=df.RefNFactura and fs.Estado='C')" +
                        " < p.Precio and f.Estado='C' order by Id desc", _con);
                    comando.Parameters.AddWithValue("@pIdPersona", pIdPersona);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Detfactura item = new Detfactura(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetDecimal(2),
                            _reader.GetDecimal(3),
                            _reader.GetString(4),
                            _reader.IsDBNull(5) ? null : _reader.GetString(5),
                            _reader.GetInt64(6),
                            _reader.GetInt64(7),
                            ProductoDAL.getProductoById(_reader.GetInt64(7)),
                            MatricdetfacDAL.getMatricdetfacByIdDetFactura(_reader.GetInt64(0))
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
        public static bool getIsParent(Int64 pId)
        {
            bool item = false;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select count(f.Id) from factura as f inner join detfactura as df on df.IdFactura=f.Id where df.Tipo='R' and f.Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = _reader.GetInt32(0)>0;
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

        public static decimal getTotalDebeReserva(Int64 pIdDetFactura,Int64 pIdPersona)
        {
            decimal item = 0;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("SELECT ((select p.Precio from producto as p where p.Id=(SELECT df.IdProducto from detfactura as df where Id=@pIdDetFactura ))-((select sum(dfs.Total) from detfactura as dfs inner join factura as f on f.Id = dfs.IdFactura where f.Estado='C' and f.IdPersona = @pIdPersona and (dfs.Tipo='R' or dfs.Tipo='C')and dfs.RefNFactura=(SELECT df.RefNFactura from detfactura as df where df.Id=@pIdDetFactura) and dfs.IdProducto= (select dft.IdProducto from detfactura as dft where dft.Id=@pIdDetFactura)))) as TotalDebe", _con);
                    comando.Parameters.AddWithValue("@pIdDetFactura", pIdDetFactura);
                    comando.Parameters.AddWithValue("@pIdPersona", pIdPersona);

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

    }
}
