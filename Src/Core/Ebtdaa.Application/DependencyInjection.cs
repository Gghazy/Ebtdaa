﻿using Ebtdaa.Application.ActualProduction.Validation;
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
using Ebtdaa.Application.FactoryJobs.Handlers;
using Ebtdaa.Application.FactoryJobs.Interfaces;
using Ebtdaa.Application.FactoryLocations.Handlers;
using Ebtdaa.Application.FactoryLocations.Interfaces;
using Ebtdaa.Application.FactoryLocations.Validation;
using Ebtdaa.Application.RawMaterials.Handlers;
using Ebtdaa.Application.RawMaterials.Interfaces;
using Ebtdaa.Application.RawMaterials.Validation;
using Ebtdaa.Application.ProductJobs.Handlers;
using Ebtdaa.Application.ProductJobs.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Ebtdaa.Application.UnitJobs.Interfaces;
using Ebtdaa.Application.UnitJobs.Handlers;
using Ebtdaa.Application.IndustrialAreas.Interfaces;
using Ebtdaa.Application.IndustrialAreas.Handlers;
using Ebtdaa.Application.Cities.Interfaces;
using Ebtdaa.Application.Cities.Handlers;
using Ebtdaa.Application.FactoryEntities.Interfaces;
using Ebtdaa.Application.FactoryEntities.Handlers;
using Ebtdaa.Application.ProductsData.Interfaces;
using Ebtdaa.Application.ProductsData.Handlers;
using Ebtdaa.Application.Units.Interfaces;
using Ebtdaa.Application.Units.Handlers;
using Ebtdaa.Application.ActualProduction.Interfaces;
using Ebtdaa.Application.ActualProduction.Handlers;
using Ebtdaa.Application.LogIn.Interfaces;
using Ebtdaa.Application.LogIn.Handllers;
using Ebtdaa.Application.InspectorRawMaterials.Interfaces;
using Ebtdaa.Application.InspectorRawMaterials.Handlers;
using Ebtdaa.Application.InspectorRawMaterials.Validation;
using Ebtdaa.Application.CustomItemRawMaterials.Interfaces;
using Ebtdaa.Application.CustomItemRawMaterials.Handlers;
using Ebtdaa.Application.Periods.Interfaces;
using Ebtdaa.Application.Periods.Handlers;
using Ebtdaa.Application.FactoryMonthlyFinancials.Validation;
using Ebtdaa.Application.FactoryMonthlyFinancials.Interfaces;
using Ebtdaa.Application.FactoryMonthlyFinancials.Handlers;
using Ebtdaa.Application.FactoriesUpdateStatus.Interfaces;
using Ebtdaa.Application.FactoriesUpdateStatus.Handlers;
using Ebtdaa.Application.ScreenUpdateStatus.Interfaces;
using Ebtdaa.Application.ScreenUpdateStatus.Handlers;

namespace Ebtdaa.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {

            #region Handler

               services.AddScoped<IFactoryJobService, FactoryJobService>();
               services.AddScoped<IProductJobServie, ProductJobServie>();
               services.AddScoped<IFactoryService, FactoryService>();
               services.AddScoped<IAttachmentService, AttachmentService>();
               services.AddScoped<IFactoryFileService, FactoryFileService>();
               services.AddScoped<IFactoryFinancialService, FactoryFinancialService>();
               services.AddScoped<IFactoryMonthlyFinancialService, FactoryMonthlyFinancialService>();
               services.AddScoped<IFactoryFinancialAttachmentService, FactoryFinancialAttachmentService>();
               services.AddScoped<IFactoryLocationService, FactoryLocationService>();
               services.AddScoped<IFactoryLocationAttachmentService, FactoryLocationAttachmentService>();
               services.AddScoped<IFactoryContactService, FactoryContactService>();
               services.AddScoped<IRawMaterialService, RawMaterialServie>();
               services.AddScoped<IItemAttachmentService, ItemAttachmentService>();
               services.AddScoped<IActualRawMaterialService, ActualRawMaterialService>();
               services.AddScoped<IActualRawFileService, ActualRawFileService>();
               services.AddScoped<IUnitJobService, UnitJobService>();
               services.AddScoped<IIndustrialAreaService, IndustrialAreaService>();
               services.AddScoped<ICityService, CityService>();
               services.AddScoped<IFactoryEntityService, FactoryEntityService>();
               services.AddScoped<IProductDataService, ProductDataService>();
               services.AddScoped<IUnitService, UnitService>();
               services.AddScoped<IActualProductionService, ActualProductionService>();
               services.AddScoped<IIncreaseActualProductionService, IncreaseActualProductionService>();
               services.AddScoped<IReasonService, ReasonService>();
               services.AddScoped<ILoginService, LoginService>();
               services.AddScoped<IActualProductionAttachService, ActualProductionAttachService>();
               services.AddScoped<IInspectorRawMaterialService, InspectorRawMaterialService>();
               services.AddScoped<ICustomItemRawMaterialServices, CustomItemRawMaterialServices>();
               services.AddScoped<IPeriodService, PeriodService>();
               services.AddScoped<IFactoryUpdateStatusService, FactoryUpdateStatusService>();
               services.AddScoped<IScreenStatusService, ScreenStatusService>();
               services.AddScoped<IProductPeriodActiveService, ProductPeriodActiveService>();

            #endregion

            #region Validation

                services.AddScoped<AttachmentValidator>();
                services.AddScoped<FactoryValidator>();
                services.AddScoped<FactoryFileValidator>();
                services.AddScoped<FactoryFinancialValidator>();
                services.AddScoped<FactoryFinancialAttachmentValidator>();
                services.AddScoped<FactoryMonthlyFinancialValidator>();
                services.AddScoped<ActualProductionValidator>();
                services.AddScoped<FactoryLocationValidator>();
                services.AddScoped<FactoryLocationAttachmentValidator>();
                services.AddScoped<FactoryContactValidator>();
                services.AddScoped<ActualRawMaterialValidator>();
                services.AddScoped<RawMaterialValidtor>();
                services.AddScoped<ItemAttachmentValidator>();
                services.AddScoped<ActualRawMaterialFileValidator>();
                services.AddScoped<ActualroductionAttachValidator>();
                services.AddScoped<InspectorRawMaterialValidator>();

            #endregion




            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


           
        }
    }
}
