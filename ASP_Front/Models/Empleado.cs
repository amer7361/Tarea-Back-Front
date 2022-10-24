using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Front.Models
{
    public class Empleado
    {
        
        public int IdEmpleado { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Apellido { get; set; }
        [Required]
        public string? Direccion { get; set; }
        [Required]
        public string? Telefono { get; set; }
        [Required]
        public int? IdPuesto { get; set; }
        [Required]
        public string? Dpi { get; set; }

        [Required]
        public DateTime? FechaNacimiento { get; set; }
        [Required]
        public DateTime? FechaIngresoRegresitro { get; set; }
    }

    public class EmpleadoResponse
    {
        public int IdEmpleado { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public int? IdPuesto { get; set; }
        public string? Dpi { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime? FechaIngresoRegresitro { get; set; }
        public string Puesto { get; set; }
    }


    public class EmpleadoViewModel
    {
        public int IdEmpleado { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public int? IdPuesto { get; set; }
        public string? Dpi { get; set; }
        public string FechaNacimiento { get; set; }
        public DateTime? FechaIngresoRegresitro { get; set; }
        public string Puesto { get; set; }
    }
}
