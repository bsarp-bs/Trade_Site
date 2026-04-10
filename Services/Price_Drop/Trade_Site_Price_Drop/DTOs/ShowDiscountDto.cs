namespace Trade_Site_Price_Drop.DTOs
{
    public class ShowDiscountDto
    {
        public int DiscountID { get; set; }
        public string DiscountCode { get; set; }
        public int DiscountRate { get; set; }
        public bool DiscountStatus { get; set; }
        public DateTime DiscountEndDate { get; set; }

    }
}
