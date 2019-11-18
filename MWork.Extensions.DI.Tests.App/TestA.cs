using System;

namespace MWork.Extensions.DI.Tests.App
{
    public class TestA : ITest
    {
        public void PrintName()
        {
            Console.WriteLine("TEST A");
        }
    }
}