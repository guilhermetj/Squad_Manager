namespace Squad_Manager.Model.Entity
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int Squad_id { get; set; }
        public Squad Squad { get; set; }
    }
}
