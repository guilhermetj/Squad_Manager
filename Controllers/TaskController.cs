using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Squad_Manager.Model.Dtos.TaskDtos;
using Squad_Manager.Repository.Interfaces;

namespace Squad_Manager.Controllers
{

    [ApiController]
    [Route("Api/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskRepository _repository;
        private readonly IMapper _mapper;
        public TaskController(ITaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var task = await _repository.Get();

            var taskRetrun = _mapper.Map<IEnumerable<TaskDto>>(task);

            return taskRetrun.Any() ? Ok(taskRetrun) : NoContent();
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _repository.GetById(id);
            if (task == null)
                return BadRequest("Task not found");

            var squadReturn = _mapper.Map<TaskDto>(task);

            return Ok(squadReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateDto taskcreateDto)
        {
            var taskAdd = _mapper.Map<Model.Entity.Task>(taskcreateDto);

            _repository.Create(taskAdd);

            return await _repository.SaveChangesAsync() ? Ok("Task created successfully") : BadRequest("Error when creating Task");
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Create(int id, TaskUpdateDto taskUpdateDto)
        {
            var task = await _repository.GetById(id);
            if (task == null)
                return BadRequest("task not found");

            var taskUpdate = _mapper.Map(taskUpdateDto, task);

            _repository.Update(taskUpdate);

            return await _repository.SaveChangesAsync() ? Ok("task updated successfully") : BadRequest("Error when editing task");
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _repository.GetById(id);
            if (task == null)
                return BadRequest("Task not found");

            _repository.Delete(task);

            return await _repository.SaveChangesAsync() ? Ok("task Deleted successfully") : BadRequest("Error when Deleting task");
        }
    }
}

