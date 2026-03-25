namespace CitaMedica_API.Models.Dtos
{
    public class HorarioConsultaDto
    {
        public int MedicoId { get; set; }
        public int DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}
