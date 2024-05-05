using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ptpnProject.Data;
using ptpnProject.Models;
using ptpnProject.Models.Entities;

namespace ptpnProject.Controllers
{
    public class FakturController : Controller
    {
        private readonly AppDbContext dbContext;

        public FakturController(AppDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        [HttpPost]

        public async Task<IActionResult> CreateFaktur(FakturDtoModel model)
        {
            var existingFaktur = await dbContext.Fakturs.FirstOrDefaultAsync(f=>f.FakturCode == model.FakturCode);

            if(existingFaktur != null)
            {
                return RedirectToAction("Form","Faktur", new {id =  existingFaktur.Id});
            }
            else
            {
                var faktur = new Faktur
                {
                    FakturCode = model.FakturCode,
                    Operator = "TES",
                    TglFaktur = DateTime.Now,
                    Total = 0,
                };

                await dbContext.Fakturs.AddAsync(faktur);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Form", "Faktur", new { id = faktur.Id });
            }
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Form(int id)
        {
            var faktur = await dbContext.Fakturs.FindAsync(id);
            if (faktur == null)
            {
                return NotFound();
            }
            var products = await dbContext.Products.ToListAsync();

            ViewBag.Product = products;
            ViewBag.Faktur = faktur;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveData([FromBody] TransactionSaveDTO data)
        {
            using(var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    foreach(var transactionDto in data.Transactions)
                    {
                        var fakturDetail = new FakturDetail
                        {
                            FakturId = transactionDto.FakturId,
                            ProductId = transactionDto.ProductId,
                            JumlahBeli = transactionDto.JumlahBeli,
                            SubTotal = transactionDto.SubTotal,
                        };

                        await dbContext.FakturDetail.AddAsync(fakturDetail);
                    }
                    await dbContext.SaveChangesAsync();

                    var faktur = await dbContext.Fakturs.FirstOrDefaultAsync(f => f.Id == data.FakturId);

                    if(faktur != null)
                    {
                        faktur.Total = data.Total;
                        await dbContext.SaveChangesAsync();
                    }

                    await transaction.CommitAsync();
                    return Ok(new { success = true, message = "Data berhasil disimpan" });
                } catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(500, "An error occurred while saving transaction data: " + ex.Message);
                }
            }
        }
        
    }
}
