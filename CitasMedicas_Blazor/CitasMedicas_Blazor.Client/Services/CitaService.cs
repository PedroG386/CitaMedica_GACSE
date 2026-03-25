using System.Net.Http.Json;
using CitasMedicas_Blazor.Client.Models;

namespace CitasMedicas_Blazor.Client.Services;

public class CitaService
{
    private readonly HttpClient _http;

    public CitaService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Cita>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<Cita>>("api/cita") ?? new();
    }

    public async Task<Cita?> GetByIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<Cita>($"api/cita/{id}");
    }

    public async Task<string?> AgendarAsync(Cita cita)
    {
        var response = await _http.PostAsJsonAsync("api/cita/agendar", new
        {
            cita.MedicoId,
            cita.PacienteId,
            cita.Fecha,
            cita.Hora,
            cita.Motivo
        });

        if (!response.IsSuccessStatusCode)
            return await response.Content.ReadAsStringAsync();

        return null;
    }

    public async Task CancelarAsync(int id, string motivoCancelacion)
    {
        await _http.PutAsJsonAsync($"api/cita/cancelar/{id}", new { MotivoCancelacion = motivoCancelacion });
    }
}
