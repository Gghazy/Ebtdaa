using AutoMapper;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.FactoryJobs.Interfaces;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.Integration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoryJobs.Handlers
{
    public class FactoryJobService : IFactoryJobService
    {

        private readonly IEbtdaaDbContext _dbContext;
        private readonly IIntgrationDbContext _intgrationDbContext;
        public readonly IMapper _mapper;
        public FactoryJobService(IIntgrationDbContext intgrationDbContext, IEbtdaaDbContext dbContext, IMapper mapper)
        {

            _intgrationDbContext = intgrationDbContext;
            _dbContext = dbContext;
            _mapper = mapper;

        }
        public async Task<int> FactoryIntegrat()
        {
            var integrationFactories =await GetAllIntegrationFactories();
            var Factories =await GetAllFactories();



            if (Factories.Count() == 0)
            {

               await AddAllFactories(integrationFactories);
            }
            else if (integrationFactories.Count > Factories.Count)
            {
                await AddNewFactories(integrationFactories, Factories);
            }
            else {

               await Update(integrationFactories);
            }
           

            return 1;
        }
        private async Task AddAllFactories(List<FactoryIntegration> factoryIntegrations)
        {
            try
            {
                var _factories = _mapper.Map<List<Factory>>(factoryIntegrations);

                await _dbContext.Factories.AddRangeAsync(_factories);

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        private async Task Update(List<FactoryIntegration> factoryIntegrations)
        {
            foreach (var item in factoryIntegrations)
            {
                var factory =await _dbContext.Factories.FirstOrDefaultAsync(x => x.FactoryNumber == item.FactoryNumber);

                var factoryUpdated = _mapper.Map(item, factory);

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
        private async Task AddNewFactories(List<FactoryIntegration> factoryIntegrations,List<Factory> factories)
        {


            var factoryIds = factories.Select(x => x.FactoryNumber.Trim(' '));
            var newFactory = factoryIntegrations.Where(x => !factoryIds.Contains(x.FactoryNumber.Trim(' '))).ToList();

            var _factories = _mapper.Map<List<Factory>>(newFactory);

            await _dbContext.Factories.AddRangeAsync(_factories);
            try
            {
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private async Task<List<FactoryIntegration>> GetAllIntegrationFactories()
        {
            return await _intgrationDbContext.FactoryIntegrations.ToListAsync();
        }
        
        private async Task<List<Factory>> GetAllFactories()
        {
            return await _dbContext.Factories.ToListAsync();
        }



        
    }
}
