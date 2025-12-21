using System.Text.Json.Serialization;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add Controllers
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddAutoMapper(
    cfg => {}, 
    typeof(ApplicationUserMappingProfile).Assembly);
builder.Services.AddAutoMapper(
    cfg => { },
    typeof(RegisterRequestMappingProfile).Assembly);

// FluentValidation
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// register cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin() // policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();

app.UseRouting();


// swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();


// Auth
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();