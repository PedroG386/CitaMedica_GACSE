using CitaMedica_API.Models;

namespace CitaMedica_API.Repositories;

public interface IPacienteRepository
{
    Task<IEnumerable<Paciente>> GetAllAsync();
    Task<Paciente?> GetByIdAsync(int id);
    Task AddAsync(Paciente paciente);
    Task UpdateAsync(Paciente paciente);
    Task DeleteAsync(int id);
}
