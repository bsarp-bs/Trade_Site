namespace Trade_Site_WebUI_Dto_Layer.UI_Demand_DTOs
{
    public class UI_GetOrderMainDto
    {
        public int OrderMainID { get; set; }
        public string UserID { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderMainDate { get; set; }
        public string OrderStatus { get; set; }
    }
}
