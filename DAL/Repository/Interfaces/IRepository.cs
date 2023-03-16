namespace DAL.Repository.Interfaces
{
    public interface IRepository<T, TChange> : IDisposable
    {
        public List<TChange> ChangeHistory { get; set; }
        public T GetById(int id);
        public IEnumerable<T> GetAll();
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(int id);
        public void CommitChanges();
    }
}