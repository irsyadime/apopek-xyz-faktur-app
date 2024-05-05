namespace ptpnProject.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public List<FakturDetail> Details { get; set; }
    }
}
