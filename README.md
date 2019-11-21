# MARCIN.WORK 
### .NET Core Dependency Injection - named instances functionality

Master:  
![](https://github.com/MarcinWorkDev/extensions-microsoft-di/workflows/BuildMe/badge.svg?branch=master)  
[![NuGet Badge](https://buildstats.info/nuget/MWork.Extensions.Microsoft.DependencyInjectio)](https://www.nuget.org/packages/MWork.Extensions.Microsoft.DependencyInjection/)  
Develop:  
![](https://github.com/MarcinWorkDev/extensions-microsoft-di/workflows/BuildMe/badge.svg?branch=develop)
[![NuGet Badge](https://buildstats.info/nuget/MWork.Extensions.Microsoft.DependencyInjectio?includePreReleases=true)](https://www.nuget.org/packages/MWork.Extensions.Microsoft.DependencyInjection/)

### Requires:
* `Microsoft.Extensions.DependencyInjection`

### Usage:

#### Registration

###### METHOD 1 - Using interface
* Implement `IWithName` interface
* Set value `of ClassExternalName` class property
* Register implementation

```c#
public interface ITest
{
    ...
}
```
```c#
public class Test : ITest, IWithName
{
    public string ClassExternalName { get; } = "TestClass"
    
    ...
}
```
```c#
public void ConfigureServices(IServiceCollection services)
{
    services
        .AddSingleton<ITest, Test>();
}
```

###### METHOD 2 - Using extension
* Register implementation using `WithName(string name)` or `AddNamed*Lifetime*` extension

```c#
public interface ITest
{
    ...
}
```
```c#
public class Test : ITest
{
    ...
}
```
```c#
public void ConfigureServices(IServiceCollection services)
{
    services
        .AddSingleton<ITest, Test>()
        .WithName("TestClass");
        
    // OR
    
    services
        .AddNamedSingleton<ITest, Test>("TestClass");
}
```

#### Resolving

###### METHOD 1 - Using `IServiceProvider`
```c#
public class TestService
{
    private readonly ITest _test;

    public TestService(IServiceProvider serviceProvider)
    {
        _test = serviceProvider.GetNamedService<ITest>("TestClass");
        
        // OR
        
        _test = serviceProvider.GetRequiredNamedService<ITest>("TestClass");
    }
}
```

###### METHOD 2 - Using `NamedAtribute`
**Method not implemented yet!**
```c#
public class TestService
{
    private readonly ITest _test;

    public TestService([Named("TestClass")]ITest test)
    {
        _test = test;
    }
}
```
