using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Pry_Practico_EJL_BP.Models;

namespace Pry_Practico_EJL_BP.Data
{
    public class CuentasData
    {

        public static bool Registrar(Cuentas oCuentas)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.rutaConexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Usp_Inser_Update_Cuentas", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "Insertar");
                cmd.Parameters.AddWithValue("@IdCliente", Convert.ToInt32(oCuentas.Cliente));
                cmd.Parameters.AddWithValue("@NumCuenta", oCuentas.NumCuenta);
                cmd.Parameters.AddWithValue("@TipoCuenta", oCuentas.TipoCuenta);
                cmd.Parameters.AddWithValue("@SaldoInicial", oCuentas.SaldoInicial);
                cmd.Parameters.AddWithValue("@Estado", oCuentas.Estado);
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool Actualizar(Cuentas oCuentas)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.rutaConexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Usp_Inser_Update_Cuentas", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "Actualziar");
                cmd.Parameters.AddWithValue("@IdCliente",Convert.ToInt32(oCuentas.Cliente));
                cmd.Parameters.AddWithValue("@NumCuenta", oCuentas.NumCuenta);
                cmd.Parameters.AddWithValue("@TipoCuenta", oCuentas.TipoCuenta);
                cmd.Parameters.AddWithValue("@SaldoInicial", oCuentas.SaldoInicial);
                cmd.Parameters.AddWithValue("@Estado", oCuentas.Estado);
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Cuentas> Listar()
        {
            List<Cuentas> oListaCuentas = new List<Cuentas>();

            using (SqlConnection cn = new SqlConnection(Conexion.rutaConexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Usp_Consulta_Cuentas", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "General");
                cmd.Parameters.AddWithValue("@Id", "");
                try
                {
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaCuentas.Add(new Cuentas()
                            {
                                NumCuenta = Convert.ToInt32(dr["NumCuenta"].ToString()),
                                TipoCuenta = dr["TipoCuenta"].ToString(),
                                SaldoInicial = dr["SaldoInicial"].ToString(),                        
                                Estado = dr["Estado"].ToString(),
                                Cliente = dr["Nombre"].ToString()
                            });
                        }
                    }

                    return oListaCuentas;
                }
                catch (Exception ex)
                {
                    return oListaCuentas;
                }
            }
        }

        public static Cuentas Obtener(int Id)
        {
            Cuentas oCuentas = new Cuentas();

            using (SqlConnection cn = new SqlConnection(Conexion.rutaConexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Usp_Consulta_Cuentas", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "Individual");
                cmd.Parameters.AddWithValue("@Id", Id);
                try
                {
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCuentas = (new Cuentas()
                            {
                                NumCuenta = Convert.ToInt32(dr["NumCuenta"].ToString()),
                                TipoCuenta = dr["TipoCuenta"].ToString(),
                                SaldoInicial = dr["SaldoInicial"].ToString(),
                                Estado = dr["Estado"].ToString(),
                                Cliente = dr["Nombre"].ToString()
                            });
                        }
                    }

                    return oCuentas;
                }
                catch (Exception ex)
                {
                    return oCuentas;
                }
            }
        }

        public static bool Eliminar(int Id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.rutaConexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Usp_Consulta_Cuentas", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "Eliminar");
                cmd.Parameters.AddWithValue("@Id", Id);

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

    }
}
