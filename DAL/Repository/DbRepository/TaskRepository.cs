using DAL.Repository.Changes;
using DAL.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;
using TaskEntity = DAL.Entities.TaskEntity;

namespace DAL.Repository.DbRepository
{
    public class TaskRepository :
        DataSourceConnector<TaskEntity>, IRepository<TaskEntity, TaskEntityChange>
    {
        private readonly string _connectionString;
        private List<TaskEntityChange> _changeHistory;
        private readonly Dictionary<ChangeOperation, Action<TaskEntity>> _changeOperations;
        public TaskRepository(string connectionString)
        {
            _changeHistory = new List<TaskEntityChange>();

            _changeOperations = new Dictionary<ChangeOperation, Action<TaskEntity>>();
            _changeOperations.Add(ChangeOperation.Insert, AddToDataSource);
            _changeOperations.Add(ChangeOperation.Update, UpdateToDataSource);
            _changeOperations.Add(ChangeOperation.Delete, DeleteFromDataSource);

            _connectionString = connectionString;
        }
        public void Add(TaskEntity entity)
        {
            var newChange = new TaskEntityChange
            {
                Operation = ChangeOperation.Insert,
                ChangedObject = entity
            };
            _changeHistory.Add(newChange);
        }
        protected override void AddToDataSource(TaskEntity entity)
        {
            var sqlExpression = "INSERT INTO Task (Task.Name, Task.Description) VALUES (@name, @description)";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(sqlExpression, connection);
                var nameParameter = new SqlParameter("@name", entity.Name);
                var descriptionParameter = new SqlParameter("@description", entity.Description);
                command.Parameters.Add(nameParameter);
                command.Parameters.Add(descriptionParameter);

                command.ExecuteNonQuery();
            }
        }
        public IEnumerable<TaskEntity> GetAll()
        {
            var tasks = new List<TaskEntity>();
            var sqlExpression = "SELECT * From Task";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0);
                            var name = reader.GetString(1);
                            var description = reader.GetString(2);
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
            var task = new TaskEntity();
            var sqlExpression = "SELECT * From Task WHERE (Task.Id) = @id";

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
            var newChange = new TaskEntityChange
            {
                Operation = ChangeOperation.Update,
                ChangedObject = entity
            };
            _changeHistory.Add(newChange);
        }
        protected override void UpdateToDataSource(TaskEntity entity)
        {
            
        }
        public void Delete(TaskEntity entity)
        {
            var newChange = new TaskEntityChange
            {
                Operation = ChangeOperation.Delete,
                ChangedObject = entity
            };
            _changeHistory.Add(newChange);
        }
        protected override void DeleteFromDataSource(TaskEntity entity)
        {
            var sqlExpression = "DELETE FROM Task WHERE (Task.Id) = @id";
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