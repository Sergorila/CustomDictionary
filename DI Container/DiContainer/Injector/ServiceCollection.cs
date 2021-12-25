using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiContainer.Injector
{
    class ServiceCollection
    {
        private Dictionary<Type, ServiceDescriptor> _serviceDescriptors = new Dictionary<Type, ServiceDescriptor>();
        
        public void RegisterSigleton<TService>()
        {
            _serviceDescriptors.Add(typeof(TService), new ServiceDescriptor(typeof(TService), ServiceLifeTime.Singleton));
        }

        public void RegisterSingleton<TService>(TService implementation)
        {
            _serviceDescriptors.Add(typeof(TService), new ServiceDescriptor(implementation, ServiceLifeTime.Singleton));
        }

        public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
        {
            _serviceDescriptors.Add(typeof(TService), new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifeTime.Singleton));
        }

        public void RegisterTransient<TService>()
        {
            _serviceDescriptors.Add(typeof(TService), new ServiceDescriptor(typeof(TService), ServiceLifeTime.Transient));
        }

        public void RegisterTransient<TService, TImplementation>() where TImplementation : TService
        {
            _serviceDescriptors.Add(typeof(TService), new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifeTime.Transient));
        }

        public Container GenerateContainer()
        {
            return new Container(_serviceDescriptors);
        }
    }
}
