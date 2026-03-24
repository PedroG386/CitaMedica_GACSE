namespace CitaMedica_API.Models.Dtos
{
    public class AgendarCitaDto
    {
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string Motivo { get; set; } = string.Empty;
    }

    public class CancelarCitaDto
    {
        public string MotivoCancelacion { get; set; } = string.Empty;
    }
}
