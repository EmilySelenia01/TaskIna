using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace inaApp.Entities
{
    public class Categoria {

        [Key] //Data Annotations
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre de la categoría debe tener entre 3 y 50 caracteres")]
        public string NombreCategoria { get; set; }

        public ICollection<Producto> Productos { get; set; } = new List<Producto>();

    }//end CLASS

}//end NAMESPACE
