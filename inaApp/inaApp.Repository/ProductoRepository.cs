using inaApp.Common.Interfaces;
using inaApp.Data;
using inaApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Repository
{
    //ProductoRepository implementa la interfaz
    //IProductoRepository porque el Service trabaja con la interfaz.
    //Ahora se debe de relacionar en program para que cuando el servicio trabaje 
    //con la interfaz el sistema conozca que clase se esta instanciando 
    public class ProductoRepository : IGenericRepository<Producto>
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context) {
            //inyecta o setea el contexto en el repositorio
            _context = context;

        }//end method constructor

        public async Task<Producto> ActualizarAsync(Producto entity) {
            try {

                _context.Productos.Update(entity);
                await _context.SaveChangesAsync();
                return entity;

            } catch (Exception ex) {

                // Manejar la excepción según sea necesario
                throw new Exception("Error al actualizar el producto->", ex);
            }
        }//end method update


        public async Task<Producto> CrearAsync(Producto entity) {
            try {

                //aqui no es await porque es propio del contexto   
                await _context.Productos.AddAsync(entity);
                //await esperamos que se guarde por eso ponermos await 
                await _context.SaveChangesAsync();
                return entity;

            } catch (Exception ex) {
                // Manejar la excepción según sea necesario
                throw new Exception("Error al crear el producto->", ex);

            }

        }//end method crear async
        

        public async Task<bool> EliminarAsync(int id) {
            try {
                var producto = await ObtenerPorIdAsync(id);

                if (producto == null)
                    return false;
                
                producto.Estado = false;//borrado logico  

                //se hace una actualizacion del producto se cambia el estado a false 
                _context.Productos.Update(producto);
                await _context.SaveChangesAsync();
                return true;


            } catch (Exception ex) {
                // Manejar la excepción según sea necesario
                throw new Exception("Error al eliminar el producto->", ex);
            }

        }//end method crear async

        public async Task<List<Producto>> ObtenerTodosAsync() {
            try {
                return await _context.Productos.Where(p => p.Estado == true).ToListAsync();
                
            } catch (Exception ex) {
                // Manejar la excepción según sea necesario
                throw new Exception("Error al obtener el producto por ID->", ex);
            }

        }//end method crear async


        //requiero la inyeccion del dbcontext 
        public async Task<Producto> ObtenerPorIdAsync(int id) {
            try {
                //singleordefault va a buscar a la base de datos por eso lleva el await 
                var entity = await _context.Productos.Where(p => p.Id == id && p.Estado == true)
                    .SingleOrDefaultAsync();

                if (entity == null)
                    throw new Exception("Producto no encontrado");
                
                return entity;
            } catch (Exception ex) {
                // Manejar la excepción según sea necesario
                throw ex;
            }

        }//end method crear async


    }//end class
}//end namespace
