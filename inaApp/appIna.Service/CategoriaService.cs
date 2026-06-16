using AutoMapper;
using inaApp.Common.Exception;
using inaApp.Common.Interfaces;
using inaApp.Common.Response;
using inaApp.DTOs.Categoria;
using inaApp.DTOs.Cliente;
using inaApp.Entities;
using inaApp.Repository;
using inaApp.Service.Mapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Service
{
    public class CategoriaService : IGenericService<CategoriaResponseDTO, CategoriaCreateDTO, CategoriaUpdateDTO>
    {

        private readonly IGenericRepository<Categoria> _categoriaRepository;
        private readonly IMapper _mapping;

        //injections repository and automapper
        public CategoriaService(IGenericRepository<Categoria> categoriaRepository, IMapper mapping) {
            _categoriaRepository = categoriaRepository;
            _mapping = mapping;

        }// end METHOD 


        public Task<Responsee<CategoriaResponseDTO>> ObtenerPorIdAsync(int id)
        {
            throw new NotImplementedException();

        }// end METHOD 

        public async Task<Responsee<List<CategoriaResponseDTO>>> ObtenerTodosAsync() {
            var categorias = await _categoriaRepository.ObtenerTodosAsync();

            if (categorias == null || !categorias.Any())
                throw new NotFoundExceptionD("No se encontraron categorias registradas.");

            return new Responsee<List<CategoriaResponseDTO>> {
                Data = _mapping.Map<List<CategoriaResponseDTO>>(categorias),
                Success = true,
                Message = "Categorias obtenidas exitosamente"
            };

        }// end METHOD 

        public async Task<Responsee<CategoriaResponseDTO>> CrearAsync(CategoriaCreateDTO entity) {
            if (entity is null)
                new NotFoundExceptionD($"No se encontró la categoria");

            var categoria = _mapping.Map<Categoria>(entity);
            categoria = await _categoriaRepository.CrearAsync(categoria);

            return new Responsee<CategoriaResponseDTO> {
                Data = _mapping.Map<CategoriaResponseDTO>(categoria),
                Message = "Categoria creada exitosamente",
                Success = true
            };

        }// end METHOD 

        public Task<Responsee<CategoriaResponseDTO>> ActualizarAsync(CategoriaUpdateDTO entity)
        {
            throw new NotImplementedException();

        }// end METHOD 

        public Task<Responsee<bool>> EliminarAsync(int id)
        {
            throw new NotImplementedException();

        }// end METHOD 


    }// end CLASS

}//end NAMESPACE
