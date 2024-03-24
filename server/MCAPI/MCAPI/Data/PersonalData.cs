using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using MCAPI.Models;

namespace MCAPI.Data
{
    public class PersonalData
    {
        public static bool Registrar(Personal oPersonal)
        {
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertPersonal", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersonal", oPersonal.idPersonal);
                cmd.Parameters.AddWithValue("@TipoDoc", oPersonal.TipoDoc);
                cmd.Parameters.AddWithValue("@NumeroDoc", oPersonal.NumeroDoc);
                cmd.Parameters.AddWithValue("@ApPaterno", oPersonal.ApPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", oPersonal.ApMaterno);
                cmd.Parameters.AddWithValue("@Nombre1", oPersonal.Nombre1);
                cmd.Parameters.AddWithValue("@Nombre2", oPersonal.Nombre2);
                cmd.Parameters.AddWithValue("@NombreCompleto", oPersonal.NombreCompleto);
                cmd.Parameters.AddWithValue("@FechaNac", oPersonal.FechaNac);
                cmd.Parameters.AddWithValue("@FechaIngreso", oPersonal.FechaIngreso);

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


        public static bool Modificar(Personal oPersonal)
        {
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdatePersonal", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersonal", oPersonal.idPersonal);
                cmd.Parameters.AddWithValue("@TipoDoc", oPersonal.TipoDoc);
                cmd.Parameters.AddWithValue("@NumeroDoc", oPersonal.NumeroDoc);
                cmd.Parameters.AddWithValue("@ApPaterno", oPersonal.ApPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", oPersonal.ApMaterno);
                cmd.Parameters.AddWithValue("@Nombre1", oPersonal.Nombre1);
                cmd.Parameters.AddWithValue("@Nombre2", oPersonal.Nombre2);
                cmd.Parameters.AddWithValue("@NombreCompleto", oPersonal.NombreCompleto);
                cmd.Parameters.AddWithValue("@FechaNac", oPersonal.FechaNac);
                cmd.Parameters.AddWithValue("@FechaIngreso", oPersonal.FechaIngreso);

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

        public static List<Personal> SelectAll()
        {
            List<Personal> PersonalList = new List<Personal>();
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SelectAllPersonal", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            PersonalList.Add(new Personal()
                            {

                               idPersonal = Convert.ToInt32(dr["idPersonal"]),
                               TipoDoc = dr["TipoDoc"].ToString(),
                               NumeroDoc = dr["ApPaterno"].ToString(),
                               ApPaterno = dr["ApPaterno"].ToString(),
                               ApMaterno = dr["ApMaterno"].ToString(),
                               Nombre1 = dr["Nombre1"].ToString(),
                               Nombre2 = dr["Nombre2"].ToString(),
                               NombreCompleto = dr["NombreCompleto"].ToString(),
                               FechaNac = Convert.ToDateTime(dr["FechaNac"].ToString()),
                               FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"].ToString())
                            });
                        }

                    }

                    return PersonalList;
                }
                catch (Exception ex)
                {
                    return PersonalList;
                }
            }
        }


        public static Personal Query(int idPersonal)
        {
            Personal personal = new Personal();
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("QueryPersonal", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersonal", idPersonal);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            personal = new Personal()
                            {
                                idPersonal = Convert.ToInt32(dr["idPersonal"]),
                                TipoDoc = dr["TipoDoc"].ToString(),
                                NumeroDoc = dr["ApPaterno"].ToString(),
                                ApPaterno = dr["ApPaterno"].ToString(),
                                ApMaterno = dr["ApMaterno"].ToString(),
                                Nombre1 = dr["Nombre1"].ToString(),
                                Nombre2 = dr["Nombre2"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                FechaNac = Convert.ToDateTime(dr["FechaNac"].ToString()),
                                FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"].ToString())
                            };
                        }

                    }



                    return personal;
                }
                catch (Exception ex)
                {
                    return personal;
                }
            }
        }



        public static bool Eliminar(int id)
        {
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeletePersonal", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersonal", id);

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