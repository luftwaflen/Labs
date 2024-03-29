﻿using DAL.Entities;
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
        private List<UserEntityChange> _changeHistory;

        public UserService(string connectionString, int dataSource)
        {
            var dictionary = new Dictionary<int, IRepository<UserEntity, UserEntityChange>>();
            dictionary.Add(0, new UserCsvRepository(connectionString));
            dictionary.Add(1, new UserRepository(connectionString));

            _repository = dictionary[dataSource];

            switch (dataSource)
            {
                case 1:
                    _repository = new UserCsvRepository(connectionString);
                    break;

                default:
                    _repository = new UserRepository(connectionString);
                    break;
            }

            var users = _repository.GetAll();
            _users = users.ToList();
        }
        public List<UserEntity> GetAll() => _users;
        public UserEntity GetById(int id) => _users.FirstOrDefault(user => user.Id == id);

        public void Update(int id, string name)
        {
            var user = _users.FirstOrDefault(user => user.Id == id);
            var oldUser = new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                Login = user.Login,
                Password = user.Password
            };
            user.Name = name;

            //Историю записывать в репозитории, в бд сохранять методом commit
            _repository.Update(user);

            _changeHistory.Add(new UserEntityChange
            {
                Operation = "Update",
                OriginObject = oldUser,
                ChangedObject = user
            });
        }

        public void Add(string name)
        {
            var maxId = _users.Max(user => user.Id);
            var newUser = new UserEntity { Id = maxId + 1, Name = name };
            _users.Add(newUser);
            _repository.ChangeHistory.Add(new UserEntityChange
            {
                Operation = "Insert",
                ChangedObject = newUser
            });
        }

        public void Delete(int id)
        {
            _users.Remove(_users.FirstOrDefault(user => user.Id == id));
            _changeHistory.Add(new UserEntityChange
            {
                Operation = "Delete",
                ChangedObject = new UserEntity { Id = id }
            });
        }
        public void CommitChanges()
        {
            _repository.CommitChanges();
        }
    }
}