namespace BusinessLayer
{
    public class Assets
    {
        public int? AssetId { get; set; }
        public string? AssetName { get; set; }
        public string? AssetDescription { get; set; }
        public int? AssetCostPerDay { get; set; }
        public int? AssetStockAvailability { get; set; }
    }
}