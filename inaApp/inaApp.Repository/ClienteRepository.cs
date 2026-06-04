using inaApp.Common.Interfaces;
using inaApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public Task<Cliente> ActualizarAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }//end method update

        public Task<Cliente> CrearAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }//end method create

        public Task<bool> EliminarAsync(int id)
        {
            throw new NotImplementedException();
        }//end method   delete

        public Task<Cliente> ObtenerPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }//end method getById

        public Task<List<Cliente>> ObtenerTodosAsync()
        {
            throw new NotImplementedException();
        }//end method getAll

    }//end class
}//end namespace
