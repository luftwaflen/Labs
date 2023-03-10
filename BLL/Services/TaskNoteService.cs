using DAL.Entities;
using DAL.Repository.DbRepository;
using DAL.Repository.CsvRepository;
using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class TaskNoteService
    {
        private IRepository<TaskNote> _repository;
        private List<TaskNote> _taskNotes;
        public TaskNoteService(string connectionString)
        {
            _repository = new TaskNoteRepository(connectionString);
            //_repository = new TaskNoteCSVRepository();

            _taskNotes = _repository.GetAll().ToList();
        }
        public List<TaskNote> GetAll() => _taskNotes;

        public TaskNote GetById(int id) => _taskNotes.FirstOrDefault(note => note.Id == id);

        public void Update(int id, int taskId, int appointerId, int executorId)
        {
            var notes = _taskNotes.FirstOrDefault(note => note.Id == id);
            notes.TaskId = taskId;
            notes.AppointerId = appointerId;
            notes.ExecutorId = executorId;
            
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
            var maxId = _taskNotes.Max(note => note.Id);
            _taskNotes.Add(new TaskNote {Id = maxId+1,
                AppointerId = appointerId,
                ExecutorId = executorId,
                TaskId = taskId });
            _repository.Add(new TaskNote
            {
                TaskId = taskId,
                AppointerId = appointerId,
                ExecutorId = executorId
            });
        }

        public void Delete(int id)
        {
            _taskNotes.Remove(_taskNotes.FirstOrDefault(note => note.Id == id));
            _repository.Delete(id);
        }
    }
}