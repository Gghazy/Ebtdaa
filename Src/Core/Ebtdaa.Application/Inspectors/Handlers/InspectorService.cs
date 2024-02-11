using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.Inspectors.Dtos;
using Ebtdaa.Application.Inspectors.Interfaces;
using Ebtdaa.Application.Inspectors.Validation;
using Ebtdaa.Domain.Inspectors.Entity;
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
            var respose = _mapper.Map<List<InspectorResultDto>>(await _dbContext.Inspectors.ToListAsync());

            return new BaseResponse<List<InspectorResultDto>>
            {
                Data = respose
            };
        }

        public async Task<BaseResponse<InspectorResultDto>> GetOne(int id)
        {
            var result = await _dbContext.Inspectors.FirstOrDefaultAsync(x => x.Id == id);

            return new BaseResponse<InspectorResultDto>
            {
                Data = _mapper.Map<InspectorResultDto>(result)
            };
        }

        public async Task<BaseResponse<InspectorResultDto>> AddAsync(InspectorRequestDto req)
        {
            Inspector inspector = _mapper.Map<Inspector>(req);
            var result = await _inspectorValidator.ValidateAsync(inspector);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.Inspectors.AddAsync(inspector);

            await _dbContext.SaveChangesAsync();
            return new BaseResponse<InspectorResultDto>
            {
                Data = _mapper.Map<InspectorResultDto>(inspector)
            };
        }

        public async Task<BaseResponse<InspectorResultDto>> UpdateAsync(InspectorRequestDto req)
        {
            var getInspector = await _dbContext.Inspectors.FirstOrDefaultAsync(x => x.Id == req.Id);
            var inspectorUpdated = _mapper.Map(req, getInspector);

            // Validation
            var result = await _inspectorValidator.ValidateAsync(inspectorUpdated);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

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
    }
}
