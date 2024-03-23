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
                Path = path + "/" + file.FileName,
                Extension= GetFileExtension(file)

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
        public async Task<ImageResultDto> DownloadImageBas64(int id)
        {
            ImageResultDto result = new ImageResultDto();
            var attachment =await _dbContext.Attachments.FindAsync(id);
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), attachment.Path);

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filepath, out var contenttype))
            {
                contenttype = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
            result.Image= Convert.ToBase64String(bytes);

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

        public string GetFileExtension(IFormFile file)
        {
            // Method 1: Using Path.GetExtension
            string extension = Path.GetExtension(file.FileName);

            // Method 2: Using ContentType
            // Note: ContentType is not always reliable, but it can give you a hint about the file type
            // Ensure you sanitize and validate it properly before usage
            string contentType = file.ContentType;
            string[] contentTypeParts = contentType.Split('/');
            if (contentTypeParts.Length == 2)
            {
                extension = "." + contentTypeParts[1];
            }

            // Method 3: Using Stream's first few bytes
            // Read the first few bytes of the stream and analyze to get the file extension
            // Note: This method is more accurate but requires more code
            // You might need to add more checks and validations
            using (var reader = new BinaryReader(file.OpenReadStream()))
            {
                byte[] headerBytes = new byte[4]; // Adjust the number of bytes according to the file types you're supporting
                reader.Read(headerBytes, 0, headerBytes.Length);
                string header = string.Join("", headerBytes.Select(b => b.ToString("X2")));
                // Compare headers to known file signatures to determine the file type and its extension
                switch (header)
                {
                    // Example: JPEG
                    case "FFD8FF":
                        extension = ".jpg";
                        break;
                        // Add more cases for other file types as needed
                }
            }

            return extension;
        }
    }
}
