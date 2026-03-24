using CitaMedica_API.Data;
using CitaMedica_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CitaMedica_API.Repositories;

public class MedicoRepository : IMedicoRepository
{
    private readonly CitaMedicaContext _context;

    public MedicoRepository(CitaMedicaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Medico>> GetAllAsync()
    {
        return await _context.Medicos
            .Include(m => m.HorariosConsulta)
            .ToListAsync();
    }

    public async Task<Medico?> GetByIdAsync(int id)
    {
        return await _context.Medicos
            .Include(m => m.HorariosConsulta)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddAsync(Medico medico)
    {
        _context.Medicos.Add(medico);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Medico medico)
    {
        _context.Medicos.Update(medico);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var medico = await _context.Medicos.FindAsync(id);
        if (medico != null)
        {
            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();
        }
    }
}
