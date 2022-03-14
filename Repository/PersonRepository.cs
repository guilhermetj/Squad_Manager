using Microsoft.EntityFrameworkCore;
using Squad_Manager.Data;
using Squad_Manager.Model.Entity;
using Squad_Manager.Repository.Interfaces;

namespace Squad_Manager.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly SquadManagerContext _context;
        public PersonRepository(SquadManagerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> Get()
        {
            return await _context.Persons
                             .Include(x => x.Squad)
                             .Include(x => x.User)
                                .ToListAsync();
        }
        public async Task<Person> GetById(int id)
        {
            return await _context.Persons
                             .Include(x => x.Squad)
                             .Include(x => x.User)
                             .Where(x => x.Id == id)
                             .FirstOrDefaultAsync();
        }


        public void Create(Person person)
        {
             _context.Add(person);
        }
        public void Update(Person person)
        {
            _context.Update(person);
        }
        public void Delete(Person person)
        {
            _context.Remove(person);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
