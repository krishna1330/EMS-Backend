using BusinessLayer;
using DataObjects;
using System.Data;

namespace ImplementationObjects
{
    public class AssetsImplementation
    {
        private readonly string _connectionString;
        public AssetsImplementation(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Assets> GetAssetsDetails()
        {
            AssetsDAO assetsDAO = new AssetsDAO();
            List<Assets> assetsList = assetsDAO.GetAssetsDetails(_connectionString);

            return assetsList;
        }

        public string EditAssetById(Assets assets)
        {
            AssetsDAO assetsDAO = new AssetsDAO();
            string response = assetsDAO.EditAssetById(assets, _connectionString);

            return response;
        }

        public string AddAsset(Assets assets)
        {
            AssetsDAO assetsDAO = new AssetsDAO();
            string response = assetsDAO.AddAsset(assets, _connectionString);

            return response;
        }

        public string DeleteAsset(int assetId)
        {
            AssetsDAO assetsDAO = new AssetsDAO();
            string response = assetsDAO.DeleteAsset(assetId, _connectionString);

            return response;
        }
    }
}