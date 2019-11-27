using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using MWork.Extensions.Microsoft.DependencyInjection.Extensions;
using MWork.Extensions.Microsoft.DependencyInjection.Abstractions;
using MWork.Extensions.Microsoft.DependencyInjection;

public class MWorkServiceProvider : IServiceProvider
{
	private readonly IServiceProvider _microsoftServiceProvider;

	public MWorkServiceProvider(IServiceProvider serviceProvider)
	{
		var microsoftServiceProvider = serviceProvider
			.GetServices<IServiceProvider>()
			.FirstOrDefault(x => x.GetType() == typeof(Microsoft.Extensions.DependencyInjection.ServiceProvider));
		
		// just temporary :) will be fully implemented IServiceProvider
		if (microsoftServiceProvider == null)
		{
			throw new Exception("Microsoft.Extensions.DependencyInjection.ServiceProvider as IServiceProvider implementation in service collection is required!");
		}
		
		_microsoftServiceProvider = microsoftServiceProvider;
	}
	
	public object GetService(Type serviceType)
	{
		var nameAttr = Attribute.GetCustomAttribute(serviceType, typeof(NamedAttribute));
		
		if (nameAttr != null)
		{
			var name = nameAttr.Name;
		
			return _microsoftServiceProvider.GetNamedService(serviceType, name);
		}
	
		return _microsoftServiceProvider.GetService(serviceType);
	};
}
