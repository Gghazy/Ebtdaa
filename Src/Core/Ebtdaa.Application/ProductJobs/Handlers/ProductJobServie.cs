using AutoMapper;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.ProductJobs.Interfaces;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.Integration;
using Ebtdaa.Domain.ProductData.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ebtdaa.Application.ProductJobs.Handlers
{
    public class ProductJobServie : IProductJobServie
    {
        private readonly IEbtdaaDbContext _dbContext;
        private readonly IIntgrationDbContext _intgrationDbContext;
        public readonly IMapper _mapper;
        public ProductJobServie(IIntgrationDbContext intgrationDbContext, IEbtdaaDbContext dbContext, IMapper mapper)
        {

            _intgrationDbContext = intgrationDbContext;
            _dbContext = dbContext;
            _mapper = mapper;

        }
        public async Task<int> ProductIntegrat()
        {
            var integrationProducts = await GetAllIntegrationProducts();
            var Products = await GetAllProducts();



            if (Products.Count() == 0)
            {

                await AddAllProducts(integrationProducts);
            }        

            return 1;
        }
        private async Task AddAllProducts(List<ProductIntegration> productIntegrations)
        {
            var products = _mapper.Map<List<Product>>(productIntegrations);
            List<FactoryProduct> factoryProducts= new List<FactoryProduct>();

            var factories = await _dbContext.Factories.ToListAsync();

            var mappUnits = await _dbContext.MappingUnits.ToListAsync();
            var units = await _dbContext.Units.ToListAsync();

            try
            {
                var removeProducts=new List<Product>();
                foreach (var product in products)
                {
                    var factory = factories.FirstOrDefault(x => x.CommercialRegister == product.CR);
                    if (factory == null)
                    {
                        removeProducts.Add(product);
                        continue;
                    }
                    product.FactoryProducts = new List<FactoryProduct>
                    {
                        new FactoryProduct{FactoryId = factory.Id }
                    };


                    var unitId =await getUnitId(product.ItemNumber, mappUnits,units);
                    product.UnitId = unitId ;
                }

                products.RemoveAll(objToRemove => removeProducts.Any(obj => obj.ItemNumber.Trim(' ') == objToRemove.ItemNumber.Trim(' ')));


                await _dbContext.Products.AddRangeAsync(products);

                await _dbContext.SaveChangesAsync();

            
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        private async Task<List<ProductIntegration>> GetAllIntegrationProducts()
        {
            return await _intgrationDbContext.ProductIntegrations.ToListAsync();
        }

        private async Task<List<Product>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }


        private async Task<int?> getUnitId(string itemNumber,List<MappingUnit> mappingUnits,List<Unit> units) 
        {

            string firstSixCharacters = itemNumber.Substring(0, Math.Min(itemNumber.Length, 6));



           var mapUnit= mappingUnits.FirstOrDefault(x => x.HS6 == firstSixCharacters);

          return mapUnit!=null?  units.FirstOrDefault(x => x.UnitOfMeasurement == mapUnit.UnitOfMeasurement)?.Id:null;
        
        }
    }
}
