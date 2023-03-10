using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Xml;

namespace DAL.Repository.CsvRepository
{
    public class UserCsvRepository : IRepository<User>
    {
        private string _path = "";
        public UserCsvRepository()
        {
            
        }
        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}