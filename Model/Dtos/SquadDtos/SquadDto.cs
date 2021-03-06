using Squad_Manager.Model.Dtos.PersonDtos;
using Squad_Manager.Model.Dtos.TaskDtos;

namespace Squad_Manager.Model.Dtos.SquadDtos
{
    public class SquadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Leader { get; set; }
        public List<PersonDto> Person { get; set; }
        public List<TaskDto> Task { get; set; }
    }
}
