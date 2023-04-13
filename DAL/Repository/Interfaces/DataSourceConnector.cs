using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public abstract class DataSourceConnector<T>
    {
        protected abstract void AddToDataSource(T entity);
        protected abstract void UpdateToDataSource(T entity);
        protected abstract void DeleteFromDataSource(T entity);
    }
}
