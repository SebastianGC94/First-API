using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace pruebaAPI.Models;


public partial class Orden
{
    public int IdOrden { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdUsuario { get; set; }

    [JsonIgnore]
    public virtual ICollection<DetallesOrden> DetallesOrdens { get; set; } = new List<DetallesOrden>();

    public virtual Usuario? oUsuario { get; set; }
}
