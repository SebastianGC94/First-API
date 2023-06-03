using System;
using System.Collections.Generic;

namespace pruebaAPI.Models;

public partial class Comentario
{
    public int IdComentario { get; set; }

    public int? IdProducto { get; set; }

    public int? IdUsuario { get; set; }

    public string? Comentarios { get; set; }

    public virtual Producto? oProducto { get; set; }

}
