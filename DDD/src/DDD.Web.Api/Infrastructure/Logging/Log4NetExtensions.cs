using log4net;
using log4net.Config;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DDD.Web.Api.Infrastructure.Logging
{
    public static class Log4NetExtensions
    {
        public static void ConfigureLog4Net(this IApplicationEnvironment appEnv, string configFileRelativePath)
        {
            GlobalContext.Properties["appRoot"] = appEnv.ApplicationBasePath;
            XmlConfigurator.Configure(new FileInfo(Path.Combine(appEnv.ApplicationBasePath, configFileRelativePath)));
        }

        public static void AddLog4Net(this ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider (new Log4NetProvider());
        }
    }
}
