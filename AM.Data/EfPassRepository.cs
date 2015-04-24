using System;
using System.Data.Entity;
using System.Linq;
using AM.Data.Entities;

namespace AM.Data
{
    internal class EfPassRepository : IPassRepository
    {
        private readonly IDbContext _dbContext;
        private IDbSet<Pass> _passesSet;

        public EfPassRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _passesSet = _dbContext.Set<Pass>();
        }

        public Pass GetById(object id)
        {
            return _passesSet.Find(id);
        }

        public void Insert(Pass entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _passesSet.Add(entity);

            _dbContext.SaveChanges();
        }

        public void Update(Pass entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _dbContext.SaveChanges();
        }

        public void Delete(Pass entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _passesSet.Remove(entity);

            _dbContext.SaveChanges();
        }

        public IQueryable<Pass> Query
        {
            get { return _passesSet; }
        }
    }
}