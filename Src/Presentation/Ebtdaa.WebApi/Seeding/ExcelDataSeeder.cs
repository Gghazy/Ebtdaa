using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.ProductData.Entity;
using Ebtdaa.Persistence;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace Ebtdaa.WebApi.Seeding
{
    public class ExcelDataSeeder
    {
        private readonly IEbtdaaDbContext _context;
        public ExcelDataSeeder(IEbtdaaDbContext context)
        {
            _context = context;
        }
        public async Task SeedData()
        {
           await SeedMappingProductFromExcel();
           await SeedMappingUnitFromExcel();
        }

        public async Task SeedMappingProductFromExcel()
        {
            if (_context.MappingProducts.Count()==0)
            {
                _context.MappingProducts.RemoveRange(_context.MappingProducts);
                await _context.SaveChangesAsync();


                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "MappingProduct.xlsx");
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                List<MappingProduct> mappingProducts = new List<MappingProduct>();

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                    {
                        var mappProduct = new MappingProduct
                        {
                            Hs10Code = worksheet.Cells[row, 2].Value?.ToString() ?? "",
                            Hs10NameAr = worksheet.Cells[row, 3].Value?.ToString() ?? "",
                            Hs10NameEn = worksheet.Cells[row, 4].Value?.ToString() ?? "",
                            Hs12Code = worksheet.Cells[row, 5].Value?.ToString() ?? "",
                            Hs12NameAr = worksheet.Cells[row, 6].Value?.ToString() ?? "",
                            Hs12NameEn = worksheet.Cells[row, 7].Value?.ToString() ?? "",

                        };
                        mappingProducts.Add(mappProduct);


                    }
                    await _context.MappingProducts.AddRangeAsync(mappingProducts.Where(x => x.Hs10Code != String.Empty));

                    await _context.SaveChangesAsync();
                }
            
            }


           
        }

        public async Task SeedMappingUnitFromExcel()
        {
            if (_context.MappingUnits.Count() == 0)
            {
                _context.MappingUnits.RemoveRange(_context.MappingUnits);
                await _context.SaveChangesAsync();


                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "MappingUnit.xlsx");
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                List<MappingUnit> mappingUnits = new List<MappingUnit>();
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                    {
                        var mappUnit = new MappingUnit
                        {
                            HS6 = worksheet.Cells[row, 2].Value?.ToString() ?? "",
                            UnitOfMeasurement = worksheet.Cells[row, 4].Value?.ToString() ?? "",

                        };
                        mappingUnits.Add(mappUnit);


                    }
                    var x = mappingUnits.Where(x => x.HS6 != String.Empty);
                    await _context.MappingUnits.AddRangeAsync(mappingUnits.Where(x => x.HS6 != String.Empty));
                    await _context.SaveChangesAsync();
                }

            }

        }



    }
}
