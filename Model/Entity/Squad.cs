namespace Squad_Manager.Model.Entity
{
    public class Squad
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Leader { get; set; }
        public List<Person> Person { get; set; }
        public List<Task> Task { get; set; }
    }
}
