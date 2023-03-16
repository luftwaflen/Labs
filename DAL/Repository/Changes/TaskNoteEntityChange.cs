using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository.Changes
{
    public class TaskNoteEntityChange : IChangeNote<TaskNoteEntity>
    {
        public string Operation { get; set; }
        public TaskNoteEntity OriginObject { get; set; }
        public TaskNoteEntity ChangedObject { get; set; }
    }
}