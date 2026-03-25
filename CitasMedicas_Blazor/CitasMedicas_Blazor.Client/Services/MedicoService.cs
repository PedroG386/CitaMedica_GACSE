using System.Net.Http.Json;
using CitasMedicas_Blazor.Client.Models;

namespace CitasMedicas_Blazor.Client.Services;

public class MedicoService
{
    private readonly HttpClient _http;

    public MedicoService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Medico>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<Medico>>("api/medico") ?? new();
    }

    public async Task<Medico?> GetByIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<Medico>($"api/medico/{id}");
    }

    public async Task CreateAsync(Medico medico)
    {
        await _http.PostAsJsonAsync("api/medico", medico);
    }

    public async Task UpdateAsync(int id, Medico medico)
    {
        await _http.PutAsJsonAsync($"api/medico/{id}", medico);
    }

    public async Task DeleteAsync(int id)
    {
        await _http.DeleteAsync($"api/medico/{id}");
    }

    public async Task AddHorarioAsync(HorarioConsulta horario)
    {
        await _http.PostAsJsonAsync("api/medico/horario", horario);
    }
}
