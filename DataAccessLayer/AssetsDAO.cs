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
            string response = Db.EditAssetById(assets, _connectionString, spName);

            return response;
        }

        public string AddAsset(Assets assets, string _connectionString)
        {
            string spName = "AddAsset";
            string response = Db.AddAsset(assets, _connectionString, spName);

            return response;
        }

        public string DeleteAsset(int assetId, string _connectionString)
        {
            string spName = "DeleteAsset";
            string response = Db.DeleteAsset(assetId, _connectionString, spName);

            return response;
        }
    }
}
