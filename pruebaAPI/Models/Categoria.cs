using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace pruebaAPI.Models;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? Descripcion { get; set; }

    //para evitar que en postman se vea este elemento vacio
    [JsonIgnore]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
