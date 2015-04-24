using System.Data.Entity;
using AM.Data.Entities;

namespace AM.Data
{
    public class AMDbContext : DbContext
    {
        public AMDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
