using Microsoft.EntityFrameworkCore;
using ReadingCorpBookApp.Domain.Models;
using ReadingCorpBookApp.Service.Data;
using ReadingCorpBookApp.Service.Infrastructure.Contract;
using ReadingCorpBookApp.Service.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add DbContext Connection string
builder.Services.AddDbContext<BookDbContext>
    (s => s.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnString")));
//Resolve Dependency Injection
builder.Services.AddScoped<IBaseRepository<Book>, BookRepository>();
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
