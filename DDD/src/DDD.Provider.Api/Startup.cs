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
using Microsoft.AspNetCore.SignalR;
using DDD.Provider.DataModel;
using Microsoft.AspNetCore.SignalR.Infrastructure;

//using Autofac;
//using Autofac.Extensions.DependencyInjection;

//namespace Microsoft.Extensions.Logging
//{
//    /// <summary>
//    /// ILoggerFactory extension methods for common scenarios.
//    /// </summary>
//    public static class LoggerFactoryExtensions
//    {
//        /// <summary>
//        /// Creates a new ILogger instance using the full name of the given type.
//        /// </summary>
//        /// <typeparam name="T">The type.</typeparam>
//        /// <param name="factory">The factory.</param>
//        public static ILogger CreateLogger<T>(this ILoggerFactory factory)
//        {
//            if (factory == null)
//            {
//                throw new ArgumentNullException("factory");
//            }
//            return new Logger<T>(factory);
//        }
//    }
//}

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
            //services.AddDbContext<ProviderDbContext>(op => op.UseSqlServer(Configuration["Data:POC_DDDContextConnection"]));
            services.AddDbContext<ProviderDbContext>(op => 
                op.UseSqlServer(@"Data Source=.\SQL2016;Initial Catalog=POC_DDD;Integrated Security=False;User ID=srvelicheti;Password=Secret@123;MultipleActiveResultSets=true;Trusted_Connection=true;")
                );
            
            var container = new Container();

            // Here we populate the container using the service collection.
            // This will register all services from the collection
            // into the container with the appropriate lifetime.
            container.Populate(services);
           
            var bus = NServiceBusBootStrapper.Init(container);
            IocBootstrapper.ConfigureIocContainer(container,bus);
            // Make sure we return an IServiceProvider, 
            // this makes Asp.Net Core use the StructureMap container.
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
            loggerFactory.AddLog4Net();
            var startupLogger = loggerFactory.CreateLogger<Startup>();
            startupLogger.LogDebug("testing logging");

            app.UseCors(pol => {
                pol.AllowAnyOrigin();
                pol.AllowAnyMethod();
                pol.AllowAnyHeader();
                pol.AllowCredentials();
            });
            app.UseStaticFiles();
            app.UseSignalR();
            app.UseMvc();
        }
    }
}
