using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using MWork.Extensions.Microsoft.DependencyInjection.Abstraction;
using MWork.Extensions.Microsoft.DependencyInjection.Extensions;

namespace MWork.Extensions.Microsoft.DependencyInjection
{
    public class NamedInstanceResolver : INamedInstanceResolver
    {
        private readonly Dictionary<Type, Dictionary<string, ServiceDescriptor>> _registrations;

        public NamedInstanceResolver()
        {
            _registrations = new Dictionary<Type, Dictionary<string, ServiceDescriptor>>();
        }

        public void RegisterInstance(ServiceDescriptor serviceDescriptor, string name)
        {
            var name2 = name.NameNormalize();
            
            var serviceType = serviceDescriptor.ServiceType;

            var existsType = _registrations.ContainsKey(serviceType);

            if (existsType == false)
            {
                _registrations.Add(serviceType, new Dictionary<string, ServiceDescriptor>());
            }

            var exists = _registrations[serviceDescriptor.ServiceType].ContainsKey(name2);
            
            if (exists)
            {
                throw new Exception($"Instance of type '{serviceDescriptor.ServiceType.FullName}' with name '{name}' already exists.");
            }

            _registrations[serviceDescriptor.ServiceType].Add(name2, serviceDescriptor);
        }

        public T ResolveInstance<T>(IEnumerable<T> services, string name, bool throwNotExists = false)
        {
            var type = typeof(T);
            var name2 = name?.NameNormalize() ?? throw new ArgumentNullException(nameof(name));

            if (_registrations.ContainsKey(type) && _registrations[type].ContainsKey(name2))
            {
                var typeRegistered = _registrations[type][name2];

                if (typeRegistered != default)
                {
                    var service = services
                        .FirstOrDefault(x => x.Equals(typeRegistered.ImplementationInstance)
                                             || x.GetType() == typeRegistered.ImplementationType);

                    if (service != null)
                    {
                        return service;
                    }
                }
            }

            if (throwNotExists)
            {
                throw new Exception($"Instance of type '{type.FullName}' with name '{name}' not found.");
            }

            return default;
        }
    }
}