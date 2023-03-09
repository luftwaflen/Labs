
using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DAL.Repository.CSVRepository
{
    public class TaskNoteCsvRepository : IRepository<TaskNote>
    {
        private string _path = "";
        public TaskNoteCsvRepository()
        {
            
        }
        public void Add(TaskNote entity)
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

        public IEnumerable<TaskNote> GetAll()
        {
            throw new NotImplementedException();
        }

        public TaskNote GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TaskNote entity)
        {
            throw new NotImplementedException();
        }
    }
}