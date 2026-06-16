using inaApp.Common.Interfaces;
using inaApp.Data;
using inaApp.DTOs.Categoria;
using inaApp.DTOs.Cliente;
using inaApp.DTOs.Producto;
using inaApp.Entities;
using inaApp.Repository;
using inaApp.Service;
using inaApp.Service.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;

namespace inaAPI.Extensions
{
    public static class DependencyInyection
    {
        //agrega todos las dependencias de mi aplicacion
         //, es decir, los servicios y repositorios
        public static IServiceCollection addAplicationService(
            this IServiceCollection service, 
            IConfiguration configuration) {
            
            
            //base de datos ' dbcontext 
            //inyeccion de dependencia del string de conexion
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"));
            });


            //injections of dependency of services
            service.AddScoped<IGenericService<ClienteResponseDTO, ClienteCreateDTO, ClienteUpdateDTO>, ClienteService>();
            service.AddScoped<IGenericService<ProductoResponseDTO, ProductoCreateDTO, ProductoUpdateDTO>, ProductoService>();
            service.AddScoped<IGenericService<CategoriaResponseDTO, CategoriaCreateDTO, CategoriaUpdateDTO>, CategoriaService>();


            //injections of dependency of the repositories
            service.AddScoped<IGenericRepository<Cliente>, ClienteRepository>();
            service.AddScoped<IGenericRepository<Producto>, ProductoRepository>();
            service.AddScoped<IGenericRepository<Categoria>, CategoriaRepository>();


            //automapper
            service.AddAutoMapper(fg => { }, typeof(MappingProfile));
            return service;

        }//end METHOD addAplicationService

    }//end CLASS

}//end NAMESPACE

//Esta clase hace la inyeccion dependencia y en el controlador se consume
//Constructor crea la inyeccion 
//IConfiguration se usa para acceder a la bd con el connection string
//IServiceCollection lleva las IyD de los servicios y repositorios,
//es decir, lo que se va a inyectar en el controlador