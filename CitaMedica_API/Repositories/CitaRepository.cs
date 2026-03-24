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

    public async Task AgendarAsync(Cita cita)
    {
        cita.Estado = EstadoCita.Programada;
        _context.Citas.Add(cita);
        await _context.SaveChangesAsync();
    }

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
