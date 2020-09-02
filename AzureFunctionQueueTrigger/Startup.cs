using Business.Interfaces;
using Business.Options;
using Business.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

[assembly: FunctionsStartup(typeof(AzureFunctionQueueTrigger.Startup))]

namespace AzureFunctionQueueTrigger
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)                
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                .AddJsonFile("local.settings.json", true, false)
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddSingleton<IConfiguration>(configuration);

            builder.Services.AddOptions<AzureStorageOptions>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("AzureStorageOptions").Bind(settings);
                });

            builder.Services.AddTransient<IAzureStorageService, AzureStorageService>();
        }
    }
}
