using BusinessLayer;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace DataAccessLayer
{
    public static class Db
    {
        public static DataSet Get(string connectionString, string spName)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        return ds;
                    }
                }

            }
        }

        public static string EditDataById(string connectionString, string spName, Dictionary<string, string> param)
        {
            string response = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (var item in param)
                        {
                            cmd.Parameters.AddWithValue(item.Key, item.Value);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }

                response = "Data Updated Successfully";
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }

        public static string AddDataToDb(string connectionString, string spName, Dictionary<string,string> param)
        {
            string response = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (var item in  param)
                        {
                            cmd.Parameters.AddWithValue(item.Key, item.Value);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }

                response = "Data Added Successfully";
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }


        public static string DeleteDataFromDb(string connectionString, string spName, string paramName, int Id)
        {
            string response = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue(paramName, Id);
                        cmd.ExecuteNonQuery();
                    }
                }

                response = "Data Deleted Successfully";
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }

    }
}