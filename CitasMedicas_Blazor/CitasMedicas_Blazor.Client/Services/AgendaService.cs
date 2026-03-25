using System.Net.Http.Json;
using CitaMedica_API.Models.Dtos.StoredProceduresResult;
using CitasMedicas_Blazor.Client.Models;

namespace CitasMedicas_Blazor.Client.Services;

public class AgendaService
{
    private readonly HttpClient _http;

    public AgendaService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Cita>> CitasDelDiaAsync(int idMedico, DateTime fecha)
    {
        var request = new { IdMedico = idMedico, Fecha = fecha };
        var response = await _http.PostAsJsonAsync("api/agenda/citasdeldia", request);
        return await response.Content.ReadFromJsonAsync<List<Cita>>() ?? new();
    }

    public async Task<List<Cita>> HistorialCitasAsync(int idPaciente)
    {
        return await _http.GetFromJsonAsync<List<Cita>>($"api/agenda/historialcitas/{idPaciente}") ?? new();
    }

    public async Task<List<HorarioDisponibleDto>> HorariosDisponiblesMedicos(int idMedico, DateTime fecha)
    {
        var request = new { IdMedico = idMedico, Fecha = fecha };
        var response = await _http.PostAsJsonAsync("api/agenda/horariosdisponibles", request);
        return await response.Content.ReadFromJsonAsync<List<HorarioDisponibleDto>>() ?? new();
    }
}
