using Microsoft.EntityFrameworkCore;
using Squad_Manager.Data;
using Squad_Manager.Model.Dtos.PersonDtos;
using Squad_Manager.Model.Dtos.UserDtos;
using Squad_Manager.Model.Entity;
using Squad_Manager.Repository.Interfaces;

namespace Squad_Manager.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SquadManagerContext _context;
        public UserRepository(SquadManagerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users
                             .Include(x => x.Person)
                             .ThenInclude(x => x.Squad)
                      .ToListAsync();
        }
        public async Task<User> GetById(int id)
        {
            return await _context.Users
                             .Include(x => x.Person)
                             .ThenInclude(x => x.Squad)
                             .Where(x => x.Id == id)
                             .FirstOrDefaultAsync();
        }
        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users
                             .Where(x => x.Email == email)
                             .FirstOrDefaultAsync();
        }
        public void Create(User user)
        {
            _context.Add(user);
        }
        public void Update(User user)
        {
            _context.Update(user);
        }
        public void Delete(User user)
        {
            _context.Remove(user);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
