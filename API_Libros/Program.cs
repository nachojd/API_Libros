using Microsoft.EntityFrameworkCore;
using API_Libros.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conecto mediante la cadenaSQL
builder.Services.AddDbContext<DblibroContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

// Configuro CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("Nueva Politica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader().
        AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("Nueva Politica");

app.UseAuthorization();

app.MapControllers();

app.Run();
