using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOLLSYSTEM.EntityLayer;
using MySql.Data.MySqlClient;

namespace GOLLSYSTEM.DataAccess
{
    public class CuotaDAL
    {
        public static Cuota getCuotaById(Int64 pId)
        {
            Cuota item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from cuota where Id=@pId", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pId", pId);
                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Cuota(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetDecimal(2),
                            _reader.GetDecimal(3),
                            _reader.GetInt64(4)
                            );

                    }
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
            return item;
        }
        public static Cuota getCuotaByMonth(Int64 pIdMatricula, int pMonth, int pYear)
        {
            Cuota item = null;
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand cmdGetItemById = new MySqlCommand("select * from cuota where IdMatricula=@pIdMatricula and month(FhRegistro)=@pMonth and year(FhRegistro)=@pYear ", _con);
                    cmdGetItemById.Parameters.AddWithValue("@pIdMatricula", pIdMatricula);
                    cmdGetItemById.Parameters.AddWithValue("@pMonth", pMonth);
                    cmdGetItemById.Parameters.AddWithValue("@pYear", pYear);

                    MySqlDataReader _reader = cmdGetItemById.ExecuteReader();
                    while (_reader.Read())
                    {
                        item = new Cuota(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetDecimal(2),
                            _reader.GetDecimal(3),
                            _reader.GetInt64(4)
                            );

                    }
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
            return item;
        }

        public static List<Cuota> getCuotasByIdMatricula(Int64 pIdMatricula, int pLimit)
        {
            List<Cuota> lista = new List<Cuota>();
            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlCommand comando = new MySqlCommand("select * from cuota where IdMatricula=@pIdMatricula and Total <Precio order by Id asc limit @pLimit", _con);
                    comando.Parameters.AddWithValue("@pIdMatricula", pIdMatricula);
                    comando.Parameters.AddWithValue("@pLimit", pLimit);

                    MySqlDataReader _reader = comando.ExecuteReader();
                    while (_reader.Read())
                    {
                        Cuota item = new Cuota(
                            _reader.GetInt64(0),
                            _reader.GetString(1),
                            _reader.GetDecimal(2),
                            _reader.GetDecimal(3),
                            _reader.GetInt64(4)
                            );

                        lista.Add(item);

                    }
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
            return lista;
        }
        public static bool syncCuotas(Int64 pIdCurso, Int64 pUserId)
        {
            bool result = true;
            bool registro = false;
            List<Cuota> lista = new List<Cuota>();
            List<Matricula> matriculas = new List<Matricula>();
            Curso curso = CursoDAL.getCursoById(pIdCurso);
            DateTime fechaFin = Convert.ToDateTime(curso.Hasta);

            using (MySqlConnection _con = new Conexion().Conectar())
            {
                try
                {
                    _con.Open();
                    MySqlTransaction _trans = _con.BeginTransaction();
                    MySqlCommand cmdGetMatriculas = new MySqlCommand("select Id from matricula where IdCurso=@pIdCurso order by Id asc", _con);
                    cmdGetMatriculas.Parameters.AddWithValue("@pIdCurso", pIdCurso);
                    MySqlDataReader _reader = cmdGetMatriculas.ExecuteReader();
                    while (_reader.Read())
                    {
                        matriculas.Add(MatriculaDAL.getMatriculaById(_reader.GetInt64(0)));

                    }
                    _reader.Close();
                    foreach (Matricula matricula in matriculas)
                    {
                        DateTime fechaIni = Convert.ToDateTime(matricula.FhRegistro);
                        if (matricula != null)
                        {
                            for (int i = 0; i < (Math.Abs((fechaFin.Month - fechaIni.Month) + 12 * (fechaFin.Year - fechaIni.Year)) + 1); i++)
                            {
                                int val1 = (fechaIni.AddMonths(i)).Month;
                                int val2 = (fechaIni.AddMonths(i)).Year;
                                string fecha = fechaIni.AddMonths(i).ToString("yyyy") + "-" + fechaIni.AddMonths(i).ToString("MM") + "-" + (DateTime.DaysInMonth(fechaIni.AddMonths(i).Year, fechaIni.AddMonths(i).Month) > Convert.ToInt32(matricula.DiaLimite) ? matricula.DiaLimite : DateTime.DaysInMonth(fechaIni.AddMonths(i).Year, fechaIni.AddMonths(i).Month).ToString());
                                if (Convert.ToInt32(matricula.DiaLimite) < Convert.ToDateTime(curso.Desde).Day && Convert.ToDateTime(curso.Desde).AddMonths(i).ToString("MM") == Convert.ToDateTime(matricula.FhRegistro).ToString("MM"))
                                {
                                    fecha = fechaIni.ToString("yyyy") + "-" + fechaIni.AddMonths(i).ToString("MM") + "-" + Convert.ToDateTime(curso.Desde).Day;
                                }
                                Cuota cuota = getCuotaByMonth(matricula.Id, (fechaIni.AddMonths(i)).Month, (fechaIni.AddMonths(i)).Year);
                                if (cuota == null)
                                {

                                    MySqlCommand cmdInsertCuota = new MySqlCommand("Insert into cuota (FhRegistro,Precio,Total,IdMatricula) values ('" + fecha + "',@Precio,@Total,@IdMatricula)", _con, _trans);
                                    cmdInsertCuota.Parameters.AddWithValue("@Precio", Properties.Settings.Default.PrecioCuota);
                                    cmdInsertCuota.Parameters.AddWithValue("@Total", "0.00");
                                    cmdInsertCuota.Parameters.AddWithValue("@IdMatricula", matricula.Id);

                                    if (cmdInsertCuota.ExecuteNonQuery() <= 0)
                                    {
                                        result = false;
                                    }
                                    else
                                    {
                                        registro = true;
                                    }
                                }

                            }
                            List<Cuota> cuotas = matricula.Cuotas.Where(a => Convert.ToDateTime(a.FhRegistro) < Convert.ToDateTime(curso.Desde) || Convert.ToDateTime(a.FhRegistro) > Convert.ToDateTime(curso.Hasta)).ToList();
                            foreach (Cuota cuota in cuotas)
                            {
                                if (MatricdetfacDAL.getMatricdetfacByIdCuota(cuota.Id) == null)
                                {
                                    MySqlCommand cmdInsertCuota = new MySqlCommand("delete from cuota where Id=@Id", _con, _trans);
                                    cmdInsertCuota.Parameters.AddWithValue("@Id", cuota.Id);
                                    if (cmdInsertCuota.ExecuteNonQuery() <= 0)
                                    {
                                        result = false;
                                    }
                                    else
                                    {
                                        registro = true;
                                    }
                                    if (result)
                                    {
                                        MySqlCommand cmdInsertAuditoria = new MySqlCommand("Insert into regemphist (Detalle,Accion,TipoRegistro,IdUserEmp) values (@Detalle,@Accion,@TipoRegistro,@IdUserEmp)", _con, _trans);
                                        cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Sincronizó cuotas en el sistema y se elimino permanentemente la cuota con Id " + cuota.Id + " de la matricula con Id " + matricula.Id + " ya que no habia sido cancelada ni anulada en ningun caso posible.");
                                        cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Eliminar");
                                        cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Cuotas");
                                        cmdInsertAuditoria.Parameters.AddWithValue("@IdUserEmp", pUserId);
                                        if (cmdInsertAuditoria.ExecuteNonQuery() <= 0)
                                        {
                                            result = false;
                                        }
                                    }
                                }

                            }
                        }
                    }
                    if (result && registro)
                    {
                        if (result)
                        {
                            MySqlCommand cmdInsertAuditoria = new MySqlCommand("Insert into regemphist (Detalle,Accion,TipoRegistro,IdUserEmp) values (@Detalle,@Accion,@TipoRegistro,@IdUserEmp)", _con, _trans);
                            cmdInsertAuditoria.Parameters.AddWithValue("@Detalle", "Sincronizó cuotas en el sistema.");
                            cmdInsertAuditoria.Parameters.AddWithValue("@Accion", "Registrar");
                            cmdInsertAuditoria.Parameters.AddWithValue("@TipoRegistro", "Cuotas");
                            cmdInsertAuditoria.Parameters.AddWithValue("@IdUserEmp", pUserId);
                            if (cmdInsertAuditoria.ExecuteNonQuery() <= 0)
                            {
                                result = false;
                            }
                        }
                    }
                    if (result)
                    {
                        if (registro)
                            _trans.Commit();
                    }
                    else
                    {
                        _trans.Rollback();
                    }
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
            return result;
        }
    }
}
