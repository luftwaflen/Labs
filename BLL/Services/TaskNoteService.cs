using DAL.Entities;
using DAL.Repository.DbRepository;
using DAL.Repository.CsvRepository;
using DAL.Repository.Interfaces;
using DAL.Repository.Changes;

namespace BLL.Services
{
    public class TaskNoteService
    {
        private IRepository<TaskNoteEntity, TaskNoteEntityChange> _repository;
        private List<TaskNoteEntity> _taskNotes;
        public TaskNoteService(string connectionString, int dataSource)
        {
            switch (dataSource)
            {
                case 1:
                    _repository = new TaskNoteCsvRepository();
                    break;

                default:
                    _repository = new TaskNoteRepository(connectionString);
                    break;
            }

            _taskNotes = _repository.GetAll().ToList();
        }
        public List<TaskNoteEntity> GetAll() => _taskNotes;

        public TaskNoteEntity GetById(int id) => _taskNotes.FirstOrDefault(note => note.Id == id);

        public void Update(int id, int taskId, int appointerId, int executorId)
        {
            var note = _taskNotes.FirstOrDefault(note => note.Id == id);
            var oldTaskNote = new TaskNoteEntity
            {
                Id = note.Id,
                TaskId = note.TaskId,
                AppointerId = note.AppointerId,
                ExecutorId = note.ExecutorId
            };
            note.TaskId = taskId;
            note.AppointerId = appointerId;
            note.ExecutorId = executorId;

            _repository.ChangeHistory.Add(new TaskNoteEntityChange
            {
                Operation = "Update",
                ChangedObject = note,
                OriginObject = oldTaskNote
            });
        }

        public void Add(int taskId, int appointerId, int executorId)
        {
            var maxId = _taskNotes.Max(note => note.Id);
            var newTaskNote = new TaskNoteEntity
            {
                TaskId = taskId,
                AppointerId = appointerId,
                ExecutorId = executorId
            };
            _taskNotes.Add(newTaskNote);
            _repository.ChangeHistory.Add(new TaskNoteEntityChange
            {
                Operation = "Insert",
                ChangedObject = newTaskNote
            });
        }

        public void Delete(int id)
        {
            _taskNotes.Remove(_taskNotes.FirstOrDefault(note => note.Id == id));
            _repository.ChangeHistory.Add(new TaskNoteEntityChange
            {
                Operation = "Delete",
                ChangedObject = new TaskNoteEntity { Id = id }
            });
        }

        public void CommitChanges()
        {
            _repository.CommitChanges();
        }
    }
}