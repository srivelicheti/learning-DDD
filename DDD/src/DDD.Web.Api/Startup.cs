using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StructureMap;
using DDD.Domain.Common.Event;
using Microsoft.Extensions.PlatformAbstractions;
using DDD.Web.Api.Infrastructure.Logging;
using DDD.Web.Api.App_Start;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.SignalR;
//using Microsoft.AspNet.SignalR.


namespace DDD.Web.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile("config.Json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            env.ConfigureLog4Net("log4net.xml");
            AutoMapperConfig.RegisterMappings();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddSignalR();
            services.AddEntityFrameworkSqlServer(); // .AddEntityFramework().AddSqlServer();
            var container = new Container();

            // Here we populate the container using the service collection.
            // This will register all services from the collection
            // into the container with the appropriate lifetime.
            container.Populate(services);
            var bus = NServiceBusBootStrapper.Init(container);
            IocBootstrapper.ConfigureIocContainer(container,bus);
            //DomainEventsBootStrapper.RegisterEvents(container);
            // Make sure we return an IServiceProvider, 
            // this makes DNX use the StructureMap container.
            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.Use(async (context, next) => {
                    context.Request.Headers.Remove("content-type");
                    context.Request.Headers.Add("content-type", new[] { "application/json" });
                    await next();
                });
            }
            
            var loggingConfig = Configuration.GetSection("Logging");
            loggerFactory.AddConsole(loggingConfig);
            loggerFactory.AddDebug();
            //loggerFactory.

           // app.UseIISPlatformHandler();
            app.UseCors(pol => {
                pol.AllowAnyOrigin();
                pol.AllowAnyMethod();
                pol.AllowAnyHeader();
                pol.AllowCredentials();
            });
            app.UseStaticFiles();
           // app.UseSignalR();
            app.UseMvc();
        }

        // Entry point for the application.
        //public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
