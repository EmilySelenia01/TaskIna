using inaApp.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static inaApp.Common.Enums.Enumeradores;

namespace inaApp.DTOs.Cliente
{
    public class ClienteUpdateDTO {

        [Required(ErrorMessage = "El id del cliente es obligatorio.")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El tipo de identificación es obligatorio.")]
        public TipoIdentificacion TipoIdentificacion { get; set; }

        [Required(ErrorMessage = "El número de identificación es obligatorio.")]
        public string NumeroIdentificacion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El primer apellido del cliente es obligatorio.")]
        public string PrimerApellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El segundo apellido del cliente es obligatorio.")]
        public string? SegundoApellido { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "El correo del cliente es obligatorio.")]
        public string? CorreoElectronico { get; set; }

        [Phone]
        [Required(ErrorMessage = "El telefono del cliente es obligatorio.")]
        public string? Telefono { get; set; }

    }//end CLASS

}//end NAMESPACE