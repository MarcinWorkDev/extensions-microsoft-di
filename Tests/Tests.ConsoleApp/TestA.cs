using System;

namespace MWork.Extensions.Microsoft.DependencyInjection.Tests.ConsoleApp
{
    public class TestA : ITest
    {
        public void PrintName()
        {
            Console.WriteLine("TEST A");
        }
    }
}