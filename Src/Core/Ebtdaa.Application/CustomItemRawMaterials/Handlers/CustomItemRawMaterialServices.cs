using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Application.CustomItemRawMaterials.Dtos;
using Ebtdaa.Application.CustomItemRawMaterials.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ebtdaa.Application.CustomItemRawMaterials.Handlers
{
    public class CustomItemRawMaterialServices : ICustomItemRawMaterialServices
    {
        private readonly IEbtdaaDbContext _dbContext;
        public readonly IMapper _mapper;

        public CustomItemRawMaterialServices(IEbtdaaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<CustomItemRawMaterialResultDto>>> GetAll()
        {
            var respose = _mapper.Map<List<CustomItemRawMaterialResultDto>>
                (await _dbContext.CustomItemRawMaterials.Where(x=>x.ItemName != "Out-licensing").ToListAsync());

            return new BaseResponse<List<CustomItemRawMaterialResultDto>>
            {
                Data = respose
            };
        }
    }
}
