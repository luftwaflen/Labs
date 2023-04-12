namespace DAL.Repository.Interfaces
{
    public interface IChangeNote<T>
    {
        public string Operation { get; set; }
        public T OriginObject { get; set; }
        public T ChangedObject { get; set; }
        public void ExecuteOperation();
    }
}