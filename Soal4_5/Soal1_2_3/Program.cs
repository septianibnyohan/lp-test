using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Soal1_2_3.Models;
using Soal1_2_3.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// context
builder.Services.AddDbContext<LPSDbContext>(o =>
{
    o.UseSqlServer("Server=127.0.0.1,1433;Database=LPSTest;User Id=sa;Password=Septian01;TrustServerCertificate=True");
    
});

// register
builder.Services.AddScoped<IJenisBukuRepository, JenisBukuRepository>();
builder.Services.AddScoped<IBukuRepository, BukuRepository>();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowReact", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy.SetIsOriginAllowed(origin => true)
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReact");

app.UseAuthorization();

app.MapControllers();

app.Run();
