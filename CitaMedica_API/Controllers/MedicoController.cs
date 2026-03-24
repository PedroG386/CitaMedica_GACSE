using CitaMedica_API.Models;
using CitaMedica_API.Models.Dtos;
using CitaMedica_API.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CitaMedica_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoRepository _repository;
        public MedicoController(IMedicoRepository repository)
        {
            _repository= repository;
        }

        // GET: api/<MedicoController>
        [HttpGet]
       public async Task <IEnumerable<Medico>> Get() { 
            return await _repository.GetAllAsync();
        }

        // GET api/<MedicoController>/5
        [HttpGet("{id}")]
        public async Task<Medico> Get(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        // POST api/<MedicoController>
        [HttpPost]
        public async Task Post([FromBody] MedicoDto value)
        {
           var medico =  new Medico{
                Id = value.Id,
                Nombre = value.Nombre,
                Especialidad = value.Especialidad,
            };

            await _repository.AddAsync(medico);
        }

        // PUT api/<MedicoController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] MedicoDto value)
        {
            var medico = new Medico
            {
                Id = value.Id,
                Nombre = value.Nombre,
                Especialidad = value.Especialidad,
            };

            await _repository.UpdateAsync(medico);
        }

        // DELETE api/<MedicoController>/5
        [HttpDelete("{id}")]
       public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
