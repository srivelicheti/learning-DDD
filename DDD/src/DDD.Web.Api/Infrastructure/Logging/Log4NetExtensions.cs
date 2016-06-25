using log4net;
using log4net.Config;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace DDD.Web.Api.Infrastructure.Logging
{
    public static class Log4NetExtensions
    {
        public static void ConfigureLog4Net(this IHostingEnvironment appEnv, string configFileRelativePath)
        {
            GlobalContext.Properties["appRoot"] = appEnv.ContentRootPath; // ApplicationBasePath;
            var test = appEnv.WebRootPath;
            XmlConfigurator.Configure(new FileInfo(Path.Combine(appEnv.WebRootPath, configFileRelativePath)));
        }

        public static void AddLog4Net(this ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider (new Log4NetProvider());
        }
    }
}
