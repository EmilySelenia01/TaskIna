using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Common.Interfaces
{
    public interface IGenericRepository<E>
    {
        //parametrizando una interfaz para que me sirva de forma generica 
        //creando un solo esqueleto que me sirva para cualquier entidad,
        //en este caso E es un tipo generico que se va a reemplazar por
        //la entidad que se quiera usar
        Task<List<E>> ObtenerTodosAsync();

        Task<E> ObtenerPorIdAsync(int id);

        Task<E> CrearAsync(E entity);

        Task<E> ActualizarAsync( E entity);

        Task<bool> EliminarAsync(int id);
    }
}
