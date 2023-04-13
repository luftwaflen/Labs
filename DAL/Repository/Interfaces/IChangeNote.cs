namespace DAL.Repository.Interfaces
{
    public enum ChangeOperation
    {
        Insert,
        Update,
        Delete
    }
    public interface IChangeNote<T>
    {
        public ChangeOperation Operation { get; set; }
        public T OriginObject { get; set; }
        public T ChangedObject { get; set; }
    }
}