using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKC_IS.DataAccess.Interface.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
       
        object Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(int id);
        int GetCount();
        IList<TEntity> GetAll();
        IList<TEntity> GetPagedEntites(int startIndex, int requestCount, out int totalCount,
            string orderColumnName = null, bool asc = true);
        IList<TEntity> GetLatestEntities(string datePropertyName, int requestedCount, out int totalCount);
        void Save();
    }
}
