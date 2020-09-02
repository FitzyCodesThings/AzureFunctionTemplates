using Business.Interfaces;
using Business.Options;
using Business.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Triggers
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddUserSecrets<Program>(true)
                .AddJsonFile("appsettings.json", true)                
                .Build();

            var services = ConfigureServices(configuration);

            var serviceProvider = services.BuildServiceProvider();

            IServiceScope scope = serviceProvider.CreateScope();

            Console.ReadLine();

            scope.ServiceProvider.GetRequiredService<QueueTest>().Run();

            Console.ReadLine();
        }

        private static IServiceCollection ConfigureServices(IConfiguration configuration)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton(configuration);

            services.AddOptions<AzureStorageOptions>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("AzureStorageOptions").Bind(settings);
                });

            services.AddTransient<IAzureStorageService, AzureStorageService>();
            services.AddTransient<QueueTest>();

            return services;
        }

        private static void DisposeServices(ServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                return;
            }
            if (serviceProvider is IDisposable)
            {
                ((IDisposable)serviceProvider).Dispose();
            }
        }
    }
}
