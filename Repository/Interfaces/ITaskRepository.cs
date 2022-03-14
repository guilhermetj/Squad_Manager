namespace Squad_Manager.Repository.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Model.Entity.Task>> Get();
        Task<Model.Entity.Task> GetById(int id);
        void Create(Model.Entity.Task task);
        void Update(Model.Entity.Task task);
        void Delete(Model.Entity.Task task);
        Task<bool> SaveChangesAsync();
    }
}
