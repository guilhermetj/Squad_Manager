using Squad_Manager.Model.Entity;

namespace Squad_Manager.Model.Dtos.PersonDtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SquadDto Squad { get; set; }
    }
}
