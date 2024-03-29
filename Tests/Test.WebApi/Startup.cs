﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MWork.Extensions.Microsoft.DependencyInjection.Extensions;
using MWork.Extensions.Microsoft.DependencyInjection.Tests.WebApi.Services;

namespace MWork.Extensions.Microsoft.DependencyInjection.Tests.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<ITest, TestA>().WithName("Class A")
                .AddSingleton<ITest, TestA>().WithName("Class X")
                .AddSingleton<ITest, TestB>()
                .AddNamedScoped<ITest, TestC>("Class C")
                .AddSingleton<ITest>(new TestC(){Text = "Init"}).WithName("InitC1").WithName("InitC2")
                .AddScoped<ITest, TestD>(); // name albo key dowolnego typu nie musi to być string, i może zamiast AddNamed lepiej .WithName

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}