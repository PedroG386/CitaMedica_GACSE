using CitaMedica_API.Data;
using CitaMedica_API.Models;
using CitaMedica_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CitaMedica_API.Tests;

public class CitaRepositoryTests
{
    private CitaMedicaContext CrearContexto()
    {
        var options = new DbContextOptionsBuilder<CitaMedicaContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var context = new CitaMedicaContext(options);

      
        var medico = new Medico { Id = 1, Nombre = "Dr. Test", Especialidad = "Medicina General" };
        var paciente = new Paciente { Id = 1, Nombre = "Paciente Test", FechaNacimiento = new DateTime(1990, 1, 1), Telefono = "1234567890", CorreoElectronico = "test@test.com" };
        var horario = new HorarioConsulta { Id = 1, MedicoId = 1, DiaSemana = DiaSemana.Miercoles, HoraInicio = new TimeSpan(8, 0, 0), HoraFin = new TimeSpan(14, 0, 0) };

        context.Medicos.Add(medico);
        context.Pacientes.Add(paciente);
        context.HorariosConsulta.Add(horario);
        context.SaveChanges();

        return context;
    }

    [Fact]
    public async Task AgendarAsync_CitaDentroDeHorario_RetornaNull()
    {
        
        var context = CrearContexto();
        var repo = new CitaRepository(context);

        var cita = new Cita
        {
            MedicoId = 1,
            PacienteId = 1,
            Fecha = new DateTime(2026, 3, 25),
            Hora = new TimeSpan(9, 0, 0),
            Motivo = "Consulta general"
        };

       
        var resultado = await repo.AgendarAsync(cita);

  
        Assert.Null(resultado);
        Assert.Equal(EstadoCita.Programada, cita.Estado);
        Assert.Equal(TimeSpan.FromMinutes(20), cita.Duracion);
    }

    [Fact]
    public async Task AgendarAsync_CitaFueraDeHorario_RetornaMensajeError()
    {
        
        var context = CrearContexto();
        var repo = new CitaRepository(context);

      
        var cita = new Cita
        {
            MedicoId = 1,
            PacienteId = 1,
            Fecha = new DateTime(2026, 3, 25),
            Hora = new TimeSpan(18, 0, 0),
            Motivo = "Consulta fuera de horario"
        };
   
        var resultado = await repo.AgendarAsync(cita);

        Assert.NotNull(resultado);
        Assert.Contains("fuera de horario", resultado, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task CancelarAsync_CitaExistente_CambiaEstadoACancelada()
    {
        var context = CrearContexto();
        var repo = new CitaRepository(context);

        var cita = new Cita
        {
            MedicoId = 1,
            PacienteId = 1,
            Fecha = new DateTime(2026, 3, 25),
            Hora = new TimeSpan(10, 0, 0),
            Motivo = "Consulta"
        };
        await repo.AgendarAsync(cita);

        await repo.CancelarAsync(cita.Id, "Ya no puedo asistir");

        var citaCancelada = await context.Citas.FindAsync(cita.Id);
        Assert.NotNull(citaCancelada);
        Assert.Equal(EstadoCita.Cancelada, citaCancelada.Estado);
        Assert.Equal("Ya no puedo asistir", citaCancelada.MotivoCancelacion);
    }
}
