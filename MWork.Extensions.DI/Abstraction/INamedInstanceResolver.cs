using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace MWork.Extensions.DI.Abstraction
{
    public interface INamedInstanceResolver
    {
        void RegisterInstance(ServiceDescriptor serviceDescriptor, string name);
        
        T ResolveInstance<T>(IEnumerable<T> services, string name, bool throwNotExists = false);
    }
}