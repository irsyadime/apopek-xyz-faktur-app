namespace ptpnProject.Models.Entities
{
    public class FakturDetail
    {
        public int Id { get; set; }
        public int FakturId { get; set; }
        public int ProductId { get; set; }
        public int JumlahBeli { get; set; }
        public int SubTotal { get; set; }
        public Faktur Faktur { get; set; }
        public Product Product { get; set; }
    }
}
