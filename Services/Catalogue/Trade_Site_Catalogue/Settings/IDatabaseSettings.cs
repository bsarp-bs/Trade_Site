namespace Trade_Site_Catalogue.Settings
{
    public interface IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ProductInfoCollectionName { get; set; }
        public string ProductPhotoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
