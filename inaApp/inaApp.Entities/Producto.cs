using System;
using System.Collections.Generic;
using System.Text;

namespace inaApp.Entities
{
    //Niveles de acceso 
    //Public cualquier clase puede acceder a esta clase
    //Private solo las clases dentro del mismo archivo pueden acceder a esta clase
    //Internal solo se puede acceder dentro de su misma capa, son publicos 
    //Protegido solo las clases dentro del mismo proyecto y la clases que heredan 
    public class Producto
    {
        /*Antes se trabajaba de esta manera
         * 
         * propiedades son variables que describen las caracteristicas de un obj
        private int id;
        private string nombre;
        private string precio;
        private string descripcion;
        private bool estado;

        //propiedesades automaticas son propoiedades que no necesitan un campo privado 

        public int getId() {return id; }

        */

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Descripcion {  get; set; }
        public bool Estado { get; set; }


    }//end class
     
}//end namespace
