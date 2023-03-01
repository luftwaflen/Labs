using DAL.Repository.Interfaces;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Task = DAL.Entities.Task;

namespace DAL.Repository.BDRepository
{
    public class TaskRepository : IRepository<Task>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["TaskManagerDB"].ConnectionString;
        public void Add(Task entity)
        {
            string sqlExpression = "INSERT INTO Task (Name, Description) VALUES (@name, @description)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter nameParameter = new SqlParameter("@name", entity.Name);
                SqlParameter descriptionParameter = new SqlParameter("@description", entity.Description);
                command.Parameters.Add(nameParameter);
                command.Parameters.Add(descriptionParameter);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sqlExpression = "DELETE FROM Task WHERE (User.Id) = @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParameter = new SqlParameter("@id", id);
                command.Parameters.Add(idParameter);

                command.ExecuteNonQuery();
            }
        }
                
        public IEnumerable<Task> GetAll()
        {
            List<Task> tasks = new List<Task>();
            string sqlExpression = "SELECT * From Task";

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
                            string description = reader.GetString(2);
                            tasks.Add(new Task
                            {
                                Id = id,
                                Name = name,
                                Description = description
                            });
                        }
                    }
                }
            }

            return tasks;
        }

        public Task GetById(int id)
        {
            Task task = new Task();
            string sqlExpression = "SELECT * From Task WHERE (User.Id) = @id";

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
                        task.Id = reader.GetInt32(0);
                        task.Name = reader.GetString(1);
                        task.Description = reader.GetString(2);
                    }
                    else
                    {
                        task = null;
                    }
                }
            }

            return task;
        }

        public void Update(Task entity)
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