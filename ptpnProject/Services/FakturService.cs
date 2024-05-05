using ptpnProject.Models.Entities;
using ptpnProject.Data;
using ptpnProject.Models;

namespace ptpnProject.Services
{
    public interface IFakturService
    {
        public Task<int> create(Faktur fakturModel);
        public Task<Faktur> getFaktur();
    }
    public class FakturService : IFakturService
    {
        private readonly AppDbContext dbContext;

        public FakturService(AppDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public Task<int> create(Faktur fakturModel)
        {
            throw new NotImplementedException();
        }

        public Task<Faktur> getFaktur()
        {
            throw new NotImplementedException();
        }

        public void createNewFaktur(FakturDtoModel faktur)
        {
            var newfaktur = new Faktur
            {
                FakturCode = faktur.FakturCode,
                Operator = "TES",
                Total = 0,
                TglFaktur = DateTime.Now,
            };
            dbContext.Fakturs.Add(newfaktur);
            dbContext.SaveChanges();
        
        }
    }
}
