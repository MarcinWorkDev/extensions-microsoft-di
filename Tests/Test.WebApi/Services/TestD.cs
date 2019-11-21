using System;
using MWork.Extensions.Microsoft.DependencyInjection.Abstraction;

namespace MWork.Extensions.Microsoft.DependencyInjection.Tests.WebApi.Services
{
    public class TestD : ITest, IWithName
    {
        public string Text { get; set; } = "BlaBlaBla";
        
        public void PrintName()
        {
            Console.WriteLine("TEST D");
        }

        public string ClassExternalName { get; set; } = "BlaBla";
    }
}