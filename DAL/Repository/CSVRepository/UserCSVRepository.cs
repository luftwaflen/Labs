using CsvHelper;
using DAL.Entities;
using DAL.Repository.Changes;
using DAL.Repository.Interfaces;
using System.Globalization;

namespace DAL.Repository.CsvRepository
{
    public class UserCsvRepository : IRepository<UserEntity, UserEntityChange>
    {
        private string _path = "";
        public UserCsvRepository(string path)
        {
            _path = path;
        }

        public List<UserEntityChange> ChangeHistory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(UserEntity entity)
        {
            
        }
                
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetAll()
        {
            var users = new List<UserEntity>();

            using (var reader = new StreamReader(_path))
            {
                using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    users = csvReader.GetRecords<UserEntity>().ToList();
                }
            }

            return users;
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