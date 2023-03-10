using DAL.Entities;
using DAL.Repository.DbRepository;
using DAL.Repository.CsvRepository;
using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class UserService
    {
        private IRepository<User> _repository;
        private List<User> _users;
        public UserService(string connectionString)
        {
            _repository = new UserRepository(connectionString);
            //_repository = new UserCSVRepository();

            var users = _repository.GetAll();
            _users = users.ToList();
        }
        public List<User> GetAll() => _users;
        public User GetById(int id) => _users.FirstOrDefault(user => user.Id == id);

        public void Update(int id, string name)
        {
            var users = _users.FirstOrDefault(user => user.Id == id);
            users.Name = name;

            _repository.Update(new User { Id = id, Name = name });
        }

        public void Add(string name)
        {
            var maxId = _users.Max(user => user.Id);
            _users.Add(new User { Id = maxId + 1, Name = name });
            _repository.Add(new User { Name = name });
        }

        public void Delete(int id)
        {
            _users.Remove(_users.FirstOrDefault(user => user.Id == id));
            _repository.Delete(id);
        }
        public void CommitChanges()
        {
            
            _repository.Dispose();
        }
    }
}