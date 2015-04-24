using AM.Data;
using AM.Domain;
using Ninject;

namespace Whisky.Web
{
    public static class MainKernel
    {
        public static IKernel Kernel { get; private set; }

        public static void Init()
        {
            var kernel = new StandardKernel();

            kernel.Load(new DataNinjectModule());
            kernel.Load(new DomainNinjectModule());

            Kernel = kernel;
        }
    }
}