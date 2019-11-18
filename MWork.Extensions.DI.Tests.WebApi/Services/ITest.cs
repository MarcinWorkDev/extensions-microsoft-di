namespace MWork.Extensions.DI.Tests.WebApi.Services
{
    public interface ITest
    {
        string Text { get; set; }
        
        void PrintName();
    }
}