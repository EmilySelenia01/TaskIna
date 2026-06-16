using AutoMapper;
using inaApp.Common.Enums;
using inaApp.Common.Exception;
using inaApp.Common.Interfaces;
using inaApp.Common.Response;
using inaApp.DTOs.Cliente;
using inaApp.DTOs.Producto;
using inaApp.Entities;
using inaApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using static inaApp.Common.Enums.Enumeradores;

namespace inaApp.Service
{
    public class ClienteService : IGenericService<ClienteResponseDTO, ClienteCreateDTO, ClienteUpdateDTO>
    {
        //injection of the interface of the repository and automapper 
        private readonly IGenericRepository<Cliente> _clienteRepository;
        private readonly IMapper _mapper;
        

        //now we can access the repository through the interface  
        public ClienteService(IGenericRepository<Cliente> clienteRepository, IMapper mapper) {
            _clienteRepository = clienteRepository;
            _mapper = mapper;

        }//end METHOD


        //We contacted the repository and then checked if there data in the database.
        public async Task<Responsee<List<ClienteResponseDTO>>> ObtenerTodosAsync() {
            
            var client = await _clienteRepository.ObtenerTodosAsync();

            if (client == null || !client.Any() ) 
                throw new NotFoundExceptionD("No se encontraron clientes.");
          
            return new Responsee<List<ClienteResponseDTO>> {
                Data = _mapper.Map<List<ClienteResponseDTO>>(client),
                Message = "Clientes obtenidos exitosamente.",
                Success = true
            };

        }//end METHOD 


        public async Task<Responsee<ClienteResponseDTO>> ObtenerPorIdAsync(int id) {

            if (id <= 0)
                throw new InvalidIdException("El ID debe ser un número positivo.");

            var client = await _clienteRepository.ObtenerPorIdAsync(id);

            if (client is null)
                throw new NotFoundExceptionD($"No se encontró el cliente con ID {id}.");

            return new Responsee<ClienteResponseDTO> {
                Data = _mapper.Map<ClienteResponseDTO>(client),
                Message = "Clientes obtenidos exitosamente.",
                Success = true
            };

        }//end METHOD


        public async Task<Responsee<ClienteResponseDTO>> CrearAsync(ClienteCreateDTO clienteDTO) {

            ValidarIdentificacion(clienteDTO.TipoIdentificacion, clienteDTO.NumeroIdentificacion);

            var client = await _clienteRepository.ObtenerTodosAsync();
            if (client.Any(c => c.NumeroIdentificacion == clienteDTO.NumeroIdentificacion))
                throw new InvalidExceptionData("Ya existe un cliente con el mismo numero de identificacion.");
            

            var clientes = _mapper.Map<Cliente>(clienteDTO);
            clientes = await _clienteRepository.CrearAsync(clientes);
            
            return new Responsee<ClienteResponseDTO> {
                Data = _mapper.Map<ClienteResponseDTO>(clientes),
                Message = "Clientes obtenidos exitosamente.",
                Success = true
            };

        }//end METHOD


        public async Task<Responsee<ClienteResponseDTO>> ActualizarAsync(ClienteUpdateDTO clienteDTO) {

            ValidarIdentificacion(clienteDTO.TipoIdentificacion, clienteDTO.NumeroIdentificacion);

            if (clienteDTO.IdCliente <= 0)
                throw new InvalidIdException("El ID debe ser un número positivo");

            var clienteExistente = await _clienteRepository.ObtenerPorIdAsync(clienteDTO.IdCliente);
            if (clienteExistente is null)
                throw new NotFoundExceptionD($"No se encontró el cliente con ID {clienteDTO.IdCliente}.");
            

            var cliente = _mapper.Map<Cliente>(clienteDTO);
            cliente = await _clienteRepository.ActualizarAsync(cliente);
           
            return new Responsee<ClienteResponseDTO> {
                Data = _mapper.Map<ClienteResponseDTO>(cliente),
                Message = "Clientes obtenidos exitosamente.",
                Success = true
            };

        }//end METHOD


        public async Task<Responsee<bool>> EliminarAsync(int id) {

            if (id <= 0)
                throw new InvalidIdException("El ID debe ser un número positivo.");

            var client = await _clienteRepository.ObtenerPorIdAsync(id);
            if (client is null)
                throw new NotFoundExceptionD($"No se encontró el cliente con ID {id}.");

            var eliminado = await _clienteRepository.EliminarAsync(id);

            return new Responsee<bool> {
                Data = eliminado,
                Message = "Clientes obtenidos exitosamente.",
                Success = true
            };

        }//end METHOD


        private void ValidarIdentificacion(TipoIdentificacion tipoIdentificacion, string numeroIdentificacion)
        {

            if (!Enum.IsDefined(typeof(TipoIdentificacion), tipoIdentificacion))
                throw new InvalidExceptionData("El tipo de identificación no es válido. Solo se permite: " +
                                                "\n1:Cedula." +
                                                "\n2:Dimex" +
                                                "\n3:Pasaporte" +
                                                "\n4:RUC");

            if (!string.IsNullOrWhiteSpace(numeroIdentificacion) && !numeroIdentificacion.All(char.IsDigit))
                throw new InvalidExceptionData("El número de identificación debe contener únicamente números.");

        }//end METHOD private

    }//end CLASS

}//end NAMESPACE
