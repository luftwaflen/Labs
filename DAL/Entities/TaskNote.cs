namespace DAL.Entities
{
    public class TaskNote
    {
        public int Id { get; set; }
        public int AppointerId { get; set; }
        public int ExecutorId { get; set; }
        public int TaskId { get; set; }
    }
}