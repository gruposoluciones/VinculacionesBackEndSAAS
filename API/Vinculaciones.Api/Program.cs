using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vinculaciones.Application;
using Vinculaciones.Application.gateways;
using Vinculaciones.Application.gateways.Auth;
using Vinculaciones.Application.interfaces;
using Vinculaciones.Persistence;
using Vinculaciones.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddDbContext<VinculacionesDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
