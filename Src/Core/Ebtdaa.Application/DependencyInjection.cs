using Ebtdaa.Application.ActualProduction.Validation;
using Ebtdaa.Application.ActualRawMaterials.Handlers;
using Ebtdaa.Application.ActualRawMaterials.Interfaces;
using Ebtdaa.Application.ActualRawMaterials.Validation;
using Ebtdaa.Application.Attachments.Handler;
using Ebtdaa.Application.Attachments.Interfaces;
using Ebtdaa.Application.Attachments.Validation;
using Ebtdaa.Application.Factories.Handlers;
using Ebtdaa.Application.Factories.Interfaces;
using Ebtdaa.Application.Factories.Validation;
using Ebtdaa.Application.FactoryContacts.Handlers;
using Ebtdaa.Application.FactoryContacts.Interfaces;
using Ebtdaa.Application.FactoryContacts.Validation;
using Ebtdaa.Application.FactoryFinancials.Handlers;
using Ebtdaa.Application.FactoryFinancials.Interfaces;
using Ebtdaa.Application.FactoryFinancials.Validation;
using Ebtdaa.Application.FactoryLocations.Handlers;
using Ebtdaa.Application.FactoryLocations.Interfaces;
using Ebtdaa.Application.FactoryLocations.Validation;
using Ebtdaa.Application.RawMaterials.Handlers;
using Ebtdaa.Application.RawMaterials.Interfaces;
using Ebtdaa.Application.RawMaterials.Validation;
using Microsoft.Extensions.DependencyInjection;


namespace Ebtdaa.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {

            #region Handler

               services.AddScoped<IFactoryService, FactoryService>();
               services.AddScoped<IAttachmentService, AttachmentService>();
               services.AddScoped<IFactoryFileService, FactoryFileService>();
               services.AddScoped<IFactoryFinancialService, FactoryFinancialService>();
               services.AddScoped<IFactoryFinancialAttachmentService, FactoryFinancialAttachmentService>();
               services.AddScoped<IFactoryLocationService, FactoryLocationService>();
               services.AddScoped<IFactoryLocationAttachmentService, FactoryLocationAttachmentService>();
               services.AddScoped<IFactoryContactService, FactoryContactService>();
               services.AddScoped<IRawMaterialService, RawMaterialServie>();
               services.AddScoped<IActualRawMaterialService, ActualRawMaterialService>();
               services.AddScoped<IActualRawFileService, ActualRawFileService>();

            #endregion

            #region Validation

                services.AddScoped<AttachmentValidator>();
                services.AddScoped<FactoryValidator>();
                services.AddScoped<FactoryFileValidator>();
                services.AddScoped<FactoryFinancialValidator>();
                services.AddScoped<FactoryFinancialAttachmentValidator>();
                services.AddScoped<ActualProductionValidator>();
                services.AddScoped<FactoryLocationValidator>();
                services.AddScoped<FactoryLocationAttachmentValidator>();
                services.AddScoped<FactoryContactValidator>();
                services.AddScoped<ActualRawMaterialValidator>();
                services.AddScoped<RawMaterialValidtor>();
                services.AddScoped<ActualRawMaterialFileValidator>();

            #endregion




            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
