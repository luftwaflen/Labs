using DAL.Entities;
using DAL.Repository.BDRepository;
using DAL.Repository.CSVRepository;
using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class UserService
    {
        private IRepository<User> _repository;
        public UserService()
        {
            _repository = new UserRepository();
            //_repository = new UserCSVRepository();
        }
        public List<User> GetAll()
        {
            var users = _repository.GetAll();
            return users.ToList();
        }
        public User GetById(int id)
        {
            var user = _repository.GetById(id);
            List<User> tmp = new List<User> { user };
            return user;
        }

        public void Update(int id, string name)
        {
            _repository.Update(new User { Id = id, Name = name });
        }

        public void Add(string name)
        {
            _repository.Add(new User { Name = name });
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}