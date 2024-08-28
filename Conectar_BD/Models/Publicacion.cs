using System;
using System.Collections.Generic;

namespace Conectar_BD.Models;

public partial class Publicacion
{
    public int IdPublicacion { get; set; }

    public string Especie { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string Ubicacion { get; set; } = null!;

    public string Estado { get; set; } = null!;
}
