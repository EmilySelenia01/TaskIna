using inaApp.Common.Interfaces;
using inaApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Service
{
    public class ProductoService : IGenericService<Producto>
    {
        private readonly IGenericRepository<Producto> _productoRepository;

        public ProductoService(IGenericRepository<Producto> productoRepository)
        {
            _productoRepository = productoRepository;

        }//end method constructor

        public async Task<Producto> ActualizarAsync(Producto entity)
        {
            try {
                var exist = await _productoRepository.ObtenerPorIdAsync(entity.Id);
                
                if (exist == null)
                    throw new Exception("Producto no encontrado");

                updateProduct(exist, entity);

                return await _productoRepository.ActualizarAsync(exist);

            } catch (Exception ex) {
                // Manejar la excepción según sea necesario
                throw new Exception("Error al actualizar el producto->", ex);

            }//end method update
        }

        public async Task<Producto> CrearAsync(Producto entity)
        {
            //debemos impolementar reglas de negocio    
            return await _productoRepository.CrearAsync(entity);
        }// end method crear async

        public async Task<bool> EliminarAsync(int id)
        {
            return await _productoRepository.EliminarAsync(id);
        }//end method delete

        public async Task<Producto> ObtenerPorIdAsync(int id)
        {
            return await _productoRepository.ObtenerPorIdAsync(id);
        }//end method getById

        public async Task<List<Producto>> ObtenerTodosAsync()
        {
            return await _productoRepository.ObtenerTodosAsync();

        }//end method getAll


        //this method is responsible for update new data to the exist product  
        private void updateProduct(Producto receiver, Producto transmitter)
        {
            receiver.Nombre = transmitter.Nombre;
            receiver.Descripcion = transmitter.Descripcion;
            receiver.Precio = transmitter.Precio;
            receiver.Stock = transmitter.Stock;
            receiver.Estado = transmitter.Estado;
        }//end method updateProduct


    }//end class

}//end namespace
