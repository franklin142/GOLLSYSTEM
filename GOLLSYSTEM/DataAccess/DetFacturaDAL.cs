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
                            _reader.GetInt64(5),
                            _reader.GetInt64(6),
                            ProductoDAL.getProductoById(_reader.GetInt64(6)),
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
                            _reader.GetInt64(5),
                            _reader.GetInt64(6),
                            ProductoDAL.getProductoById(_reader.GetInt64(6)),
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
    }
}
