using DAL.Entities;
using DAL.Repository.DbRepository;
using DAL.Repository.CsvRepository;
using DAL.Repository.Interfaces;
using DAL.Repository.Changes;
using BLL.Interfaces;

namespace BLL.Services
{
    public class UserService : IService
    {
        private IRepository<UserEntity, UserEntityChange> _repository;
        private List<UserEntity> _users;

        public UserService(string connectionString, int dataSource)
        {
            var dataSourceDictionary = new Dictionary<int, IRepository<UserEntity, UserEntityChange>>();
            dataSourceDictionary.Add(0, new UserCsvRepository(connectionString));
            dataSourceDictionary.Add(1, new UserRepository(connectionString));

            _repository = dataSourceDictionary[dataSource];

            var users = _repository.GetAll();
            _users = users.ToList();
        }
        public List<UserEntity> GetAll() => _users;
        public UserEntity GetById(int id) => _users.FirstOrDefault(user => user.Id == id);

        public void Update(int id, string name)
        {
            var user = _users.FirstOrDefault(user => user.Id == id);
            user.Name = name;
            _repository.Update(user);
        }

        public void Add(string name)
        {
            var maxId = _users.Max(user => user.Id);
            var newUser = new UserEntity { Id = maxId + 1, Name = name };
            _users.Add(newUser);
        }

        public void Delete(int id)
        {
            var userToDel = _users.FirstOrDefault(user => user.Id == id);
            _repository.Delete(userToDel);
            _users.Remove(userToDel);
        }
        public void CommitChanges()
        {
            _repository.CommitChanges();
        }
    }
}