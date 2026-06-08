using inaAPI.Extensions;
using inaApp.Common.Interfaces;
using inaApp.Repository;
using inaApp.Service;

var builder = WebApplication.CreateBuilder(args);

//registro contenedor de inyecciones de dependencias 
//Clase DependencyInyection se encarga de registrar los servicios y repositorios
builder.Services.addAplicationService(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();