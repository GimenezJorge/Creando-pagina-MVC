using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conectar_BD.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    [Required (ErrorMessage = "Este campo es requerido")]
    public string? Email { get; set; }
    
    [Display (Name = "contraseña")]
    [DataType(DataType.Password)]
    public string? Clave { get; set; }

    [Display(Name ="Repetir contraseña")]
    [DataType(DataType.Password)]

    [NotMapped]
    [Compare("Clave", ErrorMessage ="Las contraseñas no coinciden")]
    public string? ReClave { get; set; }
}
