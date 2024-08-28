using System;
using System.Collections.Generic;

namespace Conectar_BD.Models;

public partial class Curso
{
    public int Idcurso { get; set; }

    public string Curso1 { get; set; } = null!;

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}
