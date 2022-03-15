using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Squad_Manager.Model.Dtos.PersonDtos;
using Squad_Manager.Model.Entity;
using Squad_Manager.Repository.Interfaces;
using System.Security.Claims;

namespace Squad_Manager.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public PersonController(IPersonRepository repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var person = await _repository.Get();

            var personReturn = _mapper.Map<IEnumerable<PersonSquadUser>>(person);

            return personReturn.Any() ? Ok(personReturn) : NoContent();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _repository.GetById(id);
            if (person == null)
                return BadRequest("Person not found");

            var personReturn = _mapper.Map<PersonSquadUser>(person);

            return Ok(personReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonCreateDto personcreateDto)
        {
            var personAdd = _mapper.Map<Person>(personcreateDto);

            _repository.Create(personAdd);

            return await _repository.SaveChangesAsync() ? Ok("Person created successfully") : BadRequest("Error when creating Person");
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Create(int id, PersonUpdateDto personUpdateDto)
        {
            var person = await _repository.GetById(id);
            if (person == null)
                return BadRequest("Person not found");

            var personUpdate = _mapper.Map(personUpdateDto, person);

            _repository.Update(personUpdate);

            return await _repository.SaveChangesAsync() ? Ok("Person updated successfully") : BadRequest("Error when editing Person");
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _repository.GetById(id);
            if (person == null)
                return BadRequest("Person not found");

            _repository.Delete(person);

            return await _repository.SaveChangesAsync() ? Ok("Person Deleted successfully") : BadRequest("Error when Deleting Person");
        }


    }
}
