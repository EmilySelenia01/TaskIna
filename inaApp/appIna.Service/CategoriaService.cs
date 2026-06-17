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
    public class CategoriaService : IGenericService<CategoriaResponseDTO, CategoriaCreateDTO, CategoriaUpdateDTO> {

        private readonly IGenericRepository<Categoria> _categoriaRepository;
        private readonly IMapper _mapping;
        private readonly IGenericRepository<Producto> _productoRepository;

        //injections repository and automapper
        public CategoriaService(IGenericRepository<Categoria> categoriaRepository, IMapper mapping, IGenericRepository<Producto> productoRepository)
        {
            _categoriaRepository = categoriaRepository;
            _mapping = mapping;
            _productoRepository = productoRepository;
        }// end METHOD 


        public async Task<Responsee<CategoriaResponseDTO>> ObtenerPorIdAsync(int id) {

            if (id <= 0)
                throw new InvalidIdException("El ID debe ser un número positivo.");

            var categoria = await _categoriaRepository.ObtenerPorIdAsync(id);
            if (categoria is null)
                throw new NotFoundExceptionD($"No se encontró la categoría con ID {id}.");

            return new Responsee<CategoriaResponseDTO> {
                Data = _mapping.Map<CategoriaResponseDTO>(categoria),
                Message = "Categoría obtenida exitosamente.",
                Success = true
            };

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

        public async Task<Responsee<CategoriaResponseDTO>> CrearAsync(CategoriaCreateDTO entityDTO) {
            
            if (entityDTO is null)
                new NotFoundExceptionD($"No se encontró la categoria");

            var category = await _categoriaRepository.ObtenerTodosAsync();
            if (category.Any(c => c.NombreCategoria.ToLower() == entityDTO.NombreCategoria.ToLower()))
                throw new DuplicateNameException("El nombre de la categoría ya existe.");

            var categoria = _mapping.Map<Categoria>(entityDTO);
            categoria = await _categoriaRepository.CrearAsync(categoria);

            return new Responsee<CategoriaResponseDTO> {
                Data = _mapping.Map<CategoriaResponseDTO>(categoria),
                Message = "Categoria creada exitosamente",
                Success = true
            };

        }// end METHOD 

        public async Task<Responsee<CategoriaResponseDTO>> ActualizarAsync(CategoriaUpdateDTO entityDTO) {
            
            if (entityDTO is null)
                throw new NotFoundExceptionD($"No se encontró la categoria");

            var category = await _categoriaRepository.ObtenerTodosAsync();
            if (category.Any(c => c.NombreCategoria.ToLower() == entityDTO.NombreCategoria.ToLower()))
                throw new DuplicateNameException("El nombre de la categoría ya existe.");

            var categoryExist = await _categoriaRepository.ObtenerPorIdAsync(entityDTO.IdCategoria);
            if (categoryExist is null)
                throw new NotFoundExceptionD($"No se encontró la categoría con ID {entityDTO.IdCategoria}.");

            var categoria = _mapping.Map<Categoria>(entityDTO);
            categoria = await _categoriaRepository.ActualizarAsync(categoria);

            return new Responsee<CategoriaResponseDTO> {
                Data = _mapping.Map<CategoriaResponseDTO>(categoria),
                Message = "Categoria actualizada exitosamente",
                Success = true
            };

        }// end METHOD 

        public async Task<Responsee<bool>> EliminarAsync(int id) {

            if (id <= 0)
                throw new InvalidIdException("El ID debe ser un número positivo.");

            var categoria = await _categoriaRepository.ObtenerPorIdAsync(id);
            if (categoria is null)
                throw new NotFoundExceptionD($"No se encontró la categoría con ID {id}.");

            var productoActivo = await _productoRepository.ObtenerTodosAsync();
            if (productoActivo.Any(p => p.IdCategoria == id && p.Estado == true))
                throw new InvalidOperationException("No se puede eliminar la categoría porque tiene productos asociados.");

            var eliminarCategoria = await _categoriaRepository.EliminarAsync(id);

            return new Responsee<bool> {
                Data = eliminarCategoria,
                Message = "Categoría eliminada exitosamente.",
                Success = true
            };

        }// end METHOD 


    }// end CLASS

}//end NAMESPACE
