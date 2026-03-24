using CitaMedica_API.Models;
using CitaMedica_API.Models.Dtos;

namespace CitaMedica_API.Services
{
    public interface IAgendaService
    {
        Task<IEnumerable<Cita>> CitasDelDiaAsync(int idMedico, DateTime fecha);
        Task<IEnumerable<Cita>> HistorialCitasAsync(int idPaciente);
        Task<IEnumerable<HorarioConsulta>> HorariosDisponiblesAsync(int idMedico, DateTime fecha);
    }
}

