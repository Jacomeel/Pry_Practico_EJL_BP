using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Pry_Practico_EJL_BP.Models;

namespace Pry_Practico_EJL_BP.Data
{
    public class MovimientosData
    {

        public static string Registrar(Movimientos oMovimientos)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.rutaConexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Usp_Inser_Movimientos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "Insertar");
                cmd.Parameters.AddWithValue("@IdCuenta", Convert.ToInt32(oMovimientos.IdCuenta));
                cmd.Parameters.AddWithValue("@TipoMov", oMovimientos.Movimiento);
                cmd.Parameters.AddWithValue("@Valor", oMovimientos.saldo);

                SqlDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);
                var res = dt.Rows[0][0].ToString();
                cn.Dispose();
                cn.Close();

                try
                {
                    return res;
                }
                catch (Exception ex)
                {
                    return res;
                }
            }
        }
       
        public static List<Movimientos> Listar()
        {
            List<Movimientos> oListaMovimientos = new List<Movimientos>();

            using (SqlConnection cn = new SqlConnection(Conexion.rutaConexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Usp_Consulta_Mov", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "General");
                cmd.Parameters.AddWithValue("@IdCiente", "");
                cmd.Parameters.AddWithValue("@FecIni", "");
                cmd.Parameters.AddWithValue("@FecFin", "");
                try
                {
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaMovimientos.Add(new Movimientos()
                            {
                                Fecha =dr["Fecha"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                NumCuenta = dr["NumCuenta"].ToString(),
                                TipoCuenta = dr["TipoCuenta"].ToString(),
                                SaldoInicial = dr["SaldoInicial"].ToString(),
                                Estado = dr["Estado"].ToString(),
                                Movimiento = dr["Movimiento"].ToString(),
                                saldo = dr["saldo"].ToString()
                            });
                        }
                    }

                    return oListaMovimientos;
                }
                catch (Exception ex)
                {
                    return oListaMovimientos;
                }
            }
        }

        public static Movimientos Obtener(int IdCliente,DateTime FecIni, DateTime FecFin)
        {
            Movimientos oMovimientos = new Movimientos();

            using (SqlConnection cn = new SqlConnection(Conexion.rutaConexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Usp_Consulta_Mov", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "General");
                cmd.Parameters.AddWithValue("@IdCiente", IdCliente);
                cmd.Parameters.AddWithValue("@FecIni", FecIni);
                cmd.Parameters.AddWithValue("@FecFin", FecFin);
                try
                {
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oMovimientos = (new Movimientos()
                            {
                                Fecha = dr["Fecha"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                NumCuenta = dr["NumCuenta"].ToString(),
                                TipoCuenta = dr["TipoCuenta"].ToString(),
                                SaldoInicial = dr["SaldoInicial"].ToString(),
                                Estado = dr["Estado"].ToString(),
                                Movimiento = dr["Movimiento"].ToString(),
                                saldo = dr["saldo"].ToString()
                            });
                        }
                    }

                    return oMovimientos;
                }
                catch (Exception ex)
                {
                    return oMovimientos;
                }
            }
        }

      
    }
}
