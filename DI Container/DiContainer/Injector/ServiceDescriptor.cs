using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiContainer.Injector
{
    class ServiceDescriptor
    {
        public Type Type { get;}

        public Type ImplementationType { get; }

        public object Implementation { get; internal set; }

        public ServiceLifeTime LifeTime { get; }

        public ServiceDescriptor(object implementation, ServiceLifeTime lifeTime)
        {
            Type = implementation.GetType();
            Implementation = implementation;
            LifeTime = lifeTime;
        }

        public ServiceDescriptor(Type serviceType, ServiceLifeTime lifeTime)
        {
            Type = serviceType;
            LifeTime = lifeTime;
        }
        public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifeTime lifeTime)
        {
            Type = serviceType;
            LifeTime = lifeTime;
            ImplementationType = implementationType;
        }
    }
}
