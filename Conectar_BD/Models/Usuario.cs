using System;
using System.Collections.Generic;

namespace Conectar_BD.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Email { get; set; }

    public string? Clave { get; set; }
}
