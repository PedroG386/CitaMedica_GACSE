using CitaMedica_API.Models;
using CitaMedica_API.Models.Dtos;
using CitaMedica_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CitaMedica_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly ICitaRepository _repository;
        public CitaController(ICitaRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<CitaController>
        [HttpGet]
        public async Task<IEnumerable<Cita>> Get()
        {
            return await _repository.GetAllAsync();
        }

        // GET api/<CitaController>/5
        [HttpGet("{id}")]
        public async Task<Cita> Get(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        // POST api/<CitaController>/agendar
        [HttpPost("agendar")]
        public async Task<IActionResult> Post([FromBody] AgendarCitaDto value)
        {
            var cita = new Cita
            {
                MedicoId = value.MedicoId,
                PacienteId = value.PacienteId,
                Fecha = value.Fecha,
                Hora = value.Hora,
                Motivo = value.Motivo,
            };

            var error = await _repository.AgendarAsync(cita);
            if (error != null)
                return Conflict(error);

            return Ok();
        }

        // PUT api/<CitaController>/cancelar/5
        [HttpPut("cancelar/{id}")]
        public async Task Cancelar(int id, [FromBody] CancelarCitaDto value)
        {
            await _repository.CancelarAsync(id, value.MotivoCancelacion);
        }
    }
}
