using System;

namespace MWork.Extensions.Microsoft.DependencyInjection.Tests.WebApi.Services
{
    public class TestC : ITest
    {
        public string Text { get; set; } = nameof(TestC);
        
        public void PrintName()
        {
            Console.WriteLine("TEST C");
        }
    }
}