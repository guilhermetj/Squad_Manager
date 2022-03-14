namespace Squad_Manager.Model.Entity
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Squad_Id { get; set; }
        public Squad Squad { get; set; }
        public User User { get; set; }
    }
}
