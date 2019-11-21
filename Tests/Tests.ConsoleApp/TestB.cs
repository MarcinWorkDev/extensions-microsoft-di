using System;

namespace MWork.Extensions.Microsoft.DependencyInjection.Tests.ConsoleApp
{
    public class TestB : ITest
    {
        public void PrintName()
        {
            Console.WriteLine("TEST B");
        }
    }
}