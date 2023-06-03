using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace pruebaAPI.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Identificacion { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Direccion { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
}
