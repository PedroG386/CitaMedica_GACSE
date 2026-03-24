using System.ComponentModel.DataAnnotations;

namespace CitaMedica_API.Models;

public class Paciente
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Nombre { get; set; } = string.Empty;

    public DateTime FechaNacimiento { get; set; }

    [MaxLength(20)]
    public string Telefono { get; set; } = string.Empty;

    [MaxLength(150)]
    public string CorreoElectronico { get; set; } = string.Empty;

    public ICollection<Cita> Citas { get; set; } = new List<Cita>();
}
