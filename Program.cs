global using QSWebAPI.Data;
global using Microsoft.EntityFrameworkCore;
using QSWebAPI.Models;
using QSWebAPI.Repositories;
using QSWebAPI.Repositories.Base;
using QSWebAPI.Services;
using QSWebAPI.Services.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IService<User>, UserService>(); 
builder.Services.AddScoped<IRepository<User>, UserRepository>(); 

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