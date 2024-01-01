using AutoMapper;
using Ebtdaa.Application.Common.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Ebtdaa.Domain.General;
using Ebtdaa.Application.Attachments.Validation;
using Ebtdaa.Application.Common.Interfaces;
using FluentValidation;
using Ebtdaa.Application.Attachments.Dtos;
using Ebtdaa.Application.Attachments.Interfaces;

namespace Ebtdaa.Application.Attachments.Handler
{
    public class AttachmentService: IAttachmentService
    {
        private readonly AttachmentValidator _attachMentValidator;
        private readonly IMapper _mapper;
        private readonly IEbtdaaDbContext _dbContext;


        public AttachmentService(
            AttachmentValidator attachMentValidator,
            IMapper mapper,
            IConfiguration configuration,
            IEbtdaaDbContext dbContext
            )
        {
            _attachMentValidator = attachMentValidator;
            _mapper = mapper;
            _dbContext = dbContext;
        }










        public async Task<BaseResponse<Attachment>> AddAsync(IFormFile file)
        {
            var path = await UploadFile(file);
            Attachment attachment = new Attachment
            {
                Name = file.FileName,
                Path = path + "/" + file.FileName

            };
            var result = await _attachMentValidator.ValidateAsync(attachment);
            if (result.IsValid == false) throw new ValidationException(result.Errors);

            await _dbContext.Attachments.AddAsync(attachment);
            await _dbContext.SaveChangesAsync();


            return new BaseResponse<Attachment>
            {
                Data = attachment
            };
        }
        public async Task<AttachmentResultDto> DownloadFile(int id)
        {
            AttachmentResultDto result = new AttachmentResultDto();
            var attachment =await _dbContext.Attachments.FindAsync(id);
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), attachment.Path);

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filepath, out var contenttype))
            {
                contenttype = "application/octet-stream";
            }

            result.File = await System.IO.File.ReadAllBytesAsync(filepath);
            result.Name = attachment.Name;
            result.Extention = contenttype;


            return result;


        }


        public async Task<string> UploadFile(IFormFile file)
        {
            string path = "";
            if (file.Length > 0)
            {
                path = "wwwroot/Files";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

            }

            return path;
        }
    }
}
