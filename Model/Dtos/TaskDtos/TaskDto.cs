﻿namespace Squad_Manager.Model.Dtos.TaskDtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}
