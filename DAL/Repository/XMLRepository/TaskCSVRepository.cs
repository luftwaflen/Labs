using DAL.Repository.Interfaces;
using Task = DAL.Entities.Task;

namespace DAL.Repository.XMLRepository
{
    public class TaskCSVRepository : IRepository<Task>
    {
        public void Add(Task entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Task entity)
        {
            throw new NotImplementedException();
        }
    }
}