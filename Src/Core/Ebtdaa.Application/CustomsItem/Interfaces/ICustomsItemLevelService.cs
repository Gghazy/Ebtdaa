using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Application.CustomsItem.Dtos;
using Ebtdaa.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.CustomsItem.Interfaces
{
    public interface ICustomsItemLevelService
    {
        Task<BaseResponse<QueryResult<CUstomsItemLevelResultDto>>> GetAll(CustomsItemSearch searsh);
    }
}
