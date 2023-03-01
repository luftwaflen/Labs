using DAL.Entities;
using DAL.Repository.BDRepository;
using DAL.Repository.CSVRepository;
using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class TaskNoteService
    {
        private IRepository<TaskNote> _repository;
        public TaskNoteService()
        {
            _repository = new TaskNoteRepository();
            //_repository = new TaskNoteCSVRepository();
        }
        public List<TaskNote> GetAll()
        {
            var taskNotes = _repository.GetAll();
            return taskNotes.ToList();
        }

        public void GetById(int id)
        {
            _repository.GetById(id);
        }

        public void Update(int id, int taskId, int appointerId, int executorId)
        {
            _repository.Update(new TaskNote
            {
                Id = id,
                TaskId = taskId,
                AppointerId = appointerId,
                ExecutorId = executorId
            });
        }

        public void Add(int taskId, int appointerId, int executorId)
        {
            _repository.Add(new TaskNote
            {
                TaskId = taskId,
                AppointerId = appointerId,
                ExecutorId = executorId
            });
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}