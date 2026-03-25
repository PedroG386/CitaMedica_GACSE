using CitaMedica_API.Models;
using CitaMedica_API.Models.Dtos;
using CitaMedica_API.Models.Dtos.StoredProceduresResult;

namespace CitaMedica_API.Services
{
    public interface IAgendaService
    {
        Task<IEnumerable<Cita>> CitasDelDiaAsync(int idMedico, DateTime fecha);
        Task<IEnumerable<Cita>> HistorialCitasAsync(int idPaciente);
        Task<IEnumerable<HorarioDisponibleDto>> HorariosDisponiblesAsync(int idMedico, DateTime fecha);
    }
}

