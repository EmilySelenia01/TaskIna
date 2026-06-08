using inaApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Common.Interfaces
{
    public interface IGenericService<E>
    {
        //parametrizando una interfaz para que me sirva de forma generica 
        //creando un solo esqueleto que me sirva para cualquier entidad,
        //en este caso E es un tipo generico que se va a reemplazar por
        //la entidad que se quiera usar
        Task<List<E>> ObtenerTodosAsync();

        Task<E> ObtenerPorIdAsync(int id);

        Task<E> CrearAsync(E entity);

        Task<E> ActualizarAsync(E entity);

        Task<bool> EliminarAsync(int id);


    }//end interface
}

//Esqueleto define la firma de los documentos
//y me dice que es lo que tiene que llevar el objeto que lo implemente
//TASK quiere decir que es un metodo asincronico

