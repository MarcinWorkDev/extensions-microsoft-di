using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MWork.Extensions.Microsoft.DependencyInjection.Abstractions;
using MWork.Extensions.Microsoft.DependencyInjection.Extensions;
using MWork.Extensions.Microsoft.DependencyInjection.Tests.WebApi.Services;

namespace MWork.Extensions.Microsoft.DependencyInjection.Tests.WebApi.Controllers
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
            
            var e = serviceProvider.GetNamedService<ITest>("InitC1");
            var f = serviceProvider.GetNamedService<ITest>("InitC2");
            
            var m = serviceProvider.GetNamedService<ITest>("BlaBla");
            var n = serviceProvider.GetNamedService<ITest>("KwaKwa");
            
            var x = serviceProvider.GetNamedService<ITest>("Class X");

            var res = serviceProvider.GetService<INamedInstanceResolver>();
            var all = serviceProvider.GetServices<ITest>();

            Console.WriteLine("Class A " + a?.Text);
            Console.WriteLine("Class B " + b?.Text);
            Console.WriteLine("Class C " + c?.Text);
            Console.WriteLine("Invalid " + d?.Text);
            Console.WriteLine("InitC1 " + e?.Text);
            Console.WriteLine("InitC2 " + f?.Text);
            
            Console.WriteLine("BlaBla " + m?.Text);
            Console.WriteLine("KwaKwa " + n?.Text);
            
            Console.WriteLine("Class X " + x?.Text);

            if (f != null) f.Text = "AAAAAAA!!!!";
            var f2 = serviceProvider.GetNamedService<ITest>("InitC2");
            
            Console.WriteLine("InitC2 " + f2?.Text);
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