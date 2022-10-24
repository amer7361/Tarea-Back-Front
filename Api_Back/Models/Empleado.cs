using System;
using System.Collections.Generic;

namespace TareaBackFront.Models
{
    public partial class Empleado
    {
        public int IdEmpleado { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public int? IdPuesto { get; set; }
        public string? Dpi { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaIngresoRegresitro { get; set; }
    }
}
