using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository.Changes
{
    public class TaskEntityChange : IChangeNote<TaskEntity>
    {
        public ChangeOperation Operation { get; set; }
        public TaskEntity OriginObject { get; set; }
        public TaskEntity ChangedObject { get; set; }
    }
}