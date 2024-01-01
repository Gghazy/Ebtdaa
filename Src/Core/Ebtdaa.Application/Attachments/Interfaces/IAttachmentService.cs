using Ebtdaa.Application.Attachments.Dtos;
using Ebtdaa.Application.Common.Dtos;
using Ebtdaa.Domain.General;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Attachments.Interfaces
{
    public interface IAttachmentService
    {
        Task<BaseResponse<Attachment>> AddAsync(IFormFile file);
        Task<AttachmentResultDto> DownloadFile(int id);
    }
}
