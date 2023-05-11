using System;
using System.Collections.Generic;

namespace Equipos.Models;

public partial class Equipo
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Ciudad { get; set; }

    public virtual ICollection<Jugadore> Jugadores { get; set; } = new List<Jugadore>();
}
