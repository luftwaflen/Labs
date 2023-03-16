using DAL.Entities;
using DAL.Repository.Changes;
using DAL.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repository.DbRepository
{
    public class TaskNoteRepository : IRepository<TaskNoteEntity, TaskNoteEntityChange>
    {
        private string _connectionString;
        public List<TaskNoteEntityChange> ChangeHistory { get; set; }
        public TaskNoteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(TaskNoteEntity entity)
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

        public IEnumerable<TaskNoteEntity> GetAll()
        {
            List<TaskNoteEntity> taskNotes = new List<TaskNoteEntity>();
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
                            taskNotes.Add(new TaskNoteEntity
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

        public TaskNoteEntity GetById(int id)
        {
            TaskNoteEntity taskNote = new TaskNoteEntity();
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

        public void Update(TaskNoteEntity entity)
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