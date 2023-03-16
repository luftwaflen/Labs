
using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DAL.Repository.CsvRepository
{
    public class TaskNoteCsvRepository : IRepository<TaskNoteEntity>
    {
        private string _path = "";
        public TaskNoteCsvRepository()
        {
            
        }
        public void Add(TaskNoteEntity entity)
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

        public IEnumerable<TaskNoteEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TaskNoteEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TaskNoteEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}