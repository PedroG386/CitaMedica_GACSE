namespace CitasMedicas_Blazor.Client.Models;

public class Cita
{
    public int Id { get; set; }
    public int MedicoId { get; set; }
    public int PacienteId { get; set; }
    public DateTime Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public TimeSpan Duracion { get; set; }
    public TimeSpan HoraFin { get; set; }
    public string Motivo { get; set; } = string.Empty;
    public int Estado { get; set; }
    public string? MotivoCancelacion { get; set; }
    public Medico? Medico { get; set; }
    public Paciente? Paciente { get; set; }
}
