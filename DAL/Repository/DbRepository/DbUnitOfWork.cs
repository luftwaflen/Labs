using DAL.Repository.Interfaces;

namespace DAL.Repository.DbRepository
{
    public class DbUnitOfWork : IUnitOfWork
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}