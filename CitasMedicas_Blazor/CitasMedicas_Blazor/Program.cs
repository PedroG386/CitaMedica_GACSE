using CitasMedicas_Blazor.Client.Pages;
using CitasMedicas_Blazor.Client.Services;
using CitasMedicas_Blazor.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7158")
});
builder.Services.AddScoped<MedicoService>();
builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<CitaService>();
builder.Services.AddScoped<AgendaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(CitasMedicas_Blazor.Client._Imports).Assembly);

app.Run();
