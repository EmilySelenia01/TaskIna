using inaApp.Common.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Common.Interfaces
{
    public interface IGenericService<TResponse, TCreate, TUpdate>
    {
        Task<Responsee<List<TResponse>>> ObtenerTodosAsync();
        Task<Responsee<TResponse>> ObtenerPorIdAsync(int id);
        Task<Responsee<TResponse>> CrearAsync(TCreate entity);
        Task<Responsee<TResponse>> ActualizarAsync(TUpdate entity);
        Task<Responsee<bool>> EliminarAsync(int id);

    }//end INTERFACE

}//end NAMESPACE

//Esqueleto define la firma de los documentos
//y me dice que es lo que tiene que llevar el objeto que lo implemente
//TASK quiere decir que es un metodo asincronico
//Le pasamos los dto genericos 

