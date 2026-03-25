using CitaMedica_API.Models;

namespace CitaMedica_API.Repositories;

public interface IMedicoRepository
{
    Task<IEnumerable<Medico>> GetAllAsync();
    Task<Medico?> GetByIdAsync(int id);
    Task AddAsync(Medico medico);
    Task UpdateAsync(Medico medico);
    Task DeleteAsync(int id);
    Task AddHorarioAsync(HorarioConsulta horario);
}
