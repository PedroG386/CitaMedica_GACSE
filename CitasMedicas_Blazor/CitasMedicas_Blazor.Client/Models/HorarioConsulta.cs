namespace CitasMedicas_Blazor.Client.Models;

public class HorarioConsulta
{
    public int MedicoId { get; set; }
    public int DiaSemana { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin { get; set; }
}
