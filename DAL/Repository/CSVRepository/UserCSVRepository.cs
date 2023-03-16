using DAL.Entities;
using DAL.Repository.Changes;
using DAL.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Xml;

namespace DAL.Repository.CsvRepository
{
    public class UserCsvRepository : IRepository<UserEntity, UserEntityChange>
    {
        private string _path = "";
        public UserCsvRepository()
        {
            
        }

        public List<UserEntityChange> ChangeHistory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(UserEntity entity)
        {
            throw new NotImplementedException();
        }
                
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void CommitChanges()
        {
            throw new NotImplementedException();
        }
    }
}