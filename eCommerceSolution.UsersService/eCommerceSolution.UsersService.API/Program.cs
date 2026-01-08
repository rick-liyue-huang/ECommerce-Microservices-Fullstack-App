using eCommerceSolution.UsersService.API.Middlewares;
using eCommerceSolution.UsersService.Core;
using eCommerceSolution.UsersService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices();
builder.Services.AddCoreServices();
builder.Services.AddControllers();


var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();