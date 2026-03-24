using CitaMedica_API.Data;
using CitaMedica_API.Models;
using CitaMedica_API.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CitaMedica_API.Services
{
    public class AgendaService : IAgendaService
    {
        private readonly CitaMedicaContext _context;

        public AgendaService(CitaMedicaContext context)
        {
           _context = context;
        }

        public async Task<IEnumerable<Cita>> CitasDelDiaAsync(int idMedico, DateTime fecha)
        {
            return await _context.Citas
                .Include(m => m.Medico)
                .Include(p => p.Paciente)
                .Where(x => x.MedicoId == idMedico && x.Fecha.Date == fecha.Date)
                .OrderBy(x => x.Hora)
                .ToListAsync();
        }

        public async Task<IEnumerable<Cita>> HistorialCitasAsync(int idPaciente)
        {
            return await _context.Citas.Where(x => x.PacienteId==idPaciente).ToListAsync();
        }

        public Task<IEnumerable<HorarioConsulta>> HorariosDisponiblesAsync(int idMedico, DateTime fecha)
        {
            throw new NotImplementedException();
        }
    }
}
