using Microsoft.EntityFrameworkCore;
using Squad_Manager.Data;
using Squad_Manager.Repository.Interfaces;

namespace Squad_Manager.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly SquadManagerContext _context;
        public TaskRepository(SquadManagerContext context)
        {
            _context = context;
        }
        public void Create(Model.Entity.Task task)
        {
            _context.Add(task);
        }
        public void Delete(Model.Entity.Task task)
        {
           _context.Remove(task);
        }

        public async Task<IEnumerable<Model.Entity.Task>> Get()
        {
            return await _context.Tasks
                             .Include(x => x.Squad)
                      .ToListAsync();
        }

        public async Task<Model.Entity.Task> GetById(int id)
        {
            return await _context.Tasks
                             .Include(x => x.Squad)
                             .Where(x => x.Id == id)
                      .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Model.Entity.Task task)
        {
            _context.Update(task);
        }
    }
}
