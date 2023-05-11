using System;
using System.Collections.Generic;

namespace Equipos.Models;

public partial class Jugadore
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public int? IdEquipo { get; set; }

    public virtual Equipo? IdEquipoNavigation { get; set; }
}
