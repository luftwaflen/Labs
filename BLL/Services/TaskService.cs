using DAL.Repository.DbRepository;
using DAL.Repository.CsvRepository;
using DAL.Repository.Interfaces;
using Task = DAL.Entities.Task;

namespace BLL.Services
{
    public class TaskService
    {
        private IRepository<Task> _repository;
        private List<Task> _tasks;
        public TaskService(string connectionString)
        {
            _repository = new TaskRepository(connectionString);
            //_repository = new TaskCSVRepository();

            _tasks = _repository.GetAll().ToList();
        }
        public List<Task> GetAll() => _tasks;
        public Task GetById(int id) => _tasks.FirstOrDefault(task => task.Id == id);

        public void Update(int id, string name, string description)
        {
            var task = _tasks.FirstOrDefault(task => task.Id == id);
            task.Name = name;
            task.Description = description;

            _repository.Update(new Task { Id = id, Name = name, Description = description });
        }

        public void Add(int id, string name, string description)
        {
            var maxId = 0;
            if (_tasks.Count > 0)
                maxId = _tasks.Max(task => task.Id);
            _tasks.Add(new Task { Id = maxId + 1, Name = name, Description = description });
            _repository.Add(new Task { Id = id, Name = name, Description = description });
        }

        public void Delete(int id)
        {
            _tasks.Remove(_tasks.FirstOrDefault(task => task.Id == id));
            _repository.Delete(id);
        }
    }
}