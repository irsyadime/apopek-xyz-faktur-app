namespace ptpnProject.Models
{
    public class TransactionSaveDTO
    {
        public List<TransactionDTO> Transactions { get; set; }
        public int Total {  get; set; }
        public int FakturId { get; set; }
    }
}
