using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using MWork.Extensions.DI.Abstraction;

namespace MWork.Extensions.DI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNamedSingleton<TService, TImplementation>(this IServiceCollection services, string name)
            where TService : class
            where TImplementation : class, TService
        {
            return services.AddNamed<TService, TImplementation>(name, ServiceLifetime.Singleton);
        }
        
        public static IServiceCollection AddNamedScoped<TService, TImplementation>(this IServiceCollection services, string name)
            where TService : class
            where TImplementation : class, TService
        {
            return services.AddNamed<TService, TImplementation>(name, ServiceLifetime.Scoped);
        }
        
        public static IServiceCollection AddNamedTransient<TService, TImplementation>(this IServiceCollection services, string name)
            where TService : class
            where TImplementation : class, TService
        {
            return services.AddNamed<TService, TImplementation>(name, ServiceLifetime.Transient);
        }
        
        public static IServiceCollection AddNamedSingleton(this IServiceCollection services, Type service, Type implementation, string name)
        {
            return services.AddNamed(service, implementation, name, ServiceLifetime.Singleton);
        }
        
        public static IServiceCollection AddNamedScoped(this IServiceCollection services, Type service, Type implementation, string name)
        {
            return services.AddNamed(service, implementation, name, ServiceLifetime.Scoped);
        }
        
        public static IServiceCollection AddNamedTransient(this IServiceCollection services, Type service, Type implementation, string name)
        {
            return services.AddNamed(service, implementation, name, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddNamed<TService, TImplementation>(this IServiceCollection services, string name, ServiceLifetime lifetime)
            where TService : class
            where TImplementation : class, TService
        {
            return services.AddNamed(typeof(TService), typeof(TImplementation), name, lifetime);
        }
        
        public static IServiceCollection AddNamed(this IServiceCollection services, Type service, Type implementation, string name, ServiceLifetime lifetime)
        {
            var serviceDescriptor = new ServiceDescriptor(service, implementation, lifetime);
            
            if (services.Any(x => x.ServiceType == typeof(INamedInstanceResolver)) == false)
            {
                services.AddSingleton<INamedInstanceResolver>(new NamedInstanceResolver());
            }

            var resolver = services.First(x => x.ServiceType == typeof(INamedInstanceResolver)).ImplementationInstance as INamedInstanceResolver;
            
            resolver?.RegisterInstance(serviceDescriptor, name);

            services.Add(serviceDescriptor);
            
            return services;
        }
    }
}