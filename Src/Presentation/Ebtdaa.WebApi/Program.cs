using Ebtdaa.Application;
using Ebtdaa.Infrastructure;
using Ebtdaa.Persistence;
using Ebtdaa.WebApi.Jobs;
using Ebtdaa.WebApi.Middlewares;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//DependancyInjection
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddJobsConfiguration();








builder.Services.AddMvc().AddFluentValidation(fv =>
{
    fv.ImplicitlyValidateChildProperties = true;
}).AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();
app.UseAuthorization();

// Globale Exeption
app.UseMiddleware<GlobalExceptionHandler>();
app.Services.CreateScope().ServiceProvider.GetRequiredService<EbtdaaDbContext>().Database.Migrate();


app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
