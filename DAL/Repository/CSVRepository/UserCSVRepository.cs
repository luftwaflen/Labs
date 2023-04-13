using CsvHelper;
using DAL.Entities;
using DAL.Repository.Changes;
using DAL.Repository.Interfaces;
using System.Globalization;

namespace DAL.Repository.CsvRepository
{
    public class UserCsvRepository :
        DataSourceConnector<UserEntity>, IRepository<UserEntity, UserEntityChange>
    {
        private readonly string _path;
        private List<UserEntityChange> _changeHistory { get; set; }
        private readonly Dictionary<ChangeOperation, Action<UserEntity>> _changeOperations;
        public UserCsvRepository(string path)
        {
            _changeHistory = new List<UserEntityChange>();

            _changeOperations = new Dictionary<ChangeOperation, Action<UserEntity>>();
            _changeOperations.Add(ChangeOperation.Insert, AddToDataSource);
            _changeOperations.Add(ChangeOperation.Update, UpdateToDataSource);
            _changeOperations.Add(ChangeOperation.Delete, DeleteFromDataSource);

            _path = path;
        }
        public void Add(UserEntity entity)
        {
            
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

        protected override void AddToDataSource(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateToDataSource(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override void DeleteFromDataSource(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}