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
            return serviceProvider.GetService<TService>(name, false);
        }
        
        public static TService GetRequiredNamedService<TService>(this IServiceProvider serviceProvider, string name)
        {
            return serviceProvider.GetService<TService>(name, true);
        }

        private static TService GetService<TService>(this IServiceProvider serviceProvider, string name,
            bool throwNotExits)
        {
            var services = serviceProvider
                .GetServices<TService>()
                .ToList();

            if (services.Any())
            {
                // Try using IWithName interface
                var withName = services
                    .Select(x => new
                    {gdfgdgdfgdfg
                        Service = x,
                        WithName = x.GetType()
                            .GetInterfaces()
                            .Any(i => i == typeof(IWithName))
                    })
                    .LastOrDefault(x => x.WithName && (x.Service as IWithName)?.ClassExternalName == name);
                
                if (withName != default)
                {
                    return withName.Service;
                }
            
                // Try using resolver
                var resolver = serviceProvider.GetRequiredService<INamedInstanceResolver>();
                return resolver.ResolveInstance(serviceProvider.GetServices<TService>(), name, throwNotExits);
            }

            return default;
        }
    }
}