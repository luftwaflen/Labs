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
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(UserEntity entity)
        {
            string sqlExpression = "INSERT INTO [User] ([User].Name, [User].Login, [User].Password) VALUES (@name, @login, @password)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter nameParameter = new SqlParameter("@name", entity.Name);
                SqlParameter loginParameter = new SqlParameter("@login", entity.Name);
                SqlParameter pasParameter = new SqlParameter("@password", entity.Name);
                command.Parameters.Add(nameParameter);
                command.Parameters.Add(loginParameter);
                command.Parameters.Add(pasParameter);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sqlExpression = "DELETE FROM [User] WHERE ([User].Id) = @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParameter = new SqlParameter("@id", id);
                command.Parameters.Add(idParameter);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<UserEntity> GetAll()
        {
            List<UserEntity> users = new List<UserEntity>();
            string sqlExpression = "SELECT * From [User]";

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
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
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
            UserEntity user = new UserEntity();
            string sqlExpression = "SELECT * From [User] WHERE ([User].Id) = @id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                SqlParameter idParameter = new SqlParameter("@id", id);
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
            SqlConnection connection = new SqlConnection(_connectionString);
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void CommitChanges()
        {
            foreach (var change in ChangeHistory)
            {
                switch (change.Operation)
                {
                    case "Insert":
                        {
                            Add(change.ChangedObject);
                        }
                        break;

                    case "Update":
                        {
                            Update(change.ChangedObject);
                        }
                        break;

                    case "Delete":
                        {
                            Delete(change.ChangedObject.Id);
                        }
                        break;

                    default:
                        break;
                }
            }
            Dispose();
        }
    }
}