using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DependencyInjection_IOCContainer.DependencyInjection
{
    public class DiContainer
    {
        private List<ServiceDescriptor> _serviceDescriptors;
        public DiContainer(List<ServiceDescriptor> serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors;
        }

        public object GetService(Type serviceType)
        {
            var descriptor = _serviceDescriptors.SingleOrDefault(x => x.ServiceType == serviceType);

            if (descriptor == null)
            {
                throw new Exception($"Service of type {serviceType.Name} is not registered");
            }
            if (descriptor.Implementation != null)
            {
                return descriptor.Implementation;
            }          

            var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

            if (actualType.IsAbstract || actualType.IsInterface)
            {
                throw new Exception("Can not instantiate abstract classes or interfaces.");
            }

            var constructorInfo = actualType.GetConstructors().First();
            var parameters = constructorInfo.GetParameters().Select(x => GetService(x.ParameterType)).ToArray();

            var implementation = Activator.CreateInstance(actualType, parameters);

            if (descriptor.Lifetime == ServiceLifetime.Singleton)
            {
                descriptor.Implementation = implementation;
            }
            return implementation;

            //return (T)Activator.CreateInstance(descriptor.ServiceType);  // This process will create diff Guid number for singleton.
        }
        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }
    }
}
