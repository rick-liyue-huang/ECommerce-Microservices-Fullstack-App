using System.Text.Json.Serialization;
using eCommerceSolution.UsersService.API.Middlewares;
using eCommerceSolution.UsersService.Core;
using eCommerceSolution.UsersService.Core.Mappers;
using eCommerceSolution.UsersService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var licenseKey = builder.Configuration["AutoMapper:LicenseKey"];
builder.Services.AddInfrastructureServices();
builder.Services.AddCoreServices();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddAutoMapper(cfg =>
{
    cfg.LicenseKey = licenseKey;
    cfg.AddMaps(typeof(ApplicationUserMappingProfile).Assembly);
}); 

var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();