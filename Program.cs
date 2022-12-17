using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using enoca.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UrunlerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UrunlerContext") ?? throw new InvalidOperationException("Connection string 'UrunlerContext' not found.")));
builder.Services.AddDbContext<FirmaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FirmaContext") ?? throw new InvalidOperationException("Connection string 'FirmaContext' not found.")));
builder.Services.AddDbContext<SiparisContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SiparisContext") ?? throw new InvalidOperationException("Connection string 'SiparisContext' not found.")));
// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
