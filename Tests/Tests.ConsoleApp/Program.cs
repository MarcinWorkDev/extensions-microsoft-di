using System;
using Microsoft.Extensions.DependencyInjection;
using MWork.Extensions.Microsoft.DependencyInjection.Extensions;

namespace MWork.Extensions.Microsoft.DependencyInjection.Tests.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var serviceProvider = new ServiceCollection()
                .AddNamedSingleton<ITest, TestA>("Class A")
                .AddNamedSingleton<ITest, TestA>("Class X")
                .AddSingleton<ITest, TestB>()
                .AddNamedSingleton<ITest, TestC>("Class C")
                .BuildServiceProvider();

            var serviceA = serviceProvider.GetNamedService<ITest>("Class A");
            serviceA?.PrintName();
            
            var serviceX = serviceProvider.GetNamedService<ITest>("Class X");
            serviceX?.PrintName();
            
            var serviceB = serviceProvider.GetNamedService<ITest>("Class B");
            serviceB?.PrintName(); // null cause TestB implementation is no named
            
            var serviceC = serviceProvider.GetNamedService<ITest>("Class C");
            serviceC?.PrintName();
        }
    }
}