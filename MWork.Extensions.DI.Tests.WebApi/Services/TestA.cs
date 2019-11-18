using System;

namespace MWork.Extensions.DI.Tests.WebApi.Services
{
    public class TestA : ITest
    {
        public string Text { get; set; } = nameof(TestA);

        public void PrintName()
        {
            Console.WriteLine("TEST A");
        }
    }
}