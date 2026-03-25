using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CitasMedicas_Blazor.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7158")
});

builder.Services.AddScoped<MedicoService>();
builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<CitaService>();
builder.Services.AddScoped<AgendaService>();

await builder.Build().RunAsync();
