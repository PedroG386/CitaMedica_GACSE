using CitaMedica_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CitaMedica_API.Data;

public class CitaMedicaContext : DbContext
{
    public CitaMedicaContext(DbContextOptions<CitaMedicaContext> options) : base(options) { }

    public DbSet<Medico> Medicos => Set<Medico>();
    public DbSet<Paciente> Pacientes => Set<Paciente>();
    public DbSet<Cita> Citas => Set<Cita>();
    public DbSet<HorarioConsulta> HorariosConsulta => Set<HorarioConsulta>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HorarioConsulta>(entity =>
        {
            entity.HasOne(h => h.Medico)
                  .WithMany(m => m.HorariosConsulta)
                  .HasForeignKey(h => h.MedicoId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(h => new { h.MedicoId, h.DiaSemana, h.HoraInicio })
                  .IsUnique();
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasOne(c => c.Medico)
                  .WithMany(m => m.Citas)
                  .HasForeignKey(c => c.MedicoId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(c => c.Paciente)
                  .WithMany(p => p.Citas)
                  .HasForeignKey(c => c.PacienteId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(c => new { c.MedicoId, c.Fecha, c.Hora })
                  .IsUnique();
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasIndex(m => m.Nombre);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasIndex(p => p.CorreoElectronico)
                  .IsUnique();
        });
    }
}
