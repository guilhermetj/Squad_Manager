using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Squad_Manager.Model;
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
        private readonly AuthenticatedUser _user;

        public SquadController(ISquadRepository repository, IMapper mapper, AuthenticatedUser user)
        {
            _repository = repository;
            _mapper = mapper;
            _user = user;
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
            var userAuth = _user.Name;
            var squadnew = new Squad
            {
                Name = squadcreateDto.Name,
                Leader = userAuth
            };
            _repository.Create(squadnew);

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
