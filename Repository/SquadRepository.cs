using Microsoft.EntityFrameworkCore;
using Squad_Manager.Data;
using Squad_Manager.Model.Entity;
using Squad_Manager.Repository.Interfaces;

namespace Squad_Manager.Repository
{
    public class SquadRepository : ISquadRepository
    {
        private readonly SquadManagerContext _context;
        public SquadRepository(SquadManagerContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Squad>> Get()
        {
            return await _context.Squads
                           .Include(x => x.Task)
                           .ToListAsync();
        }

        public async Task<Squad> GetById(int id)
        {
            return await _context.Squads
                           .Include(x => x.Task)
                           .Where(x => x.Id == id)
                           .FirstOrDefaultAsync();
        }
        public void Create(Squad person)
        {
            _context.Add(person);
        }

        public void Update(Squad person)
        {
            _context.Update(person);
        }

        public void Delete(Squad person)
        {
            _context.Remove(person);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
