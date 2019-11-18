using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using MWork.Extensions.DI.Abstraction;

namespace MWork.Extensions.DI.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static TService GetNamedService<TService>(this IServiceProvider serviceProvider, string name)
        {
            var resolver = serviceProvider.GetService<INamedInstanceResolver>();

            if (resolver != null)
            {
                return resolver.ResolveInstance(serviceProvider.GetServices<TService>(), name);
            }

            return default;
        }
        
        public static TService GetRequiredNamedService<TService>(this IServiceProvider serviceProvider, string name)
        {
            var resolver = serviceProvider.GetService<INamedInstanceResolver>();

            if (resolver != null)
            {
                return resolver.ResolveInstance(serviceProvider.GetServices<TService>(), name, true);
            }

            return default;
        }
    }
}