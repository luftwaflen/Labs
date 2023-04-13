using DAL.Entities;
using DAL.Repository.Changes;
using DAL.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repository.DbRepository
{
    public class UserRepository : IRepository<UserEntity, UserEntityChange>
    {
        private string _connectionString;
        public List<UserEntityChange> ChangeHistory { get; set; }
        private readonly Dictionary<ChangeOperation, Action<UserEntity>> _dict;
        public UserRepository(string connectionString)
        {
            _dict = new Dictionary<ChangeOperation, Action<UserEntity>>();
            _dict.Add(ChangeOperation.Insert, Add);
            _dict.Add(ChangeOperation.Update, Update);
            _dict.Add(ChangeOperation.Delete, Delete);

            _connectionString = connectionString;
        }
        public void Add(UserEntity entity)
        {
            var sqlExpression = "INSERT INTO [User] ([User].Name, [User].Login, [User].Password) VALUES (@name, @login, @password)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
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

        public void Delete(UserEntity user)
        {
            var sqlExpression = "DELETE FROM [User] WHERE ([User].Id) = @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(sqlExpression, connection);
                var idParameter = new SqlParameter("@id", user.Id);
                command.Parameters.Add(idParameter);

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
                SqlCommand command = new SqlCommand(sqlExpression, connection);

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

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);

                var idParameter = new SqlParameter("@id", id);
                command.Parameters.Add(idParameter);

                using (SqlDataReader reader = command.ExecuteReader())
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
            throw new NotImplementedException();
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
            foreach (var change in ChangeHistory)
            {
                _dict[change.Operation].Invoke(change.ChangedObject);

                //switch (change.Operation)
                //{
                //    case "Insert":
                //        {
                //            Add(change.ChangedObject);
                //        }
                //        break;

                //    case "Update":
                //        {
                //            Update(change.ChangedObject);
                //        }
                //        break;

                //    case "Delete":
                //        {
                //            Delete(change.ChangedObject.Id);
                //        }
                //        break;

                //    default:
                //        break;
                //}
            }
            Dispose();
        }
    }
}