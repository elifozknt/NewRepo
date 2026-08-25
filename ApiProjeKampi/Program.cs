using System.Reflection;
using FluentValidation;
using ApiProjeKampi.ValidationRules;
using ApiProjeKampi.Context;
using ApiProjeKampi.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApiContext>();

builder.Services.AddScoped<IValidator<Product>, ProductValidator>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//pnfgthyujı
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


