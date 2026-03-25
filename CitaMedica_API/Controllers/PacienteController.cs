using CitaMedica_API.Models;
using CitaMedica_API.Models.Dtos;
using CitaMedica_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CitaMedica_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _repository;
        public PacienteController(IPacienteRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<PacienteController>
        [HttpGet]
        public async Task<IEnumerable<Paciente>> Get()
        {
            return await _repository.GetAllAsync();
        }

        // GET api/<PacienteController>/5
        [HttpGet("{id}")]
        public async Task<Paciente> Get(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        // POST api/<PacienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PacienteDto value)
        {
            try
            {
                var paciente = new Paciente
                {
                    Nombre = value.Nombre,
                    FechaNacimiento = value.FechaNacimiento,
                    Telefono = value.Telefono,
                    CorreoElectronico = value.CorreoElectronico,
                };

                await _repository.AddAsync(paciente);
                return Ok();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                return BadRequest("Ya existe un paciente con ese correo electronico.");
            }
        }

        // PUT api/<PacienteController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] PacienteDto value)
        {
            var paciente = new Paciente
            {
                Id = value.Id,
                Nombre = value.Nombre,
                FechaNacimiento = value.FechaNacimiento,
                Telefono = value.Telefono,
                CorreoElectronico = value.CorreoElectronico,
            };

            await _repository.UpdateAsync(paciente);
        }

        // DELETE api/<PacienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return Ok();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                return BadRequest("No se puede eliminar el paciente porque tiene citas asociadas.");
            }
        }
    }
}
