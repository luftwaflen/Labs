using DAL.Repository.DbRepository;
using DAL.Repository.CsvRepository;
using DAL.Repository.Interfaces;
using TaskEntity = DAL.Entities.TaskEntity;
using DAL.Repository.Changes;

namespace BLL.Services
{
    public class TaskService
    {
        private IRepository<TaskEntity, TaskEntityChange> _repository;
        private List<TaskEntity> _tasks;
        public TaskService(string connectionString, int dataSource)
        {
            switch (dataSource)
            {
                case 1:
                    _repository = new TaskRepository(connectionString);
                    break;

                case 2:
                    _repository = new TaskCsvRepository(connectionString);
                    break;

                default:
                    break;
            }

            _tasks = _repository.GetAll().ToList();
        }
        public List<TaskEntity> GetAll() => _tasks;
        public TaskEntity GetById(int id) => _tasks.FirstOrDefault(task => task.Id == id);

        public void Update(int id, string name, string description)
        {
            var task = _tasks.FirstOrDefault(task => task.Id == id);
            var oldTask = new TaskEntity
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description
            };
            task.Name = name;
            task.Description = description;

            _repository.ChangeHistory.Add(new TaskEntityChange
            {
                Operation = "Update",
                OriginObject = oldTask,
                ChangedObject = task
            });
        }

        public void Add(int id, string name, string description)
        {
            var maxId = 0;
            if (_tasks.Count > 0)
                maxId = _tasks.Max(task => task.Id);
            var newTask = new TaskEntity { Id = maxId + 1, Name = name, Description = description };
            _tasks.Add(newTask);
            _repository.ChangeHistory.Add(new TaskEntityChange
            {
                Operation = "Insert",
                ChangedObject = newTask
            });
        }

        public void Delete(int id)
        {
            _tasks.Remove(_tasks.FirstOrDefault(task => task.Id == id));
            _repository.ChangeHistory.Add(new TaskEntityChange
            {
                Operation = "Delete",
                ChangedObject = new TaskEntity { Id = id }
            });
        }

        public void CommitChanges()
        {
            _repository.CommitChanges();
        }
    }
}