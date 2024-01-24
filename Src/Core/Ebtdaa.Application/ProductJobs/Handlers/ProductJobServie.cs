using AutoMapper;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.ProductJobs.Interfaces;
using Ebtdaa.Domain.Factories.Entity;
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
            else if (integrationProducts.Count > Products.Count)
            {
                await AddNewProducts(integrationProducts, Products);
            }
            else
            {

                await Update(integrationProducts);
            }
           

            return 1;
        }
        private async Task AddAllProducts(List<ProductIntegration> productIntegrations)
        {
            var products = _mapper.Map<List<Product>>(productIntegrations);

            var factories = await _dbContext.Factories.ToListAsync();

            try
            {

                foreach (var product in products)
                {

                    var factory = factories.FirstOrDefault(x => x.CommercialRegister == product.CR);

                    product.FactoryId = factory == null?null: factory.Id;
                }

                await _dbContext.Products.AddRangeAsync(products);

                await _dbContext.SaveChangesAsync();

            
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
        private async Task AddNewProducts(List<ProductIntegration> productIntegrations, List<Product> products)
        {


            var productIds = products.Select(x => x.ItemNumber.Trim(' '));
            var newProduct = productIntegrations.Where(x => !productIds.Contains(x.ItemNumber.Trim(' '))).ToList();

            var _products = _mapper.Map<List<Product>>(newProduct);
            foreach (var product in _products)
            {
                product.FactoryId = (await _dbContext.Factories.FirstOrDefaultAsync(x => x.CommercialRegister == product.CR)).Id;
            }
            await _dbContext.Products.AddRangeAsync(_products);
            try
            {
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private async Task Update(List<ProductIntegration> productIntegrations)
        {
            var factories= await _dbContext.Factories.ToListAsync();
            var products= await _dbContext.Products.ToListAsync();

            foreach (var item in productIntegrations)
            {
                var product =  products.FirstOrDefault(x => x.ItemNumber == item.ItemNumber);

                var productUpdated = _mapper.Map(item, product);

                var factory = factories.FirstOrDefault(x => x.CommercialRegister == productUpdated.CR);

                productUpdated.FactoryId = factories==null?null: factory?.Id;

            }
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception EX)
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
    }
}
