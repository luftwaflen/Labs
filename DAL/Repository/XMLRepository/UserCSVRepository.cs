using DAL.Entities;
using DAL.Repository.Interfaces;
using System.Xml;

namespace DAL.Repository.XMLRepository
{
    public class UserCSVRepository : IRepository<User>
    {
        string path = "";
        XmlElement xRoot;
        public UserCSVRepository()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            xRoot = xDoc.DocumentElement;
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