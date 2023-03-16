using DAL.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using TaskEntity = DAL.Entities.TaskEntity;

namespace DAL.Repository.CsvRepository
{
    public class TaskCsvRepository : IRepository<TaskEntity>
    {
        private string _path;
        public TaskCsvRepository(string path)
        {
            _path = path;
        }
        public void Add(TaskEntity entity)
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

        public IEnumerable<TaskEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TaskEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TaskEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}