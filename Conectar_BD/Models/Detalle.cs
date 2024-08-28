using System;
using System.Collections.Generic;

namespace Conectar_BD.Models;

public partial class Detalle
{
    public int Iddetalle { get; set; }

    public string Detalle1 { get; set; } = null!;

    public decimal Monto { get; set; }

    public int Idrecibo { get; set; }

    public virtual Recibo IdreciboNavigation { get; set; } = null!;
}
