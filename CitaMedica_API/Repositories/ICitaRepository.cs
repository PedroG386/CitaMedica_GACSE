using CitaMedica_API.Models;

namespace CitaMedica_API.Repositories;

public interface ICitaRepository
{
    Task<IEnumerable<Cita>> GetAllAsync();
    Task<Cita?> GetByIdAsync(int id);
    Task AgendarAsync(Cita cita);
    Task CancelarAsync(int id, string motivoCancelacion);
}
