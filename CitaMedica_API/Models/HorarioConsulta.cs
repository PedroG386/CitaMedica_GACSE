using System.ComponentModel.DataAnnotations;

namespace CitaMedica_API.Models;

public class HorarioConsulta
{
    public int Id { get; set; }

    public int MedicoId { get; set; }

    [Required]
    public DiaSemana DiaSemana { get; set; }

    public TimeSpan HoraInicio { get; set; }

    public TimeSpan HoraFin { get; set; }

    public Medico Medico { get; set; } = null!;
}

public enum DiaSemana
{
    Lunes = 1,
    Martes = 2,
    Miercoles = 3,
    Jueves = 4,
    Viernes = 5,
    Sabado = 6,
    Domingo = 7
}
