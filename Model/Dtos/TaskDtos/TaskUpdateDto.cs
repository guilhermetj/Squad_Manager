namespace Squad_Manager.Model.Dtos.TaskDtos
{
    public class TaskUpdateDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}
