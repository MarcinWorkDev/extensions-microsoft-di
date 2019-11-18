using System;

namespace MWork.Extensions.DI.Tests.App
{
    public class TestC : ITest
    {
        public void PrintName()
        {
            Console.WriteLine("TEST C");
        }
    }
}