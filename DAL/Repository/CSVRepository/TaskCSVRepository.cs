using DAL.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Task = DAL.Entities.Task;

namespace DAL.Repository.CSVRepository
{
    public class TaskCsvRepository : IRepository<Task>
    {
        private string _path;
        public TaskCsvRepository(string path)
        {
            _path = path;
        }
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