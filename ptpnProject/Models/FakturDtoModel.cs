using ptpnProject.Models.Entities;

namespace ptpnProject.Models
{
    public class FakturDtoModel
    {
        public string FakturCode { get; set; }
        public string Operator { get; set; }
        public DateTime TglFaktur { get; set; }
        public int Total { get; set; }
        public List<FakturDetail> Details { get; set; }
    }
}
