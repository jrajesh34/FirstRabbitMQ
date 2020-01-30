using EOM.Kernel.Infrastructure.Interfaces;
using EOM.Kernel.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstRabbitMQ
{
    public static class Bootstrapper
    {
        public static IHostBuilder UseTaskProcessorServices(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices(ConfigureServices);
        }

        public static IHostBuilder UseTaskProcessorAppConfiguration(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddEnvironmentVariables();
            });
        }

        public static void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services)
        {
            services.AddSingleton<IEncryptionService, EncryptionService>();
            services.AddSingleton<IKekServiceFactory, KekServiceFactory>();
        }
    }
}
