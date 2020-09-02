using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Triggers
{
    public class QueueTest
    {
        private readonly IAzureStorageService azureStorageService;

        public QueueTest(IAzureStorageService azureStorageService)
        {
            this.azureStorageService = azureStorageService;
        }

        public void Run()
        {
            Console.WriteLine("Writing message to queue.");
            this.azureStorageService.EnqueueMessage("samplequeue", "Test Message");
        }
    }
}
