namespace Squad_Manager.Model.Dtos.SquadDtos
{
    public class SquadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Task> Task { get; set; }
    }
}
