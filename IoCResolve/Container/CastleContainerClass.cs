using Castle.Windsor;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCResolve.Container
{
    public static class CastleContainer
    {
        private static IWindsorContainer container;

        public static IWindsorContainer Instance
        {
            get
            {
                if (container == null)
                {
                    container = new WindsorContainer();
                }
                return container;
            }
            // exposing a setter alleviates some common component testing problems
            set { container = value; }
        }

        public static T Resolve<T>()
        {
            return Instance.Resolve<T>();
        }

        public static void Dispose()
        {
            if (container != null)
                container.Dispose();
            container = null;
        }
    }
}
