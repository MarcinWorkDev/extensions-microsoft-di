namespace MWork.Extensions.Microsoft.DependencyInjection.Tests.WebApi.Services
{
    public interface ITest
    {
        string Text { get; set; }
        
        void PrintName();
    }
}