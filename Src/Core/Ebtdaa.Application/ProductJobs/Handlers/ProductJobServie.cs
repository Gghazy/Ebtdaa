using AutoMapper;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.ProductJobs.Interfaces;
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
            else
            {

                await Update(integrationProducts);
            }
            if (integrationProducts.Count > Products.Count)
            {
                await AddNewProducts(integrationProducts, Products);
            }

            return 1;
        }
        private async Task AddAllProducts(List<ProductIntegration> productIntegrations)
        {
            var products = _mapper.Map<List<Product>>(productIntegrations);

            await _dbContext.Products.AddRangeAsync(products);

            await _dbContext.SaveChangesAsync();
        }
        private async Task AddNewProducts(List<ProductIntegration> productIntegrations, List<Product> products)
        {


            var productIds = products.Select(x => x.ItemNumber.Trim(' '));
            var newProduct = productIntegrations.Where(x => !productIds.Contains(x.ItemNumber.Trim(' '))).ToList();

            var _products = _mapper.Map<List<Product>>(newProduct);

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
            foreach (var item in productIntegrations)
            {
                var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.ItemNumber == item.ItemNumber);

                var productUpdated = _mapper.Map(item, product);

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
