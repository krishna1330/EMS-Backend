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

        public static string EditAssetById(Assets assets, string connectionString, string spName)
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

                        cmd.Parameters.AddWithValue("@assetId", assets.AssetId);
                        cmd.Parameters.AddWithValue("@assetName", assets.AssetName);
                        cmd.Parameters.AddWithValue("@assetDescription", assets.AssetDescription);
                        cmd.Parameters.AddWithValue("@assetCostPerDay", assets.AssetCostPerDay);
                        cmd.Parameters.AddWithValue("@assetStockAvailability", assets.AssetStockAvailability);

                        cmd.ExecuteNonQuery();
                    }
                }

                response = "Asset Updated Successfully";
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }

        public static string AddAsset(Assets assets, string connectionString, string spName)
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

                        cmd.Parameters.AddWithValue("@assetName", assets.AssetName);
                        cmd.Parameters.AddWithValue("@assetDescription", assets.AssetDescription);
                        cmd.Parameters.AddWithValue("@assetCostPerDay", assets.AssetCostPerDay);
                        cmd.Parameters.AddWithValue("@assetStockAvailability", assets.AssetStockAvailability);

                        cmd.ExecuteNonQuery();
                    }
                }

                response = "Asset Added Successfully";
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }


        public static string DeleteAsset(int assetId, string connectionString, string spName)
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
                        cmd.Parameters.AddWithValue("@assetId", assetId);
                        cmd.ExecuteNonQuery();
                    }
                }

                response = "Asset Deleted Successfully";
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }

    }
}