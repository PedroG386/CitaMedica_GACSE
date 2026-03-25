using System.Net.Http.Json;
using CitasMedicas_Blazor.Client.Models;

namespace CitasMedicas_Blazor.Client.Services;

public class PacienteService
{
    private readonly HttpClient _http;

    public PacienteService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Paciente>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<Paciente>>("api/paciente") ?? new();
    }

    public async Task<Paciente?> GetByIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<Paciente>($"api/paciente/{id}");
    }

    public async Task CreateAsync(Paciente paciente)
    {
        await _http.PostAsJsonAsync("api/paciente", paciente);
    }

    public async Task UpdateAsync(int id, Paciente paciente)
    {
        await _http.PutAsJsonAsync($"api/paciente/{id}", paciente);
    }

    public async Task<string?> DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/paciente/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        return null;
    }
}
