using System;
using System.Collections.Generic;

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
}
