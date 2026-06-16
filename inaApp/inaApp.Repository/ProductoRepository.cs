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
    public class ProductoRepository : IGenericRepository<Producto> {
 
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context) {
            _context = context;//inyecta o setea el contexto en el repositorio

        }//end METHOD


        //requiero la inyeccion del dbcontext 
        public async Task<Producto> ObtenerPorIdAsync(int id) {
            
            try {
                //singleordefault va a buscar a la base de datos por eso lleva el await 
                return await _context.Productos.AsNoTracking().Include(p => p.Categoria).Where(p => p.Id == id && p.Estado == true)
                    .SingleOrDefaultAsync();

            } catch (Exception ex) {
                throw new Exception($"Error al obtener el producto por id: {ex.Message}");
            }

        }//end METHOD

        public async Task<List<Producto>> ObtenerTodosAsync() {
            
            try {
                return await _context.Productos.AsNoTracking().Include(p => p.Categoria).Where(p => p.Estado == true).ToListAsync();

            } catch (Exception ex) {
                throw new Exception("Error al obtener el producto por ID->", ex);// Manejar la excepción según sea necesario
            }

        }//end METHOD

        public async Task<Producto> CrearAsync(Producto entity) { 
           
            try { 
                await _context.Productos.AddAsync(entity);//aqui no es await porque es propio del contexto   
                await _context.SaveChangesAsync();//await esperamos que se guarde por eso ponermos await 
                return entity;
 
            } catch (Exception ex) {
               
                throw new Exception("Error al crear el producto->", ex);
            }

        }//end METHOD


        public async Task<Producto> ActualizarAsync(Producto entity) {
            
            try {
                _context.Productos.Update(entity);
                await _context.SaveChangesAsync();
                return entity;

            } catch (Exception ex) {
                throw new Exception("Error al actualizar el producto->", ex);
            }

        }//end METHOD


        public async Task<bool> EliminarAsync(int id) { 
            
            try {
                var producto = await ObtenerPorIdAsync(id);

                if (producto == null)
                    return false;

                producto.Estado = false;//borrado logico  
                _context.Productos.Update(producto);//se hace una actualizacion del producto se cambia el estado a false 
                await _context.SaveChangesAsync();
                return true;

            } catch (Exception ex) {
                throw new Exception("Error al eliminar el producto->", ex);
            }

        }//end METHOD


        //METHOD EXTRA

        public async Task<bool> ObtenerPorNombreAsync(string nombre) {
            
            try {
                return await _context.Productos.AnyAsync(p => p.Nombre.ToLower() == nombre.ToLower() && p.Estado == true);
            
            } catch (Exception ex) {
                throw ex;
            }

        }//end METHOD


    }//end class

}//end namespace
