using AutoMapper;
using inaApp.DTOs.Categoria;
using inaApp.DTOs.Cliente;
using inaApp.DTOs.Producto;
using inaApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Service.Mapping
{
    //objeto propio del automapper se encarga de
    //configurar todas las entidades para saber de que a que se tiene que mappear
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //DTO CREATE A ENTITY
            //origen - destino
            //_mapper.Map<LO QUE QUIERO OBTENER>(LO QUETENGO);
            //lo que tengo , lo que quiero obtener
            CreateMap<ProductoCreateDTO,Producto>();
            CreateMap<ClienteCreateDTO, Cliente>();
            CreateMap<CategoriaCreateDTO, Categoria>();

            //DTOs uPDATE A ENTITY
            CreateMap<ProductoUpdateDTO, Producto>();
            CreateMap<ClienteUpdateDTO, Cliente>();
            CreateMap<CategoriaUpdateDTO, Categoria>();

            //ENTITY A DTO RESPONSE
            CreateMap<Producto, ProductoResponseDTO>();
            CreateMap<Cliente, ClienteResponseDTO>();
            CreateMap<Categoria, CategoriaResponseDTO>();

        }//end METHOD

    }//end CLASS mapping profile

}//end NAMESPACE
