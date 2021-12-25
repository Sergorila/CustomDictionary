using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiContainer.Injector
{
    class Container
    {
        private Dictionary<Type, ServiceDescriptor> _serviceDescriptors;
        
        public Container(Dictionary<Type, ServiceDescriptor> serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors;
        }

        public object GetService(Type serviceType, ref List<Type> dependsList)
        {
            var descriptor = _serviceDescriptors[serviceType];

            if (descriptor == null)
            {
                throw new Exception($"There is no type of {serviceType.Name}");
            }

            if (descriptor.Implementation != null)
            {
                return descriptor.Implementation;
            }

            var actualType = descriptor.ImplementationType ?? descriptor.Type;

            if (actualType.IsAbstract || actualType.IsInterface)
            {
                throw new Exception("Can't create an instance of interfaces or abstract classes");
            }

            var constructorInfo = actualType.GetConstructors().First();

            var parameters = constructorInfo.GetParameters();

            List<object> newParameters = new List<object>();
            foreach (var parameter in parameters)
            {
                if (dependsList.Contains(serviceType))
                {
                    throw new Exception($"{serviceType.Name} type is already referenced.");
                }
                dependsList.Add(serviceType);
                var newParameter = GetService(parameter.ParameterType, ref dependsList);
                newParameters.Add(newParameter);
            }

            var res = newParameters.ToArray();

            var implementation = Activator.CreateInstance(actualType, res);

            if (descriptor.LifeTime == ServiceLifeTime.Singleton)
            {
                descriptor.Implementation = implementation;
            }

            return implementation;
        }

        public object GetService(Type serviceType)
        {
            List<Type> depsList = new List<Type>();

            return GetService(serviceType, ref depsList);
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }
    }
}
