using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Pry_Practico_EJL_BP.Models;

namespace Pry_Practico_EJL_BP.Data
{
    public class ClientesData
    {
        public static bool Registrar(Clientes oClientes)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.rutaConexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Usp_Inser_Update_Acciones_Clientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "Insertar");
                cmd.Parameters.AddWithValue("@Id", oClientes.Id);
                cmd.Parameters.AddWithValue("@Nombre", oClientes.Nombre);
                cmd.Parameters.AddWithValue("@Genero", oClientes.Genero);
                cmd.Parameters.AddWithValue("@Edad", oClientes.Edad);
                cmd.Parameters.AddWithValue("@Identificación", oClientes.Identificación);
                cmd.Parameters.AddWithValue("@Dirección", oClientes.Dirección);
                cmd.Parameters.AddWithValue("@Teléfono", oClientes.Teléfono);
                cmd.Parameters.AddWithValue("@Contraseña", oClientes.Contraseña);
                cmd.Parameters.AddWithValue("@Estado", oClientes.Estado);
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

        public static bool Actualizar(Clientes oClientes)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.rutaConexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Usp_Inser_Update_Acciones_Clientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "Actualziar");
                cmd.Parameters.AddWithValue("@Id", oClientes.Id);
                cmd.Parameters.AddWithValue("@Nombre", oClientes.Nombre);
                cmd.Parameters.AddWithValue("@Genero", oClientes.Genero);
                cmd.Parameters.AddWithValue("@Edad", oClientes.Edad);
                cmd.Parameters.AddWithValue("@Identificación", oClientes.Identificación);
                cmd.Parameters.AddWithValue("@Dirección", oClientes.Dirección);
                cmd.Parameters.AddWithValue("@Teléfono", oClientes.Teléfono);
                cmd.Parameters.AddWithValue("@Contraseña", oClientes.Contraseña);
                cmd.Parameters.AddWithValue("@Estado", oClientes.Estado);
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

        public static List<Clientes> Listar()
        {
            List<Clientes> oListaCLientes = new List<Clientes>();

            using (SqlConnection cn = new SqlConnection(Conexion.rutaConexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Usp_Consulta_Clientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Accion", "General");
                cmd.Parameters.AddWithValue("@Id", "");
                try
                {
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr =cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaCLientes.Add(new Clientes()
                            {
                              Id = dr["Id"].ToString(),
                              Nombre = dr["Nombre"].ToString(),
                              Genero= dr["Genero"].ToString(),
                              Edad = Convert.ToInt32(dr["Edad"].ToString()),
                              Identificación = dr["Identificación"].ToString(),
                              Dirección= dr["Dirección"].ToString(),
                              Teléfono= dr["Teléfono"].ToString(),
                              Contraseña = dr["Contraseña"].ToString(),
                              Estado= dr["Estado"].ToString()
                            }) ;
                        }
                    }

                    return oListaCLientes;
                }
                catch (Exception ex)
                {
                    return oListaCLientes;
                }
            }
        }

        public static Clientes Obtener(int Id)
        {
            Clientes oClientes = new Clientes();

            using (SqlConnection cn = new SqlConnection(Conexion.rutaConexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Usp_Consulta_Clientes", cn);
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
                            oClientes = (new Clientes()
                            {
                                Id= dr["Id"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Genero = dr["Genero"].ToString(),
                                Edad = Convert.ToInt32(dr["Edad"].ToString()),
                                Identificación = dr["Identificación"].ToString(),
                                Dirección = dr["Dirección"].ToString(),
                                Teléfono = dr["Teléfono"].ToString(),
                                Contraseña = dr["Contraseña"].ToString(),
                                Estado = dr["Estado"].ToString()
                            });
                        }
                    }

                    return oClientes;
                }
                catch (Exception ex)
                {
                    return oClientes;
                }
            }
        }

        public static bool Eliminar(int Id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.rutaConexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Usp_Consulta_Clientes", cn);
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
