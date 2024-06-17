using Gestion.Core.Business;
using Gestion.Core.Configuration;
using Gestion.Core.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;

namespace WinFormsGestion
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<Form1>());
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    // Read the configuration
                    var configuration = context.Configuration;

                    var config = new Gestion.Core.Configuration.Config
                    {
                        ConnectionString = configuration.GetConnectionString("GestionConnectionString")
                    };

                    services.AddSingleton(config);

                    services.AddTransient<ProductoBusiness>();
                    services.AddTransient<OperacionesBusiness>();
                    services.AddTransient<ProductoRepository>();
                    services.AddTransient<OperacionesRepository>();
                    services.AddTransient<Form1>();
                    services.AddTransient<Form2>();
                    services.AddTransient<Form3>();
                });
        }
    }
}
