using DAL.Repository.Changes;
using DAL.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;
using TaskEntity = DAL.Entities.TaskEntity;

namespace DAL.Repository.DbRepository
{
    public class TaskRepository : IRepository<TaskEntity, TaskEntityChange>
    {
        private string _connectionString;
        public List<TaskEntityChange> ChangeHistory { get; set; }
        public TaskRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(TaskEntity entity)
        {
            string sqlExpression = "INSERT INTO Task (Task.Name, Task.Description) VALUES (@name, @description)";
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
            string sqlExpression = "DELETE FROM Task WHERE (Task.Id) = @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParameter = new SqlParameter("@id", id);
                command.Parameters.Add(idParameter);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<TaskEntity> GetAll()
        {
            List<TaskEntity> tasks = new List<TaskEntity>();
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
                            tasks.Add(new TaskEntity
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

        public TaskEntity GetById(int id)
        {
            TaskEntity task = new TaskEntity();
            string sqlExpression = "SELECT * From Task WHERE (Task.Id) = @id";

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
                        throw new Exception("Wrong Id");
                    }
                }
            }

            return task;
        }

        public void Update(TaskEntity entity)
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