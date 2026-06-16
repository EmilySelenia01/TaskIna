using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace inaApp.DTOs.Categoria
{
    public class CategoriaCreateDTO {

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        public string NombreCategoria { get; set; }

    }//end CLASS

}//end NAMESPACE
