using CitaMedica_API.Data;
using CitaMedica_API.Models;
using CitaMedica_API.Models.Dtos.StoredProceduresResult;
using Microsoft.EntityFrameworkCore;
using CitaMedica_API.Utilities;

namespace CitaMedica_API.Services
{
    public class AgendaService : IAgendaService
    {
        private readonly CitaMedicaContext _context;
        private readonly IHelpers _helpers;

        public AgendaService(CitaMedicaContext context, IHelpers helpers    )
        {
            _context = context;
            _helpers = helpers;
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

        public async Task<IEnumerable<HorarioDisponibleDto>> HorariosDisponiblesAsync(int idMedico, DateTime fecha)
        {
           var dia = _helpers.ObtieneNumeroDia(fecha.DayOfWeek.ToString());

           var horarios = await _context.Database
                .SqlQuery<HorarioDisponibleDto>($@"
                    EXEC dbo.HorariosDisponiblesMedico
                            @IdMedico={idMedico},
                            @Fecha={fecha.Date},
                            @DiaSemana={dia}").ToListAsync();

            return horarios;
            
        }
    }
}
