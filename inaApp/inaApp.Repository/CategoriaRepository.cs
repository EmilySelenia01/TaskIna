using inaApp.Common.Interfaces;
using inaApp.Data;
using inaApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Repository
{
    public class CategoriaRepository : IGenericRepository<Categoria>
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext context) {
            _context = context;

        }//end METHOD

        public async Task<Categoria> ObtenerPorIdAsync(int id) {
            
            try {
                return await _context.Categorias.AsNoTracking().Where(c => c.IdCategoria == id && c.Estado == true).SingleOrDefaultAsync();

            } catch (Exception ex) {
                throw new Exception($"Error al crear la categoría: {ex.Message}");
            }

        }//end METHOD

        public async Task<List<Categoria>> ObtenerTodosAsync() {
            
            try {

                return await _context.Categorias.AsNoTracking().Where(c => c.Estado == true).ToListAsync();

            } catch (Exception ex) {
                throw new Exception($"Error al crear la categoría: {ex.Message}");
            }

        }//end METHOD

        public async Task<Categoria> CrearAsync(Categoria entity) {
            
            try {

                _context.Categorias.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;

            } catch (Exception ex)
            {
                throw new Exception($"Error al crear la categoría: {ex.Message}");
            }

        }//end METHOD 


        public async Task<Categoria> ActualizarAsync(Categoria entity) {
            
            try {
                _context.Categorias.Update(entity);
                await _context.SaveChangesAsync();
                return entity;

            } catch (Exception ex) {
                throw new Exception($"Error al actualizar la categoría: {ex.Message}");
            }

        }//end METHOD


        public async Task<bool> EliminarAsync(int id) {
            
            try {
                var categoria = await ObtenerPorIdAsync(id);
                if (categoria == null)
                    throw new Exception("Categoría no encontrada");
                
                categoria.Estado = false;//delete logic by change the state
                _context.Categorias.Update(categoria);
                await _context.SaveChangesAsync();
                return true;

            } catch (Exception ex) {
                throw new Exception($"Error al eliminar la categoría: {ex.Message}");
            }

        }//end METHOD

 
    }//end CLASS

}//end NAMESPACE
