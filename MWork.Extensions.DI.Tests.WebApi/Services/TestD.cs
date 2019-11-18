using System;
using MWork.Extensions.DI.Abstraction;

namespace MWork.Extensions.DI.Tests.WebApi.Services
{
    public class TestD : ITest, IWithName
    {
        public string Text { get; set; } = "BlaBlaBla";
        
        public void PrintName()
        {
            Console.WriteLine("TEST D");
        }

        public string __InstanceName { get; set; } = "BlaBla";
    }
}