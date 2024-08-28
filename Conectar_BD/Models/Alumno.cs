using System;
using System.Collections.Generic;

namespace Conectar_BD.Models;

public partial class Alumno
{
    public int Idalumno { get; set; }

    public string Apyn { get; set; } = null!;

    public int Idcurso { get; set; }

    public DateOnly Fecnac { get; set; }

    public virtual Curso IdcursoNavigation { get; set; } = null!;
}
