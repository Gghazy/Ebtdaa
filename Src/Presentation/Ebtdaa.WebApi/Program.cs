using Ebtdaa.Application;
using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Infrastructure;
using Ebtdaa.Persistence;
using Microsoft.IdentityModel.Tokens;
using Ebtdaa.WebApi.Jobs;
using Ebtdaa.WebApi.Middlewares;
using Ebtdaa.WebApi.Seeding;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using System.Text;
using System.Net;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddHttpClient<MyHttpClient>(client =>
{
    // Configure your HttpClient settings here
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("AppUrl"));
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});
// Add services to the container.
/*builder.Services.AddHttpClient("MyClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("AppUrl"));
});*/

builder.Services.AddControllers();

// Register HttpClient with custom handler
builder.Services.AddSingleton(new HttpClient(new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true
}));




// Register HttpClient
//builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//DependancyInjection
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddJobsConfiguration();

builder.Services.AddScoped<ExcelDataSeeder>();


builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "Issuer",
            ValidAudience = "Audience",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("SecretKey")))
        };
    }
    );




builder.Services.AddMvc().AddFluentValidation(fv =>
{
    fv.ImplicitlyValidateChildProperties = true;
}).AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseRouting();
//app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

// Globale Exeption
app.UseMiddleware<GlobalExceptionHandler>();
app.Services.CreateScope().ServiceProvider.GetRequiredService<EbtdaaDbContext>().Database.Migrate();


SeedData(app);

/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllers();
});*/
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();

#region Seed Data
void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<ExcelDataSeeder>();
        service.SeedData().Wait();
    }
}

#endregion
