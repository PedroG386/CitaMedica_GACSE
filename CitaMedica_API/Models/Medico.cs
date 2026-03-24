using System.ComponentModel.DataAnnotations;

namespace CitaMedica_API.Models;

public class Medico
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Especialidad { get; set; } = string.Empty;

    public ICollection<HorarioConsulta> HorariosConsulta { get; set; } = new List<HorarioConsulta>();
    public ICollection<Cita> Citas { get; set; } = new List<Cita>();
}
