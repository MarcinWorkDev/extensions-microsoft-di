using System;

namespace MWork.Extensions.Microsoft.DependencyInjection.Tests.ConsoleApp
{
    public class TestC : ITest
    {
        public void PrintName()
        {
            Console.WriteLine("TEST C");
        }
    }
}