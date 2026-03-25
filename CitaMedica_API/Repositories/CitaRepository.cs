using CitaMedica_API.Data;
using CitaMedica_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CitaMedica_API.Repositories;

public class CitaRepository : ICitaRepository
{
    private readonly CitaMedicaContext _context;

    public CitaRepository(CitaMedicaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cita>> GetAllAsync()
    {
        return await _context.Citas
            .Include(c => c.Medico)
            .Include(c => c.Paciente)
            .ToListAsync();
    }

    public async Task<Cita?> GetByIdAsync(int id)
    {
        return await _context.Citas
            .Include(c => c.Medico)
            .Include(c => c.Paciente)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<string?> AgendarAsync(Cita cita)
    {
        //primera regla de negocio, valida si la cita esta dentro del horario del medico
        if (!await ValidaProgramacionMedico(cita))
            return "Cita fuera de horario del medico.";

        //segunda regla de negocio, valida si el medico de la cita, no tiene otra en el mismo horario
        if (!await ValidaProgramacionCita(cita))
            return "El medico ya tiene una cita programada en ese horario.";

        //tercera regla de negocio, asignar duracion y hora fin segun la especialidad del medico
        var medico = await _context.Medicos.FindAsync(cita.MedicoId);
        cita.Duracion = ObtieneDuracionEspecialidad(medico!.Especialidad);
        cita.HoraFin = cita.Hora.Add(cita.Duracion);

        cita.Estado = EstadoCita.Programada;
        _context.Citas.Add(cita);
        await _context.SaveChangesAsync();
        return null;
    }


    private async Task<bool> ValidaProgramacionCita(Cita cita)
    {
        var existeCitaEnMismoHorario = await _context.Citas
            .AnyAsync(c => c.MedicoId == cita.MedicoId
                        && c.Fecha.Date == cita.Fecha.Date
                        && c.Hora == cita.Hora
                        && c.Estado == EstadoCita.Programada);

        return !existeCitaEnMismoHorario;
    }

    private static TimeSpan ObtieneDuracionEspecialidad(string especialidad) =>
        especialidad.ToLowerInvariant() switch
        {
            "medicina general" => TimeSpan.FromMinutes(20),
            "cardiologia" or "cardiología" => TimeSpan.FromMinutes(30),
            "cirugia" or "cirugía" => TimeSpan.FromMinutes(45),
            "pediatria" or "pediatría" => TimeSpan.FromMinutes(20),
            "ginecologia" or "ginecología" => TimeSpan.FromMinutes(30),
            "traumatologia" or "traumatología" => TimeSpan.FromMinutes(35),
            _ => TimeSpan.FromMinutes(30)
        };

    private async Task <bool> ValidaProgramacionMedico(Cita cita)
    {

        var numeroDiaCita = ObtieneNumeroDia(cita.Fecha.DayOfWeek.ToString());

        var horarioMedico = await _context.HorariosConsulta
              .FirstOrDefaultAsync(h => h.MedicoId == cita.MedicoId && h.DiaSemana == numeroDiaCita
              && (cita.Hora>=h.HoraInicio&&cita.Hora<=h.HoraFin));

        return horarioMedico != null;

    }

    private DiaSemana ObtieneNumeroDia(string dia) =>
      dia.ToLowerInvariant() switch
      {
          "lunes" or "monday" => DiaSemana.Lunes,

          "martes" or "tuesday" => DiaSemana.Martes,

          "miercoles" or "miércoles" or "wednesday" => DiaSemana.Miercoles,

          "jueves" or "thursday" => DiaSemana.Jueves,

          "viernes" or "friday" => DiaSemana.Viernes,

          "sabado" or "sábado" or "saturday" => DiaSemana.Sabado,

          "domingo" or "sunday" => DiaSemana.Domingo,

          _ => throw new ArgumentException($"Día no válido: {dia}")
      };

    

    public async Task CancelarAsync(int id, string motivoCancelacion)
    {
        var cita = await _context.Citas.FindAsync(id);
        if (cita == null)
            throw new KeyNotFoundException($"No se encontró la cita con Id {id}");

        cita.Estado = EstadoCita.Cancelada;
        cita.MotivoCancelacion = motivoCancelacion;
        await _context.SaveChangesAsync();
    }
}
