namespace Squad_Manager.Model.Dtos.TaskDtos
{
    public class TaskCreateDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int Squad_id { get; set; }
    }
}
