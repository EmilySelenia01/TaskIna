using inaApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Common.Interfaces
{
    //Esqueleto que define la firma de los metodos
    //que se deben implementar en el repositorio de cliente
    public interface IClienteRepository
    {
        Task<List<Cliente>> ObtenerTodosAsync();

        Task<Cliente> ObtenerPorIdAsync(int id);

        Task<Cliente> CrearAsync(Cliente cliente);

        Task<Cliente> ActualizarAsync(Cliente cliente);

        Task<bool> EliminarAsync(int id);

    }//end interface
}//end namespace
