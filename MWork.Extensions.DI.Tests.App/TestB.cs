using System;

namespace MWork.Extensions.DI.Tests.App
{
    public class TestB : ITest
    {
        public void PrintName()
        {
            Console.WriteLine("TEST B");
        }
    }
}