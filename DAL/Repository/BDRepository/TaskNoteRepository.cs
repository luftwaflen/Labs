using DAL.Entities;
using DAL.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repository.BDRepository
{
    public class TaskNoteRepository : IRepository<TaskNote>
    {
        private string _connectionString;
        public TaskNoteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(TaskNote entity)
        {
            string sqlExpression = "INSERT INTO TaskNote (TaskNote.AppointerId, TaskNote.ExecutorId, TaskNote.TaskId)" +
                "VALUES (@appointerId, @executorId, @taskId)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter appointerParameter = new SqlParameter("@appointerId", entity.AppointerId);
                SqlParameter executorParameter = new SqlParameter("@executorId", entity.ExecutorId);
                SqlParameter taskParameter = new SqlParameter("@taskId", entity.TaskId);
                command.Parameters.Add(appointerParameter);
                command.Parameters.Add(executorParameter);
                command.Parameters.Add(taskParameter);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sqlExpression = "DELETE FROM TaskNote WHERE (TaskNote.Id) = @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParameter = new SqlParameter("@id", id);
                command.Parameters.Add(idParameter);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<TaskNote> GetAll()
        {
            List<TaskNote> taskNotes = new List<TaskNote>();
            string sqlExpression = "SELECT * From TaskNote";

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
                            int appointerId = reader.GetInt32(1);
                            int executorId = reader.GetInt32(2);
                            int taskId = reader.GetInt32(3);
                            taskNotes.Add(new TaskNote
                            {
                                Id = id,
                                AppointerId = appointerId,
                                ExecutorId = executorId,
                                TaskId = taskId
                            });
                        }
                    }
                }
            }

            return taskNotes;
        }

        public TaskNote GetById(int id)
        {
            TaskNote taskNote = new TaskNote();
            string sqlExpression = "SELECT * From TaskNote WHERE (TaskNote.Id) = @id";

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
                        taskNote.Id = reader.GetInt32(0);
                        taskNote.AppointerId = reader.GetInt32(1);
                        taskNote.ExecutorId = reader.GetInt32(2);
                        taskNote.TaskId = reader.GetInt32(3);
                    }
                    else
                    {
                        throw new Exception("Wrong Id");
                    }
                }
            }

            return taskNote;
        }

        public void Update(TaskNote entity)
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