using DAL.Entities;
using DAL.Repository.Changes;
using DAL.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repository.DbRepository
{
    public class UserRepository :
        DataSourceConnector<UserEntity>, IRepository<UserEntity, UserEntityChange>
    {
        private readonly string _connectionString;
        private List<UserEntityChange> _changeHistory;
        private readonly Dictionary<ChangeOperation, Action<UserEntity>> _changeOperations;
        public UserRepository(string connectionString)
        {
            _changeHistory = new List<UserEntityChange>();

            _changeOperations = new Dictionary<ChangeOperation, Action<UserEntity>>();
            _changeOperations.Add(ChangeOperation.Insert, AddToDataSource);
            _changeOperations.Add(ChangeOperation.Update, UpdateToDataSource);
            _changeOperations.Add(ChangeOperation.Delete, DeleteFromDataSource);

            _connectionString = connectionString;
        }
        public void Add(UserEntity entity)
        {
            var newChange = new UserEntityChange
            {
                Operation = ChangeOperation.Insert,
                ChangedObject = entity
            };
            _changeHistory.Add(newChange);
        }
        protected override void AddToDataSource(UserEntity entity)
        {
            var sqlExpression = "INSERT INTO [User] ([User].Name, [User].Login, [User].Password) VALUES (@name, @login, @password)";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(sqlExpression, connection);
                var nameParameter = new SqlParameter("@name", entity.Name);
                var loginParameter = new SqlParameter("@login", entity.Name);
                var pasParameter = new SqlParameter("@password", entity.Name);
                command.Parameters.Add(nameParameter);
                command.Parameters.Add(loginParameter);
                command.Parameters.Add(pasParameter);

                command.ExecuteNonQuery();
            }
        }
        public IEnumerable<UserEntity> GetAll()
        {
            var users = new List<UserEntity>();
            var sqlExpression = "SELECT * From [User]";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0);
                            var name = reader.GetString(1);
                            users.Add(new UserEntity
                            {
                                Id = id,
                                Name = name
                            });
                        }
                    }
                }
            }

            return users;
        }
        public UserEntity GetById(int id)
        {
            var user = new UserEntity();
            var sqlExpression = "SELECT * From [User] WHERE ([User].Id) = @id";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);

                var idParameter = new SqlParameter("@id", id);
                command.Parameters.Add(idParameter);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            user.Id = reader.GetInt32(0);
                            user.Name = reader.GetString(1);
                        }
                    }
                    else
                    {
                        throw new Exception("Wrong Id");
                    }
                }
            }

            return user;
        }
        public void Update(UserEntity entity)
        {
            var newChange = new UserEntityChange
            {
                Operation = ChangeOperation.Update,
                ChangedObject = entity
            };
            _changeHistory.Add(newChange);
        }
        protected override void UpdateToDataSource(UserEntity entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(UserEntity entity)
        {
            var newChange = new UserEntityChange
            {
                Operation = ChangeOperation.Delete,
                ChangedObject = entity
            };
        }
        protected override void DeleteFromDataSource(UserEntity entity)
        {
            var sqlExpression = "DELETE FROM [User] WHERE ([User].Id) = @id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(sqlExpression, connection);
                var idParameter = new SqlParameter("@id", entity.Id);
                command.Parameters.Add(idParameter);

                command.ExecuteNonQuery();
            }
        }
        public void Dispose()
        {
            var connection = new SqlConnection(_connectionString);
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public void CommitChanges()
        {
            foreach (var change in _changeHistory)
            {
                _changeOperations[change.Operation].Invoke(change.ChangedObject);
            }
            Dispose();
        }
    }
}