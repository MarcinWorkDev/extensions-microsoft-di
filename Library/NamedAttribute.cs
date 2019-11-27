using System;

namespace MWork.Extensions.Microsoft.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Constructor)]
    public class NamedAttribute : Attribute
    {
        public string Name { get; }
        
        public NamedAttribute(string name)
        {
            Name = name;
        }
    }
}
