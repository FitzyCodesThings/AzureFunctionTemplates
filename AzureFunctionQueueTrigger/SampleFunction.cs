using System;
using Business.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AzureFunctionQueueTrigger
{
    public class SampleFunction
    {
        private readonly IConfiguration configuration;
        private readonly IAzureStorageService azureStorageService;

        public SampleFunction(IConfiguration configuration, IAzureStorageService azureStorageService)
        {
            this.configuration = configuration;
            this.azureStorageService = azureStorageService;
        }

        [FunctionName("SampleFunction")]
        public void Run([QueueTrigger("samplequeue", Connection = "AzureWebJobsStorage")]string myQueueItem, ILogger log)
        {
            log.LogWarning("SomeConfigurationSetting: {value}", configuration.GetSection("Values")["SomeConfigurationSetting"]);
            log.LogInformation("C# Queue trigger function processed: {myQueueItem}", myQueueItem);
        }
    }
}
