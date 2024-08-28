using System;
using System.Collections.Generic;

namespace Conectar_BD.Models;

public partial class Recibo
{
    public int Idrecibos { get; set; }

    public string Nro { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public int Idcliente { get; set; }

    public decimal Total { get; set; }

    public virtual ICollection<Detalle> Detalles { get; set; } = new List<Detalle>();

    public virtual Cliente IdclienteNavigation { get; set; } = null!;
}
