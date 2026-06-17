using AutoMapper;
using inaApp.Common.Exception;
using inaApp.Common.Interfaces;
using inaApp.Common.Response;
using inaApp.DTOs.Cliente;
using inaApp.DTOs.Producto;
using inaApp.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace inaApp.Service
{
    public class ProductoService : IGenericService<ProductoResponseDTO, ProductoCreateDTO, ProductoUpdateDTO> {
        
        private readonly IGenericRepository<Producto> _productoRepository;
        private readonly IMapper _mapper;

        private readonly IGenericRepository<Categoria> _categoriaRepository;// provisional preguntar al profe

        //this mapper knows how to map the DTOs with the entity
        public ProductoService(IGenericRepository<Producto> productoRepository, IMapper mapper, IGenericRepository<Categoria> category) {
            _productoRepository = productoRepository;
            _mapper = mapper;
            _categoriaRepository = category;

        }//end METHOD


        public async Task<Responsee<ProductoResponseDTO>> ObtenerPorIdAsync(int id) {
            
            var pro = await _productoRepository.ObtenerPorIdAsync(id);

            if (pro is null)
                throw new NotFoundExceptionD($"El producto con id {id} no existe");//string template para el mensaje de error

            //  var productoResponse = _mapper.Map<ProductoResponseDTO>(pro);
            return new Responsee<ProductoResponseDTO> {
                Data = _mapper.Map<ProductoResponseDTO>(pro),
                Message = "Producto obtenido exitosamente",
                Success = true
            };

        }//end METHOD


        public async Task<Responsee<List<ProductoResponseDTO>>> ObtenerTodosAsync() {

            var list = await _productoRepository.ObtenerTodosAsync();
            
            if (list == null || !list.Any())
                throw new NotFoundExceptionD("No se encontraron productos.");

            var listResponse = _mapper.Map<List<ProductoResponseDTO>>(list);

            return new Responsee<List<ProductoResponseDTO>> {
                Data = listResponse,
                Message = "Productos obtenidos exitosamente",
                Success = true
            };

        }//end METHOD

        /// precio sea mayor a cero = InvalidPriceException
        /// nombre repetido no se puede crear = DuplicateProductNameException
        /// stock negativo no se puede crear = InvalidStockException
        public async Task<Responsee<ProductoResponseDTO>> CrearAsync(ProductoCreateDTO entity) {

            if (entity.Precio <= 0)
                throw new InvalidPriceException("El precio debe ser mayor a cero.");

            if (entity.Stock <= 0)
                throw new InvalidStockException("El stock no puede ser negativo y debe de ser mayor a cero.");

            var productos = await _productoRepository.ObtenerTodosAsync();
            if (productos.Any(p => p.Nombre.ToLower() == entity.Nombre.ToLower()))
                throw new DuplicateNameException("El nombre del producto ya existe.");

            var categoria = await _categoriaRepository.ObtenerPorIdAsync(entity.IdCategoria);
            if (categoria == null)
                throw new NotFoundExceptionD("La categoría no existe.");

            //_mapper.Map<LO QUE QUIERO OBTENER>(LO QUETENGO);
            // Here we tell it which mapper to use
            Producto producto = _mapper.Map<Producto>(entity);
            producto = await _productoRepository.CrearAsync(producto);

            //ProductoResponseDTO productoResponse = _mapper.Map<ProductoResponseDTO>(producto);

            return new Responsee<ProductoResponseDTO> {
                Data = _mapper.Map<ProductoResponseDTO>(producto),
                Message = "Producto obtenido exitosamente",
                Success = true
            };

        }//end METHOD


        public async Task<Responsee<ProductoResponseDTO>> ActualizarAsync(ProductoUpdateDTO entity) {

            var existProducto = await _productoRepository.ObtenerPorIdAsync(entity.Id);
            if (existProducto is null)
                throw new NotFoundExceptionD($"El producto con id {entity.Id} no existe.");

            if (entity.Precio <= 0)
                throw new InvalidPriceException("El precio debe ser mayor a cero.");

            if (entity.Stock <= 0)
                throw new InvalidStockException("El stock no puede ser negativo y debe de ser mayor a cero.");

            var existName = await _productoRepository.ObtenerTodosAsync();
            if (existName.Any(p => p.Nombre.ToLower() == entity.Nombre.ToLower() && p.Id != entity.Id))
                throw new DuplicateNameException($"El nombre {entity.Nombre} ya existe.");

            var categoria = await _categoriaRepository.ObtenerPorIdAsync(entity.IdCategoria);
            if (categoria == null)
                throw new NotFoundExceptionD("La categoría no existe.");

            var producto = _mapper.Map<Producto>(entity);
            producto = await _productoRepository.ActualizarAsync(producto);

            return new Responsee<ProductoResponseDTO> {
                Data = _mapper.Map<ProductoResponseDTO>(producto),
                Message = "Producto actualizado exitosamente",
                Success = true
            };

        }//end METHOD


        public async Task<Responsee<bool>> EliminarAsync(int id) {
            
            var producto = await _productoRepository.ObtenerPorIdAsync(id);
            if (producto is null)
                throw new NotFoundExceptionD($"El producto con id {id} no existe.");

            var result = await _productoRepository.EliminarAsync(id);

            return new Responsee<bool> {
                Data = result,
                Message = "Producto eliminado exitosamente",
                Success = result
            };

        }//end METHOD


        ////this method is responsible for update new data to the exist product  
        //private void updateProduct(Producto receiver, Producto transmitter) {
        //    receiver.Nombre = transmitter.Nombre;
        //    receiver.Descripcion = transmitter.Descripcion;
        //    receiver.Precio = transmitter.Precio;
        //    receiver.Stock = transmitter.Stock;
        //    receiver.Estado = transmitter.Estado;
        //
        //}//end METHOD

    }//end class

}//end namespace
