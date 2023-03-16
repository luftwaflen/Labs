
using DAL.Entities;
using DAL.Repository.Changes;
using DAL.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DAL.Repository.CsvRepository
{
    public class TaskNoteCsvRepository : IRepository<TaskNoteEntity, TaskNoteEntityChange>
    {
        private string _path = "";
        public List<TaskNoteEntityChange> ChangeHistory { get; set; }
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void CommitChanges()
        {
            throw new NotImplementedException();
        }
    }
}