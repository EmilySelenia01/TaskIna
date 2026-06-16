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
        }

        public async Task<Categoria> ObtenerPorIdAsync(int id) {
            
            try {
                return await _context.Categorias.AsNoTracking().Where(c => c.IdCategoria == id).SingleOrDefaultAsync();

            } catch (Exception ex) {
                throw new Exception($"Error al crear la categoría: {ex.Message}");
            }

        }//end METHOD

        public async Task<List<Categoria>> ObtenerTodosAsync() {
            
            try {

                return await _context.Categorias.AsNoTracking().ToListAsync();

            } catch (Exception ex) {
                throw new Exception($"Error al crear la categoría: {ex.Message}");
            }

        }//end METHOD

        public async Task<Categoria> CrearAsync(Categoria entity)
        {
            try {

                _context.Categorias.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;

            } catch (Exception ex)
            {
                throw new Exception($"Error al crear la categoría: {ex.Message}");
            }

        }//end METHOD 

        public Task<Categoria> ActualizarAsync(Categoria entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarAsync(int id)
        {
            throw new NotImplementedException();
        }//end METHOD

 
    }//end CLASS

}//end NAMESPACE
