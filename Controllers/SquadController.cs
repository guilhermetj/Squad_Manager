using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Squad_Manager.Model.Dtos.SquadDtos;
using Squad_Manager.Model.Entity;
using Squad_Manager.Repository.Interfaces;

namespace Squad_Manager.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class SquadController : Controller
    {
        private readonly ISquadRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public SquadController(ISquadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var squad = await _repository.Get();

            var squadRetrun = _mapper.Map<IEnumerable<SquadDto>>(squad);

            return squadRetrun.Any() ? Ok(squadRetrun) : NoContent();
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var squad = await _repository.GetById(id);
            if (squad == null)
                return BadRequest("Squad not found");

            var squadReturn = _mapper.Map<SquadDto>(squad);

            return Ok(squadReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SquadCreateDto squadcreateDto)
        {
            var squadAdd = _mapper.Map<Squad>(squadcreateDto);

            _repository.Create(squadAdd);

            return await _repository.SaveChangesAsync() ? Ok("Squad created successfully") : BadRequest("Error when creating Squad");
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Create(int id, SquadUpdateDto squadUpdateDto)
        {
            var squad = await _repository.GetById(id);
            if (squad == null)
                return BadRequest("Squad not found");

            var squadUpdate = _mapper.Map(squadUpdateDto, squad);

            _repository.Update(squadUpdate);

            return await _repository.SaveChangesAsync() ? Ok("Squad updated successfully") : BadRequest("Error when editing Squad");
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var squad = await _repository.GetById(id);
            if (squad == null)
                return BadRequest("Squad not found");

            _repository.Delete(squad);

            return await _repository.SaveChangesAsync() ? Ok("Squad Deleted successfully") : BadRequest("Error when Deleting Squad");
        }
    }
}
