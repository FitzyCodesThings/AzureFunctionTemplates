using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctionHttpTrigger
{
    public static class SampleHttpFunction
    {
        [FunctionName("SendEmail")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            // TODO Implement authorization (NOT AuthorizationLevel.Anonymous)! //

            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            
            var emailRequest = JsonConvert.DeserializeObject<EmailRequestBody>(requestBody);

            // Do things...
            // .........
            // Send the email...
            // Log it...
            // .........

            return new OkObjectResult($"Email [{emailRequest.Subject}] sent to {emailRequest.To}");
        }
    }
}
