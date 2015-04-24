using System.Data.Entity;
using AM.Data.Entities;

namespace AM.Data
{
    public class AMDbContext : DbContext, IDbContext
    {
        public AMDbContext() : base("AMConnectionString")
        {
        }

        public AMDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Pass> Passes { get; set; }

        public IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}