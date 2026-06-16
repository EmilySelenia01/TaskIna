using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace inaApp.Entities
{
    //Niveles de acceso 
    //Public cualquier clase puede acceder a esta clase
    //Private solo las clases dentro del mismo archivo pueden acceder a esta clase
    //Internal solo se puede acceder dentro de su misma capa, son publicos 
    //Protegido solo las clases dentro del mismo proyecto y la clases que heredan 

    //[Table(name:"tbProducto")] //Data Annotations
    public class Producto {

        [Key] //Data Annotations
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(100, MinimumLength =3, ErrorMessage ="El nombre debe de tener entre 3 y 100 caracteres")]
        public string Nombre { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        public decimal Precio { get; set; }


        [Required(ErrorMessage = "El stock del producto es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public int Stock { get; set; }


        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string Descripcion {  get; set; }
        
        
        public bool Estado { get; set; } = true;


        //RELATIONSHIP BETWEEN PRODUCT AND CATEGORY
        public int IdCategoria { get; set; }
        public Categoria? Categoria { get; set; }

    }//end CLASS

}//end NAMESPACE