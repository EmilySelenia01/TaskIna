using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace inaApp.DTOs.Categoria
{
    public class CategoriaUpdateDTO {

        [Required(ErrorMessage = "El Id de la categoría es obligatorio")]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        public string NombreCategoria { get; set; }

    }//end CLASS

}//end NAMESPACE
