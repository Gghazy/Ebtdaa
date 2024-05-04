using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.Inspectors.Dtos;
using Ebtdaa.Application.Inspectors.Interfaces;
using Ebtdaa.Application.Inspectors.Validation;
using Ebtdaa.Domain.Inspectors.Entity;
using Ebtdaa.Domain.RawMaterials.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Inspectors.Handlers
{
    public class InspectorService : IInspectorService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly InspectorValidator _inspectorValidator;

        public InspectorService (IEbtdaaDbContext dbContext, IMapper mapper, InspectorValidator inspectorValidator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _inspectorValidator = inspectorValidator;
        }

        public async Task<BaseResponse<List<InspectorResultDto>>> GetAll()
        {
            var resonse = await _dbContext.Inspectors.ToListAsync();
            var respose = _mapper.Map<List<InspectorResultDto>>(resonse);

            return new BaseResponse<List<InspectorResultDto>>
            {
                Data = respose
            };
        }

        public async Task<BaseResponse<InspectorResultDto>> GetOne(int id)
        {
            var result = await _dbContext.Inspectors
                .Include(x=> x.InspectorFactories)
                .ThenInclude(x=>x.Factories)
                .FirstOrDefaultAsync(x => x.Id == id);

            return new BaseResponse<InspectorResultDto>
            {
                Data = _mapper.Map<InspectorResultDto>(result)
            };
        }

        public async Task<BaseResponse<InspectorResultDto>> AddAsync(InspectorRequestDto req)
        {
            var inspector = _mapper.Map<Inspector>(req);
            var result = await _inspectorValidator.ValidateAsync(inspector);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.Inspectors.AddAsync(inspector);
                await _dbContext.SaveChangesAsync();
                foreach (var item in req.FactoryIds)
            {
                InspectorFactory inspectorFactory = new InspectorFactory();
                inspectorFactory.FactoryId = item;
                inspectorFactory.InspectorId = inspector.Id;

                await _dbContext.InspectorFactories.AddAsync(inspectorFactory);

            }


            await _dbContext.SaveChangesAsync();
                
            return new BaseResponse<InspectorResultDto>
            {
                Data = _mapper.Map<InspectorResultDto>(inspector)
            };
            
        }

        public async Task<BaseResponse<InspectorResultDto>> UpdateAsync(InspectorRequestDto req)
        {
            var getInspector = await _dbContext.Inspectors
                                    .Include(x=>x.InspectorFactories)           
                                    .FirstOrDefaultAsync(x => x.Id == req.Id);
            var inspectorUpdated = _mapper.Map(req, getInspector);

            // Validation
            var result = await _inspectorValidator.ValidateAsync(inspectorUpdated);
            if (result.IsValid == false) throw new ValidationException(result.Errors);
            await _dbContext.SaveChangesAsync();

            _dbContext.InspectorFactories.RemoveRange(getInspector.InspectorFactories);
            foreach (var item in req.FactoryIds)
            {
                InspectorFactory inspectorFactory = new InspectorFactory();
                inspectorFactory.FactoryId = item;
                inspectorFactory.InspectorId = req.Id;

                await _dbContext.InspectorFactories.AddAsync(inspectorFactory);

            }
            await _dbContext.SaveChangesAsync();

            return new BaseResponse<InspectorResultDto>
            {
                Data = _mapper.Map<InspectorResultDto>(inspectorUpdated)
            };
        }

        public async Task<BaseResponse<InspectorResultDto>> DeleteAsync(int id)
        {
            var inspector = await _dbContext.Inspectors.FindAsync(id);

            _dbContext.Inspectors.Remove(inspector);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<InspectorResultDto>
            {
                Data = _mapper.Map<InspectorResultDto>(inspector)
            };
        }

        public async Task<BaseResponse<InspectorFactoriesResultDto>> AssingFactoriesAsync(InspectorFactoriesRequestDto req)
        {
            InspectorFactory inspectorFactory = new InspectorFactory();
            foreach (var item in req.FactoryIds)
            {
                inspectorFactory.FactoryId = item.FactoryId;
                inspectorFactory.InspectorId = req.InspectorId;

                await _dbContext.InspectorFactories.AddAsync(inspectorFactory);

            }

            await _dbContext.InspectorFactories.AddAsync(inspectorFactory);

            await _dbContext.SaveChangesAsync();
            return new BaseResponse<InspectorFactoriesResultDto>
            {
                Data = _mapper.Map<InspectorFactoriesResultDto>(inspectorFactory)
            };
        }

        public async Task<BaseResponse<List<InspectorFactoriesResultDto>>> GetInspectorFactories(string InspectorId)
        {

            var result = await _dbContext.InspectorFactories
                 .Include(x => x.Factories)
                 .Where(x => x.Inspector.OwnerIdentity == InspectorId)
                 .Select(x => new InspectorFactoriesResultDto
                 {
                     InspectorId = x.Id,
                     FactoryId = x.FactoryId,
                     FactoryName = x.Factories.NameAr,
                     CommerialNumber = x.Factories.CommercialRegister,
                     CityName = x.Factories.FactoryLocations.Select(x=>x.City.NameAr).First(),
                 })
                 .ToListAsync();

            return new BaseResponse< List<InspectorFactoriesResultDto>>
            {
                Data = _mapper.Map <List<InspectorFactoriesResultDto>>(result)
            };
            
        }
    }
}
