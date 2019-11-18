using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using MWork.Extensions.DI.Abstraction;
using MWork.Extensions.DI.Extensions;

namespace MWork.Extensions.DI
{
    public class NamedInstanceResolver : INamedInstanceResolver
    {
        private readonly Dictionary<Type, Dictionary<string, Type>> _registrations;

        public NamedInstanceResolver()
        {
            _registrations = new Dictionary<Type, Dictionary<string, Type>>();
        }

        public void RegisterInstance(ServiceDescriptor serviceDescriptor, string name)
        {
            var name2 = name.NameNormalize();
            
            var serviceType = serviceDescriptor.ServiceType;
            var implementationType = serviceDescriptor.ImplementationType;

            var existsType = _registrations.ContainsKey(serviceType);

            if (existsType == false)
            {
                _registrations.Add(serviceType, new Dictionary<string, Type>());
            }

            var exists = _registrations[serviceDescriptor.ServiceType].ContainsKey(name2);
            
            if (exists)
            {
                throw new Exception($"Instance of type '{serviceDescriptor.ServiceType.FullName}' with name '{name}' already exists.");
            }

            _registrations[serviceDescriptor.ServiceType].Add(name2, implementationType);
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
                    var service = services.FirstOrDefault(x => x.GetType() == typeRegistered);

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