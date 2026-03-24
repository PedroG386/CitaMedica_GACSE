using CitaMedica_API.Models;
using CitaMedica_API.Models.Dtos;
using CitaMedica_API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CitaMedica_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaService _agendaService;
        public AgendaController(IAgendaService agendaService)
        {
            _agendaService = agendaService;
        }

        // POST api/agenda/citasdeldia
        [HttpPost("citasdeldia")]
        public async Task<IEnumerable<Cita>> Post([FromBody] AgendaDelDiaRequestDto value)
        {
            return await _agendaService.CitasDelDiaAsync(value.IdMedico, value.Fecha);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
