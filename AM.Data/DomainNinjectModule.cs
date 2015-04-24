using Ninject.Modules;

namespace AM.Data
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbContext>().To<AMDbContext>();
            Bind<IPassRepository>().To<EfPassRepository>();
        }
    }
}