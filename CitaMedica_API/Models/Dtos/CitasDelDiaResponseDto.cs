namespace CitaMedica_API.Models.Dtos
{
    public class CitasDelDiaResponseDto
    {
        public int Id { get; set; }
        public string Medico { get; set; } = null!;
        public IEnumerable<Cita> Citas { get; set; } 
    }
}
