using BusinessLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class AssetsDAO
    {
        public List<Assets> GetAssetsDetails(string _connectionString)
        {
            DataSet ds = new DataSet();

            try
            {
                string spName = "GetAllAssets";
                ds = Db.Get(_connectionString, spName);
                List<Assets> assetsList = new List<Assets>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Assets assets = new Assets();
                    assets.AssetId = Convert.ToInt32(dr["AssetId"]);
                    assets.AssetName = dr["AssetName"].ToString();
                    assets.AssetDescription = dr["AssetDescription"].ToString();
                    assets.AssetCostPerDay = Convert.ToInt32(dr["AssetCostPerDay"]);
                    assets.AssetStockAvailability = Convert.ToInt32(dr["AssetStockAvailability"]);

                    assetsList.Add(assets);
                }

                return assetsList;
            }

            catch(Exception ex)
            {
                return null;
            }
        }

        public string EditAssetById(Assets assets, string _connectionString)
        {
            string spName = "EditAsset";

            Dictionary<string, string?> param = new Dictionary<string, string?>();
            param.Add("@assetId", assets.AssetId.ToString());
            param.Add("@assetName", assets.AssetName);
            param.Add("@assetDescription", assets.AssetDescription);
            param.Add("@assetCostPerDay", assets.AssetCostPerDay.ToString());
            param.Add("@assetStockAvailability", assets.AssetStockAvailability.ToString());

            string response = Db.EditDataById(_connectionString, spName, param);

            if (response == "Data Updated Successfully")
            {
                response = "Asset Updated Successfully";
            }
            return response;
        }

        public string AddAsset(Assets assets, string _connectionString)
        {
            string spName = "AddAsset";

            Dictionary<string, string?> param = new Dictionary<string, string?>();
            param.Add("@assetName", assets.AssetName);
            param.Add("@assetDescription", assets.AssetDescription);
            param.Add("@assetCostPerDay", assets.AssetCostPerDay.ToString());
            param.Add("@assetStockAvailability", assets.AssetStockAvailability.ToString());

            string response = Db.AddDataToDb(_connectionString, spName, param);

            if (response == "Data Added Successfully")
            {
                response = "Asset Added Successfully";
            }
            return response;
        }

        public string DeleteAsset(int assetId, string _connectionString)
        {
            string spName = "DeleteAsset";
            string paramName = "@assetId";
            int Id = assetId;
            string response = Db.DeleteDataFromDb(_connectionString, spName, paramName, Id);

            if (response == "Data Deleted Successfully")
            {
                response = "Asset Deleted Successfully";
            }
            return response;
        }
    }
}
