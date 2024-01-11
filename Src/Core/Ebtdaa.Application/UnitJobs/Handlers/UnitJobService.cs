using AutoMapper;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.UnitJobs.Interfaces;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.Integration;
using Microsoft.EntityFrameworkCore;


namespace Ebtdaa.Application.UnitJobs.Handlers
{
    public class UnitJobService : IUnitJobService
    {

        private readonly IEbtdaaDbContext _dbContext;
        private readonly IIntgrationDbContext _intgrationDbContext;
        public readonly IMapper _mapper;
        public UnitJobService(IIntgrationDbContext intgrationDbContext, IEbtdaaDbContext dbContext, IMapper mapper)
        {

            _intgrationDbContext = intgrationDbContext;
            _dbContext = dbContext;
            _mapper = mapper;

        }

        public async Task<int> UnitIntegrat()
        {
            var integrationUnits = await GetAllIntegrationUnits();
            var units = await GetAllUnits();



            if (units.Count() == 0)
            {

                await AddAllUnits(integrationUnits);
            }
            else if (integrationUnits.Count > units.Count)
            {
                await AddNewUnits(integrationUnits, units);
            }
            else
            {

                await Update(integrationUnits);
            }
           

            return 1;
        }

        private async Task AddAllUnits(List<UnitIntegration> unitIntegrations)
        {
            var _units = _mapper.Map<List<Unit>>(unitIntegrations);

            await _dbContext.Units.AddRangeAsync(_units);

            await _dbContext.SaveChangesAsync();
        }

        private async Task Update(List<UnitIntegration> unitIntegrations)
        {
            foreach (var item in unitIntegrations)
            {
                var unit = await _dbContext.Units.FirstOrDefaultAsync(x => x.Id == item.Id);

                var unitUpdated = _mapper.Map(item, unit);

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

        private async Task AddNewUnits(List<UnitIntegration> unitIntegrations, List<Unit> units)
        {


            var unitIds = units.Select(x => x.Id);
            var newUnits = unitIntegrations.Where(x => !unitIds.Contains(x.Id)).ToList();

            var _units = _mapper.Map<List<Unit>>(newUnits);

            await _dbContext.Units.AddRangeAsync(_units);
            try
            {
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async Task<List<UnitIntegration>> GetAllIntegrationUnits()
        {
            return await _intgrationDbContext.UnitIntegrations.ToListAsync();
        }

        private async Task<List<Unit>> GetAllUnits()
        {
            return await _dbContext.Units.ToListAsync();
        }
    }
}
