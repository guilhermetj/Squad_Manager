using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Squad_Manager.Model.Dtos.UserDtos;
using Squad_Manager.Model.Entity;
using Squad_Manager.Repository.Interfaces;


namespace Squad_Manager.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserController(IUserRepository repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await _repository.Get();

            var userReturn = _mapper.Map<IEnumerable<UserDto>>(user);

            return userReturn.Any() ? Ok(userReturn) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var user = await _repository.GetById(id);

            var userReturn = _mapper.Map<UserDto>(user);

            return userReturn != null ? Ok(userReturn) : NotFound("User not found");
        }
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Post(UserCreateDto usercreateDto)
        {
            var user = _mapper.Map<User>(usercreateDto);

            _repository.Create(user);

            return await _repository.SaveChangesAsync() ? Ok("User created successfully") : BadRequest("Error when creating User");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UserUpdateDto userUpdateDto)
        {

            var userBanco = await _repository.GetById(id);
            if (userBanco == null) return NotFound("User not found");

            var user = _mapper.Map(userUpdateDto, userBanco);

            _repository.Update(user);

            return await _repository.SaveChangesAsync() ? Ok("User updated successfully") : BadRequest("Error when editing User");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userBanco = await _repository.GetById(id);
            if (userBanco == null) return NotFound("User not found");

            _repository.Delete(userBanco);

            return await _repository.SaveChangesAsync() ? Ok("User deleted successfully") : BadRequest("Error deleting User");
        }
    }
}
