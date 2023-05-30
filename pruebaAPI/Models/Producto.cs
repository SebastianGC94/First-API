using System;
using System.Collections.Generic;

namespace pruebaAPI.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Codigo { get; set; }

    public string? Descripcion { get; set; }

    public string? Marca { get; set; }

    public int? IdCategoria { get; set; }

    public decimal? Precio { get; set; }

    public virtual Categoria? oCategoria { get; set; }
}
