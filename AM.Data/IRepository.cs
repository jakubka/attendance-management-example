using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(object id);

        void Insert(TEntity entity);
        
        void Update(TEntity entity);

        void Delete(TEntity entity);
        
        IQueryable<TEntity> Query { get; }
    }
}
