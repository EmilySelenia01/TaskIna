using inaApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Common.Interfaces
{
    public interface IProductoRepository
    {
        //Esqueleto define la firma de los documentos
        //y me dice que es lo que tiene que llevar el objeto que lo implemente
        //TASK quiere decir que es un metodo asincronico

        Task<List<Producto>> ObtenerTodosAsync();

        Task<Producto> ObtenerPorIdAsync(int id);

        Task<Producto> CrearAsync(Producto producto);

        Task<Producto> ActualizarAsync(Producto producto);

        Task<bool> EliminarAsync(int id);

    }
}
