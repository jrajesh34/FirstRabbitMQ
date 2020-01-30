using EOM.Kernel.Infrastructure.Interfaces;
using EOM.Kernel.Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
//using ODX.AutoScaler;
using ODX.DataAccess;
using ODX.Infrastructure;
using ODX.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
namespace FirstRabbitMQ
{
    static class Program
    {
        private static Unity.UnityContainer container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            // Application.Run(new Form2());
            //var builder = new HostBuilder()
            //        .UseTaskProcessorAppConfiguration()
            //        .UseTaskProcessorServices();
            Application.Run(container.Resolve<Form1>());
        }

        private static void Bootstrap()
        {
            // Create the container as usual.
            container = new UnityContainer();
            container.RegisterType<IDbFactory, DbFactory>();
            container.RegisterType<IConnectionStringProvider, ConfigurationWrapper>();
            container.RegisterType<IEncryptionService, EncryptionService>();
            container.RegisterType<IEncryptionServiceRepository, EncryptionServiceRepository>();
            // Register your types, for instance:
        }
    }
}
