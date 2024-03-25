using MCAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace MCAPI.Data
{
    public class HijosData
    {

        public static bool Insert(Hijo hijo)
        {
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertHijo", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoDoc", hijo.TipoDoc);
                cmd.Parameters.AddWithValue("@NumeroDoc", hijo.NumeroDoc);
                cmd.Parameters.AddWithValue("@ApPaterno", hijo.ApPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", hijo.ApMaterno);
                cmd.Parameters.AddWithValue("@Nombre1", hijo.Nombre1);
                cmd.Parameters.AddWithValue("@Nombre2", hijo.Nombre2);
                cmd.Parameters.AddWithValue("@NombreCompleto", hijo.NombreCompleto);
                cmd.Parameters.AddWithValue("@FechaNac", hijo.FechaNac);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Modify(Hijo hijo)
        {
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateHijo", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersonal", hijo.IdPersonal);
                cmd.Parameters.AddWithValue("@TipoDoc", hijo.TipoDoc);
                cmd.Parameters.AddWithValue("@NumeroDoc", hijo.NumeroDoc);
                cmd.Parameters.AddWithValue("@ApPaterno", hijo.ApPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", hijo.ApMaterno);
                cmd.Parameters.AddWithValue("@Nombre1", hijo.Nombre1);
                cmd.Parameters.AddWithValue("@Nombre2", hijo.Nombre2);
                cmd.Parameters.AddWithValue("@NombreCompleto", hijo.NombreCompleto);
                cmd.Parameters.AddWithValue("@FechaNac", hijo.FechaNac);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Hijo> SelectAll()
        {
            List<Hijo> hijos = new List<Hijo>();
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SelectAllHijos", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            hijos.Add(new Hijo()
                            {
                                IdHijo = Convert.ToInt32(dr["idHijo"]),
                                IdPersonal = Convert.ToInt32(dr["idPersonal"]),
                                TipoDoc = dr["TipoDoc"].ToString(),
                                NumeroDoc = dr["NumeroDoc"].ToString(),
                                ApPaterno = dr["ApPaterno"].ToString(),
                                ApMaterno = dr["ApMaterno"].ToString(),
                                Nombre1 = dr["Nombre1"].ToString(),
                                Nombre2 = dr["Nombre2"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                FechaNac = Convert.ToDateTime(dr["FechaNac"].ToString())
                            });
                        }
                    }

                    return hijos;
                }
                catch (Exception ex)
                {
                    return hijos;
                }
            }
        }

        public static Hijo Query(int idHijo)
        {
            Hijo hijo = new Hijo();
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("QueryHijo", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idHijo", idHijo);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            hijo = new Hijo()
                            {
                                IdHijo = Convert.ToInt32(dr["idHijo"]),
                                IdPersonal = Convert.ToInt32(dr["idPersonal"]),
                                TipoDoc = dr["TipoDoc"].ToString(),
                                NumeroDoc = dr["NumeroDoc"].ToString(),
                                ApPaterno = dr["ApPaterno"].ToString(),
                                ApMaterno = dr["ApMaterno"].ToString(),
                                Nombre1 = dr["Nombre1"].ToString(),
                                Nombre2 = dr["Nombre2"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                FechaNac = Convert.ToDateTime(dr["FechaNac"].ToString())
                            };
                        }
                    }

                    return hijo;
                }
                catch (Exception ex)
                {
                    return hijo;
                }
            }
        }

        public static bool Delete(int idHijo)
        {
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteHijo", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idHijo", idHijo);

                try
                {
                    connection.Open();
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