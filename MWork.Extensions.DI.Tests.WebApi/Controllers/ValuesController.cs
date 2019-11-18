using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MWork.Extensions.DI.Abstraction;
using MWork.Extensions.DI.Extensions;
using MWork.Extensions.DI.Tests.WebApi.Services;

namespace MWork.Extensions.DI.Tests.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public ValuesController(IServiceProvider serviceProvider, ITest test)
        {
            var xx = serviceProvider.GetServices<ITest>();
            _serviceProvider = serviceProvider;

            var a = serviceProvider.GetNamedService<ITest>("Class A");
            var b = serviceProvider.GetNamedService<ITest>("Class B");
            var c = serviceProvider.GetNamedService<ITest>("Class C");
            var d = serviceProvider.GetNamedService<ITest>("Invalid");

            Console.WriteLine("Class A");
            a?.PrintName();
            Console.WriteLine("Class B");
            b?.PrintName();
            Console.WriteLine("Class C");
            c?.PrintName();
            Console.WriteLine("Invalid");
            d?.PrintName();
        }
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}