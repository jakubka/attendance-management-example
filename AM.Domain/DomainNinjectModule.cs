using Ninject.Modules;

namespace AM.Domain
{
    public class DomainNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITimeAtWorkCalculator>().To<TimeAtWorkCalculator>();
        }
    }
}