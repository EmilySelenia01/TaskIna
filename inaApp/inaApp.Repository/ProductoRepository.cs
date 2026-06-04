using inaApp.Common.Interfaces;
using inaApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Repository
{
    //ProductoRepository implementa la interfaz
    //IProductoRepository porque el Service trabaja con la interfaz.
    //Ahora se debe de relacionar en program para que cuando el servicio trabaje 
    //con la interfaz el sistema conozca que clase se esta instanciando 
    public class ProductoRepository : IProductoRepository
    {
        public Task<Producto> ActualizarAsync(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> CrearAsync(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> ObtenerPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Producto>> ObtenerTodosAsync()
        {
            throw new NotImplementedException();
        }
    }//end class
}//end namespace
