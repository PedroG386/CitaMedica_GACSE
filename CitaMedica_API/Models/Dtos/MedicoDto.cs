using System.ComponentModel.DataAnnotations;

namespace CitaMedica_API.Models.Dtos
{
    public class MedicoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;

    }
}
