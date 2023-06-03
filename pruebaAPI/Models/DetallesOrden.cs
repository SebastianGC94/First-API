using System;
using System.Collections.Generic;

namespace pruebaAPI.Models;

public partial class DetallesOrden
{
    public int IdDetalle { get; set; }

    public int? IdOrden { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public virtual Orden? oOrden { get; set; }

    public virtual Producto? oProducto { get; set; }
}
