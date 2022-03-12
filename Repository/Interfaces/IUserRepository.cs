using Squad_Manager.Model.Dtos.UserDtos;
using Squad_Manager.Model.Entity;

namespace Squad_Manager.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> Get();
        Task<User> GetById(int id);
        void Create(User user);
        void Update(User user);
        void Delete(User user);

        Task<bool> SaveChangesAsync();
    }
}
