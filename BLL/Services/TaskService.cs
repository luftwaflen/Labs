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
            var dataSourceDictionary = new Dictionary<int, IRepository<TaskEntity, TaskEntityChange>>();
            dataSourceDictionary.Add(0, new TaskCsvRepository(connectionString));
            dataSourceDictionary.Add(1, new TaskRepository(connectionString));

            _repository = dataSourceDictionary[dataSource];

            _tasks = _repository.GetAll().ToList();
        }
        public List<TaskEntity> GetAll() => _tasks;
        public TaskEntity GetById(int id) => _tasks.FirstOrDefault(task => task.Id == id);
        public void Update(int id, string name, string description)
        {
            var task = _tasks.FirstOrDefault(task => task.Id == id);
            task.Name = name;
            task.Description = description;

            _repository.Update(task);
        }
        public void Add(int id, string name, string description)
        {
            var maxId = 0;
            if (_tasks.Count > 0)
                maxId = _tasks.Max(task => task.Id);
            var newTask = new TaskEntity { Id = maxId + 1, Name = name, Description = description };
            _tasks.Add(newTask);
        }
        public void Delete(int id)
        {
            var taskToDel = _tasks.FirstOrDefault(task => task.Id == id);
            _repository.Delete(taskToDel);
            //Что-то мне подсказывает, что ссылка будет проебываться
            _tasks.Remove(taskToDel);
        }
        public void CommitChanges()
        {
            _repository.CommitChanges();
        }
    }
}