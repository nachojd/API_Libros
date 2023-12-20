using System;
using System.Collections.Generic;

namespace API_Libros.Models;

public partial class Libro
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Autor { get; set; }

    public string? Imagen { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public int? Estrellas { get; set; }
}
