using Squad_Manager.Model.Entity;

namespace Squad_Manager.Repository.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> Get();
        Task<Person> GetById(int id);
        void Create(Person person);
        void Update(Person person);
        void Delete(Person person);
        Task<bool> SaveChangesAsync();
    }
}
