using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repository.BDRepository
{    
    public class UserRepository : IRepository<User>
    {
        private string _connectionString;
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(User entity)
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

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
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
                            users.Add(new User
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

        public User GetById(int id)
        {
            User user = new User();
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

        public void Update(User entity)
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
    }
}