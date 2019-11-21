using System;

namespace MWork.Extensions.Microsoft.DependencyInjection.Tests.WebApi.Services
{
    public class TestB : ITest
    {
        public string Text { get; set; } = nameof(TestB);
        
        public void PrintName()
        {
            Console.WriteLine("TEST B");
        }
    }
}