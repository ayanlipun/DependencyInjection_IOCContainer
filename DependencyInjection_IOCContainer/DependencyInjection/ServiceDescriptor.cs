using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection_IOCContainer.DependencyInjection
{
    public class ServiceDescriptor
    {
        public Type ServiceType { get; }
        public Type ImplementationType { get; set; }
        public object Implementation { get; internal set; }
        public ServiceLifetime Lifetime { get; }

        public ServiceDescriptor(object implemenation, ServiceLifetime lifetime)
        {
            ServiceType = implemenation.GetType();
            Implementation = implemenation;
            Lifetime = lifetime;
        }

        public ServiceDescriptor(Type serviceType, ServiceLifetime lifetime)
        {
            ServiceType = serviceType;
            Lifetime = lifetime;
        }

        public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            ServiceType = serviceType;
            Lifetime = lifetime;
            ImplementationType = implementationType;
        }
    }
}
