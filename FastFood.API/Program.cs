using Repository;
using Application;
using Repository.DependencyInjection;
using Application.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var conn = builder.Configuration.GetConnectionString("DefaulConnection");
builder.Services.AddDbContext<PostgresContext>(options => options.UseNpgsql(conn));

builder.Services.AddDataBasePostgresService();
builder.Services.AddApplicationService();


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
