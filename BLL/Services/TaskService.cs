using DAL.Repository.BDRepository;
using DAL.Repository.CSVRepository;
using DAL.Repository.Interfaces;
using Task = DAL.Entities.Task;

namespace BLL.Services
{
    public class TaskService
    {
        private IRepository<Task> _repository;
        public TaskService()
        {
            _repository = new TaskRepository();
            //_repository = new TaskCSVRepository();
        }

        public List<Task> GetAll()
        {
            var tasks = _repository.GetAll();
            return tasks.ToList();
        }

        public Task GetById(int id)
        {
            var task = _repository.GetById(id);
            List<Task> tmp = new List<Task> { task };
            return task;
        }

        public void Update(int id, string name, string description)
        {
            _repository.Update(new Task { Id = id, Name = name, Description = description });
        }

        public void Add(int id, string name, string description)
        {
            _repository.Add(new Task { Id = id, Name = name, Description = description });
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}