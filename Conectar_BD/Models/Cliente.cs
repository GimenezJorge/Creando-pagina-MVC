using System;
using System.Collections.Generic;

namespace Conectar_BD.Models;

public partial class Cliente
{
    public int Idclientes { get; set; }

    public string Cliente1 { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string? Localidad { get; set; }

    public virtual ICollection<Recibo> Recibos { get; set; } = new List<Recibo>();
}
