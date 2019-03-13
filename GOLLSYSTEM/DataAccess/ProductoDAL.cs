using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class ProductoDAL
    {
        public static Producto getProductoById(Int64 pId)
        {
            Producto item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from producto where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Producto(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            Decimal.Round(_reader.GetDecimal(2), 2)
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
        public static Producto getProductoMensualidad()
        {
            Producto item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemMensualidad = new MySqlCommand("select * from producto where Nombre='Mensualidad'", _con);
                    MySqlDataReader _reader = cmdGetItemMensualidad.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Producto(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            Decimal.Round(_reader.GetDecimal(2), 2)
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
        public static List<Producto> getProductos(int pLimit)
        {
            List<Producto> lista = new List<Producto>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from producto where Nombre!='Mensualidad' order by Id asc limit @pLimit", _con);
                    comando.Parameters.AddWithValue("@pLimit", pLimit);
                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Producto item = new Producto(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            Decimal.Round(_reader.GetDecimal(2),2)
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
        public static List<Producto> getProductosReservados(Int64 pIdPersona,int pLimit)
        {
            List<Producto> lista = new List<Producto>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from producto as p right join detfactura as df "+
                        " on df.IdProducto=p.Id right join factura as f on f.IdPersona=p.Id where f.IdPersona=@pIdPersona "+
                        " and (df.Total+df.Descuento)<p.Precio order by Id asc limit @pLimit", _con);
                    comando.Parameters.AddWithValue("@pLimit", pLimit); 
                    comando.Parameters.AddWithValue("@pIdPersona", pIdPersona); 

                     MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Producto item = new Producto(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            Decimal.Round(_reader.GetDecimal(2), 2)
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

        public static bool insertProducto(Producto item, Useremp pUser)
        {
            bool result = true;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                _con.Open();
                MySqlTransaction _trans = _con.BeginTransaction();
                try
                {
                    MySqlCommand cmdInsertProducto = new MySqlCommand("Insert into producto (Nombre, Precio) values (@Nombre, @Precio)", _con, _trans);
                    cmdInsertProducto.Parameters.AddWithValue("@Nombre", item.Nombre);
                    cmdInsertProducto.Parameters.AddWithValue("@Precio", item.Precio);

                    if (cmdInsertProducto.ExecuteNonQuery() <= 0)
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
