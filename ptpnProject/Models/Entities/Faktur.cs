using System.ComponentModel.DataAnnotations.Schema;

namespace ptpnProject.Models.Entities
{
    public class Faktur
    {
        public int Id { get; set; }
        public string FakturCode { get; set; }
        public string Operator { get; set; }
        [Column("TglFaktur")]
        public DateTime TglFaktur { get; set; }
        public int Total { get; set; }
        public List<FakturDetail> Details { get; set; }
    }
}
