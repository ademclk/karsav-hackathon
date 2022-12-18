global using enoca.Models;
using enoca.Data;
using enoca.Data.Interfaces;
using enoca.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<enocaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection"));
});

builder.Services.AddScoped<IFirmaRepository, FirmaRepository>();
builder.Services.AddScoped<ISiparisRepository, SiparisRepository>();
builder.Services.AddScoped<IUrunRepository, UrunRepository>();


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
