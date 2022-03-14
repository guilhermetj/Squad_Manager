using Squad_Manager.Model.Entity;

namespace Squad_Manager.Repository.Interfaces
{
    public interface ISquadRepository
    {
        Task<IEnumerable<Squad>> Get();
        Task<Squad> GetById(int id);
        void Create(Squad person);
        void Update(Squad person);
        void Delete(Squad person);
        Task<bool> SaveChangesAsync();
    }
}
