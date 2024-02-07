﻿using AutoMapper;
using Ebtdaa.Application.ActualProduction.Dtos;
using Ebtdaa.Application.ActualProduction.Interfaces;
using Ebtdaa.Application.ActualProduction.Validation;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Domain.ActualProduction.Entity;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ActualProduction.Handlers
{
    public class ActualProductionAttachService : IActualProductionAttachService
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;
        private readonly ActualroductionAttachValidator _validator;
        public ActualProductionAttachService(IEbtdaaDbContext dbContext, IMapper mapper, ActualroductionAttachValidator validator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<BaseResponse<List<ActualProductionAttacResultDto>>> GetAll(int factoryId)
        {
            var respose = _mapper.Map<List<ActualProductionAttacResultDto>>(await _dbContext.ActualProductionAttachments.Where(x=>x.FactoryId==factoryId).ToListAsync());

            return new BaseResponse<List<ActualProductionAttacResultDto>>
            {
                Data = respose
            };
        }

        public async Task<BaseResponse<ActualProductionAttacResultDto>> AddAsync(ActualProductionAttacRequestDto req)
        {
            var file = _mapper.Map<ActualProductionAttachment>(req);
            var result = await _validator.ValidateAsync(file);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.ActualProductionAttachments.AddAsync(file);

            await _dbContext.SaveChangesAsync();
            return new BaseResponse<ActualProductionAttacResultDto>
            {
                Data = _mapper.Map<ActualProductionAttacResultDto>(file)
            };
        }

       public async Task<BaseResponse<ActualProductionAttacResultDto>> DeleteAsync(int id)
        {
            var file = await _dbContext.ActualProductionAttachments.FindAsync(id);

            _dbContext.ActualProductionAttachments.Remove(file);

            await _dbContext.SaveChangesAsync();

            return new BaseResponse<ActualProductionAttacResultDto>
            {
                Data = _mapper.Map<ActualProductionAttacResultDto>(file)
            };
        }
    }
}
