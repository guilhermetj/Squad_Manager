namespace Squad_Manager.Model.Entity
{
    public class Squad
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Leader { get; set; }
        public List<Person> Person { get; set; }
        public List<Model.Entity.Task> Task { get; set; }
    }
}
