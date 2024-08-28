using System;
using System.Collections.Generic;

namespace Conectar_BD.Models;

public partial class Cerveza
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Marca { get; set; }

    public int? Alcohol { get; set; }

    public int? Cantidad { get; set; }
}
