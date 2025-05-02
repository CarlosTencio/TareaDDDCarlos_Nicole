using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TareaDDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController:ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] PersonDTO person)
        {
            if (person == null)
            {
                return BadRequest("Person is null");
            }
            await _personService.AddAsync(person);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<PersonDTO>> GetAllAsync()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDTO>> GetByIdAsync(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PersonDTO person)
        {
            if (person == null)
            {
                return BadRequest("Person is null");
            }
            await _personService.UpdateAsync(person);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            await _personService.DeleteAsync(id);
            return Ok();
        }
    }
}
