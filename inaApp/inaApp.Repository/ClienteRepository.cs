using inaApp.Common.Interfaces;
using inaApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Repository
{
    public class ClienteRepository : IGenericRepository<Cliente>
    {
        public Task<Cliente> ActualizarAsync(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> CrearAsync(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> ObtenerPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cliente>> ObtenerTodosAsync()
        {
            throw new NotImplementedException();
        }
    
    }//end class
}//end namespace
