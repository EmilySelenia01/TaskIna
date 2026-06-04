using inaApp.Common.Interfaces;
using inaApp.Repository;
using inaApp.Service;

var builder = WebApplication.CreateBuilder(args);

//aqui estoy haciendo la inyeccion dependencia y en el controlador se consume
//Constructor crea la inyeccion 
builder.Services.AddScoped<IProductoService, ProductoService>();
//builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

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