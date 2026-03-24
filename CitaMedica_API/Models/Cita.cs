using System.ComponentModel.DataAnnotations;

namespace CitaMedica_API.Models;

public class Cita
{
    public int Id { get; set; }

    public int MedicoId { get; set; }

    public int PacienteId { get; set; }

    public DateTime Fecha { get; set; }

    public TimeSpan Hora { get; set; }

    [Required]
    [MaxLength(500)]
    public string Motivo { get; set; } = string.Empty;

    [Required]
    public EstadoCita Estado { get; set; } = EstadoCita.Programada;

    [MaxLength(500)]
    public string? MotivoCancelacion { get; set; }

    public Medico Medico { get; set; } = null!;
    public Paciente Paciente { get; set; } = null!;
}

public enum EstadoCita
{
    Programada = 1,
    Cancelada = 2,
    Completada = 3
}
