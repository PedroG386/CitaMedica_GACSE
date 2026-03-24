using CitaMedica_API.Data;
using CitaMedica_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CitaMedica_API.Repositories;

public class PacienteRepository : IPacienteRepository
{
    private readonly CitaMedicaContext _context;

    public PacienteRepository(CitaMedicaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Paciente>> GetAllAsync()
    {
        return await _context.Pacientes.ToListAsync();
    }

    public async Task<Paciente?> GetByIdAsync(int id)
    {
        return await _context.Pacientes.FindAsync(id);
    }

    public async Task AddAsync(Paciente paciente)
    {
        _context.Pacientes.Add(paciente);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Paciente paciente)
    {
        _context.Pacientes.Update(paciente);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var paciente = await _context.Pacientes.FindAsync(id);
        if (paciente != null)
        {
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
        }
    }
}
