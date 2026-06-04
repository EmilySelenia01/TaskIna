using inaApp.Common.Interfaces;
using inaApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Service
{
    public class ClienteService : IClienteService
    {
        //inyeccion de dependencias o instancia y utilizar el constructor
        public readonly IClienteRepository _clienteRepository;


        //ahora paso la inyeccion dependencia por el constructor
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


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
        }//end method delete

        public Task<Cliente> ObtenerPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }//end method getById

        public Task<List<Cliente>> ObtenerTodosAsync()
        {
            _clienteRepository.ObtenerTodosAsync();
            return null;
        }//end method getAll

    }//end class
}//end namespace
